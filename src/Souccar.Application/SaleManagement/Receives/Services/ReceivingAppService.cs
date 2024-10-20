using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.UI;
using Souccar.SaleManagement.PurchaseInvoices.Services;
using Souccar.SaleManagement.PurchaseInvoices;
using Souccar.SaleManagement.PurchaseInvoices.Receives;
using Souccar.SaleManagement.PurchaseInvoices.Receives.Services;
using Abp.Events.Bus;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.CashFlows;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Events;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Events;
using Souccar.SaleManagement.Stocks.Event;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Receives.Dto;

namespace Souccar.SaleManagement.Receives.Services
{
    public class ReceivingAppService :
        AsyncSouccarAppService<Receiving, ReceivingDto, int, FullPagedRequestDto, CreateReceivingDto, UpdateReceivingDto>, IReceivingAppService
    {
        private readonly IReceivingDomainService _receivingDomainService;
        private readonly IInvoiceDomainService _invoiceDomainService;
        public ReceivingAppService(IReceivingDomainService receivingDomainService, IInvoiceDomainService invoiceDomainService) : base(receivingDomainService)
        {
            _receivingDomainService = receivingDomainService;
            _invoiceDomainService = invoiceDomainService;
        }

        public IList<ReceivingDto> GetAllByInvoiceId(int invoiceId)
        {
            var receiving = _receivingDomainService.GetAllByInvoiceId(invoiceId).ToList();
            return ObjectMapper.Map<List<ReceivingDto>>(receiving);
        }

        public override async Task<ReceivingDto> CreateAsync(CreateReceivingDto input)
        {
            var receiving = await base.CreateAsync(input);

            var invoice = _invoiceDomainService.GetWithDetail(input.InvoiceId.Value);
            if (invoice == null)
                throw new UserFriendlyException("Not Found");

            invoice.Status = PurchaseInvoiceStatus.PartialRecieved;
            if (invoice.TotalQuantity == invoice.TotalReceivedQuantity)
                invoice.Status = PurchaseInvoiceStatus.Received;

            await _invoiceDomainService.UpdateAsync(invoice);

            if (receiving.ClearanceCompanyId != null)
            {
                await EventBus.Default.TriggerAsync(new ClearanceCompanyCashFlowCreateEventData(
                    receiving.ClearanceCostCurrency == 1 ? receiving.ClearanceCost : 0,
                    receiving.ClearanceCostCurrency == 0 ? receiving.ClearanceCost : 0,
                    TransactionName.ClearanceCost,
                    receiving.ClearanceCompanyId,
                    receiving.Id,
                    L(LocalizationResource.ClearanceCost)
                    ));
            }
            if (receiving.TransportCompanyId != null)
            {
                await EventBus.Default.TriggerAsync(new TransportCompanyCashFlowCreateEventData(
                    receiving.TransportCostCurrency == 1 ? receiving.TransportCost : 0,
                    receiving.TransportCostCurrency == 0 ? receiving.TransportCost : 0,
                    TransactionName.TransportCost,
                    receiving.TransportCompanyId,
                    receiving.Id,
                    L(LocalizationResource.TransportCost)
                    ));
            }
            foreach (var receivingItem in receiving.ReceivingItems)
            {
                var invoiceItem = invoice.InvoiseDetails.FirstOrDefault(x => x.Id == receivingItem.InvoiceItemId);
                if (invoiceItem is not null)
                {
                    await EventBus.Default.TriggerAsync(new CustomerCashFlowCreateEventData(
                    invoice.Currency == Currency.Dollar ? receivingItem.ReceivedQuantity * invoiceItem.TotalMaterilPrice : 0,
                    invoice.Currency == Currency.Dinar ? receivingItem.ReceivedQuantity * invoiceItem.TotalMaterilPrice : 0,
                    TransactionName.TransportCost,
                    invoice.SupplierId,
                    receivingItem.Id,
                    L(LocalizationResource.CostOfReceivingTheMaterial, invoiceItem?.OfferItem?.Material?.Name)
                    ));

                    var numberInLargeQuentity = invoiceItem.OfferItem.AddedBySmallUnit ? 0 : receivingItem.ReceivedQuantity;
                    var numberInSmallQuentity = invoiceItem.OfferItem.AddedBySmallUnit ? receivingItem.ReceivedQuantity : 0;
                    await EventBus.Default.TriggerAsync(new UpdateStockEventData(
                        invoiceItem.OfferItem.MaterialId,
                        numberInLargeQuentity, numberInSmallQuentity));
                }
            }
            return receiving;
        }

        public override async Task<ReceivingDto> UpdateAsync(UpdateReceivingDto input)
        {
            var oldReceivedQuantities = (await GetAggregateAsync(new EntityDto() { Id = input.Id })).ReceivingItems.Select(x => new
            {
                ItemId = x.Id,
                x.ReceivedQuantity
            }).ToList();
            var oldreceive = await _receivingDomainService.GetAgreggateAsync(input.Id);

            ObjectMapper.Map(input, oldreceive);
            foreach (var item in oldreceive.ReceivingItems)
            {
                var inputItem = input.ReceivingItems.FirstOrDefault(x => x.Id == item.Id);
                if (inputItem != null)
                {
                    item.ReceivedQuantity = inputItem.ReceivedQuantity;
                }
            }
            var newReceive = await _receivingDomainService.UpdateAsync(oldreceive);
            var invoice = _invoiceDomainService.GetWithDetail(input.InvoiceId.Value);
            if (invoice == null)
                throw new UserFriendlyException("Not Found");

            if (invoice.TotalReceivedQuantity > invoice.TotalQuantity)
                throw new UserFriendlyException($"������ ������� �� ���� �� ���� ���� �� {invoice.TotalQuantity}");
            if (newReceive.ClearanceCompanyId != null)
            {
                await EventBus.Default.TriggerAsync(new ClearanceCompanyCashFlowUpdateEventData(
                    (int)newReceive.ClearanceCostCurrency == 1 ? newReceive.ClearanceCost : 0,
                    newReceive.ClearanceCostCurrency == 0 ? newReceive.ClearanceCost : 0,
                    TransactionName.ClearanceCost,
                    newReceive.ClearanceCompanyId,
                    newReceive.Id,
                    L(LocalizationResource.ClearanceCost)
                    ));
            }
            if (newReceive.TransportCompanyId != null)
            {
                await EventBus.Default.TriggerAsync(new TransportCompanyCashFlowUpdateEventData(
                    (int)newReceive.TransportCostCurrency == 1 ? newReceive.TransportCost : 0,
                    newReceive.TransportCostCurrency == 0 ? newReceive.TransportCost : 0,
                    TransactionName.TransportCost,
                    newReceive.TransportCompanyId,
                    newReceive.Id,
                    L(LocalizationResource.TransportCost)
                    ));
            }


            var items = await Task.FromResult(_receivingDomainService.GetItemsByReceivingId(oldreceive.Id));
            foreach (var item in items)
            {
                if (!input.ReceivingItems.Any(x => x.Id == item.Id))
                {
                    await _receivingDomainService.DeleteItemAsync(item.Id);
                }
            }

            foreach (var receivingItem in newReceive.ReceivingItems)
            {
                var oldReceivedQuantity = oldReceivedQuantities.First(x => x.ItemId == receivingItem.Id).ReceivedQuantity;
                var difQuantity = oldReceivedQuantity - receivingItem.ReceivedQuantity;
                var invoiceItem = invoice.InvoiseDetails.FirstOrDefault(x => x.Id == receivingItem.InvoiceItemId);
                if (invoiceItem is not null)
                {
                    await EventBus.Default.TriggerAsync(new CustomerCashFlowUpdateEventData(
                    invoice.Currency == Currency.Dollar ? receivingItem.ReceivedQuantity * invoiceItem.TotalMaterilPrice : 0,
                    invoice.Currency == Currency.Dinar ? receivingItem.ReceivedQuantity * invoiceItem.TotalMaterilPrice : 0,
                    TransactionName.ReceivingCost,
                    invoice.SupplierId,
                    receivingItem.Id,
                    L(LocalizationResource.CostOfReceivingTheMaterial, invoiceItem?.OfferItem?.Material?.Name)
                    ));

                    var numberInLargeQuentity = invoiceItem.OfferItem.AddedBySmallUnit ? 0 : -difQuantity;
                    var numberInSmallQuentity = invoiceItem.OfferItem.AddedBySmallUnit ? -difQuantity : 0;
                    await EventBus.Default.TriggerAsync(new UpdateStockEventData(
                        invoiceItem.OfferItem.MaterialId,
                        numberInLargeQuentity, numberInSmallQuentity));
                }
            }
            var invoiceStatus = invoice.TotalReceivedQuantity == invoice.TotalQuantity ?
                PurchaseInvoiceStatus.Received :
                PurchaseInvoiceStatus.PartialRecieved;
            if (invoice.Status != invoiceStatus)
            {
                invoice.Status = invoiceStatus;
                _invoiceDomainService.Update(invoice);
            }
            return ObjectMapper.Map<ReceivingDto>(newReceive);
        }
    }
}

