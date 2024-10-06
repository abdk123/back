using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.UI;
using System;
using Abp.Events.Bus;
using Souccar.SaleManagement.Logs.Events;
using Souccar.SaleManagement.Logs;
using Souccar.SaleManagement.PurchaseInvoices.Events;
using Souccar.SaleManagement.PurchaseOrders.SupplierOffers;
using Souccar.SaleManagement.SupplierOffers.Dto;
using Souccar.SaleManagement.PurchaseOrders.SupplierOffers.Services;
using Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services;
using Souccar.SaleManagement.PurchaseInvoices;
using Souccar.SaleManagement.PurchaseInvoices.Services;

namespace Souccar.SaleManagement.SupplierOffers.Services
{
    public class SupplierOfferAppService :
        AsyncSouccarAppService<SupplierOffer, SupplierOfferDto, int, FullPagedRequestDto, CreateSupplierOfferDto, UpdateSupplierOfferDto>, ISupplierOfferAppService
    {
        private readonly ISupplierOfferDomainService _supplierOfferDomainService;
        private readonly IInvoiceDomainService _invoiceDomainService;

        public SupplierOfferAppService(ISupplierOfferDomainService offerDomainService, IInvoiceDomainService invoiceDomainService)
        : base(offerDomainService)
        {
            _supplierOfferDomainService = offerDomainService;
            _invoiceDomainService = invoiceDomainService;
        }

        public IList<UpdateSupplierOfferItemDto> GetItemsBySupplierOfferId(int offerId)
        {
            var items = _supplierOfferDomainService.GetItemsBySupplierOfferId(offerId);
            return ObjectMapper.Map<IList<UpdateSupplierOfferItemDto>>(items);
        }

        public SupplierOfferDto GetSupplierOfferWithDetailId(int offerId)
        {
            var offer = _supplierOfferDomainService.GetSupplierOfferWithDetail(offerId);
            return ObjectMapper.Map<SupplierOfferDto>(offer);
        }

        
        public override async Task<SupplierOfferDto> UpdateAsync(UpdateSupplierOfferDto input)
        {
            var oldSupplierOffer = await _supplierOfferDomainService.GetAsync(input.Id);
            ObjectMapper.Map<UpdateSupplierOfferDto, SupplierOffer>(input, oldSupplierOffer);
            var newSupplierOffer = await _supplierOfferDomainService.UpdateAsync(oldSupplierOffer);
            var items = await Task.FromResult(_supplierOfferDomainService.GetItemsBySupplierOfferId(oldSupplierOffer.Id));
            foreach (var item in items)
            {
                if (!input.SupplierOfferItems.Any(x => x.Id == item.Id))
                {
                    await _supplierOfferDomainService.DeleteItemAsync(item.Id);
                }
            }
            
            return ObjectMapper.Map<SupplierOfferDto>(newSupplierOffer);

        }

        public override async Task<SupplierOfferDto> CreateAsync(CreateSupplierOfferDto input)
        {
            var dto = await base.CreateAsync(input);
            //var currentUser = await GetCurrentUserAsync();
            //await EventBus.Default.TriggerAsync(new CreateOrderLogEventData(new OrderLog()
            //{
            //    ActionId = dto.Id,
            //    RelatedId = dto.Id,
            //    Type = OrderLogType.CreateSupplierOffer,
            //    FullName = currentUser?.FullName,
            //    Attributes = new List<OrderLogAttribute>()
            //    {
            //        new OrderLogAttribute("SupplierOfferId",dto.Id.ToString()),
            //        new OrderLogAttribute("TotalQuantity",dto.TotalQuantity.ToString()),
            //        new OrderLogAttribute("TotalPrice",dto.TotalPrice.ToString()),
            //    }
            //}));
            return dto;
        }

        protected override IQueryable<SupplierOffer> ApplySearching(IQueryable<SupplierOffer> query, Type typeDto, FullPagedRequestDto input)
        {
            if (string.IsNullOrEmpty(input.Keyword))
                return query;
            return query.Where(x => x.Supplier.FullName.Contains(input.Keyword));
        }

        public async Task<string> GetPoForBySupplierOfferItemId(int offerItemId)
        {
            var po = await _supplierOfferDomainService.GetPoForBySupplierOfferItemId(offerItemId);
            return po;
        }

        public async Task<SupplierOfferDto> ConvertToPurchaseInvoice(ConvertSupplierOfferToPurchaseInvoiceDto input)
        {
            var offer = await _supplierOfferDomainService.GetAsync(input.SupplierId);
            if (offer is null)
                throw new UserFriendlyException("SupplierOffer not found");

            if(offer.Status != SupplierOfferStatus.Approved)
            {
                throw new UserFriendlyException(ValidationMessage.TheOfferMustBeApprovedFirst);
            }

            var invoice = new PurchaseInvoice()
            {
                Status = PurchaseInvoiceStatus.NotPriced,
                SupplierOfferId = offer.Id,
                SupplierId = offer.SupplierId,
                Currency = offer.Currency,
                InvoiseDetails = offer.SupplierOfferItems.Select(offerItem => new PurchaseInvoiceItem()
                {
                    SupplierOfferItemId = offerItem.Id,
                }).ToList()
            };
            await _invoiceDomainService.InsertAsync(invoice);

            return ObjectMapper.Map<SupplierOfferDto>(offer);
        }
    }
}

