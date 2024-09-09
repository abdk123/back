using Souccar.SaleManagement.PurchaseOrders.Receives.Dto;
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

namespace Souccar.SaleManagement.PurchaseOrders.Receives.Services
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
            if(invoice.TotalQuantity == (invoice.TotalReceivedQuantity))
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
                var invoiceItem = invoice.InvoiseDetails.FirstOrDefault(x=>x.Id == receivingItem.InvoiceItemId);
                if(invoiceItem is not null)
                {
                    await EventBus.Default.TriggerAsync(new CustomerCashFlowCreateEventData(
                    invoice.Currency == Currency.Dollar ? invoiceItem.Quantity : 0,
                    invoice.Currency == Currency.Dinar ? invoiceItem.Quantity : 0,
                    TransactionName.TransportCost,
                    invoice.SupplierId,
                    receivingItem.Id,
                    L(LocalizationResource.CostOfReceivingTheMaterial, invoiceItem?.OfferItem?.Material?.Name)
                    ));

                    var numberInLargeQuentity = invoiceItem.OfferItem.AddedBySmallUnit ? 0 : invoiceItem.Quantity;
                    var numberInSmallQuentity = invoiceItem.OfferItem.AddedBySmallUnit ? invoiceItem.Quantity:0;
                    await EventBus.Default.TriggerAsync(new UpdateStockEventData(
                        invoiceItem.OfferItem.MaterialId,
                        numberInLargeQuentity, numberInSmallQuentity));
                }
            }
            return receiving;
        }

        public override async Task<ReceivingDto> UpdateAsync(UpdateReceivingDto input)
        {
            var oldOffer = await _receivingDomainService.GetAsync(input.Id);
            ObjectMapper.Map<UpdateReceivingDto, Receiving>(input, oldOffer);
            var newOffer = await _receivingDomainService.UpdateAsync(oldOffer);
            var items = await Task.FromResult(_receivingDomainService.GetItemsByReceivingId(oldOffer.Id));
            foreach (var item in items)
            {
                if (!input.ReceivingItems.Any(x => x.Id == item.Id))
                {
                    await _receivingDomainService.DeleteItemAsync(item.Id);
                }
            }
            return ObjectMapper.Map<ReceivingDto>(newOffer);
        }
    }
}

