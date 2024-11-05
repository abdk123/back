using Souccar.Extinsions;
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
using Souccar.SaleManagement.Receives.Dto;
using System.Linq.Expressions;
using System;
using Abp.Application.Services;
using Abp.Domain.Repositories;

namespace Souccar.SaleManagement.Receives.Services
{
    public class ReceivingAppService
         : AsyncCrudAppService<Receiving, ReceivingDto, int, PagedReceivingResultRequestDto, CreateReceivingDto, ReceivingDto>, IReceivingAppService
    {
        private readonly IReceivingDomainService _receivingDomainService;
        private readonly IInvoiceDomainService _invoiceDomainService;
        private readonly IRepository<Receiving> _receivingRepository;

        public Expression<Func<Receiving, bool>> include { get; private set; }

        public ReceivingAppService(IReceivingDomainService receivingDomainService, IInvoiceDomainService invoiceDomainService, IRepository<Receiving> receivingRepository) : base(receivingRepository)
        {
            _receivingDomainService = receivingDomainService;
            _invoiceDomainService = invoiceDomainService;
            _receivingRepository = receivingRepository;
        }

        public IList<ReceivingDto> GetAllByInvoiceId(int invoiceId)
        {
            var receiving = _receivingDomainService.GetAllByInvoiceId(invoiceId).ToList();
            return ObjectMapper.Map<List<ReceivingDto>>(receiving);
        }
        protected override IQueryable<Receiving> CreateFilteredQuery(PagedReceivingResultRequestDto input)
        {
            var query = _receivingDomainService.GetAllByInvoiceId(input.InvoiceId);
            if(!string.IsNullOrEmpty(input.Keyword))
            {
                query = query.Where(x => x.ClearanceCompany.Name.Contains(input.Keyword) || x.TransportCompany.Name.Contains(input.Keyword));
            }
            return query;
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

        public override async Task<ReceivingDto> UpdateAsync(ReceivingDto input)
        {
            var oldreceive = _receivingRepository
                .GetAllIncluding(x => x.ReceivingItems)
                .FirstOrDefault(x => x.Id == input.Id);

            var oldReceivedQuantities = oldreceive.ReceivingItems.Select(x => new
            {
                ItemId = x.Id,
                x.ReceivedQuantity
            }).ToList();


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
                throw new UserFriendlyException($"ÇáßãíÉ ÇáãÓáãÉ áÇ íãßä Çä Êßæä ÇßÈÑ ãä {invoice.TotalQuantity}");
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

        public ReceivingDto GetWithDetail(int receiveId)
        {
            var receiving = _receivingRepository.GetAllIncluding(x => x.ReceivingItems)
                .FirstOrDefault(x => x.Id == receiveId);
            return ObjectMapper.Map<ReceivingDto>(receiving);
        }
    }
}

