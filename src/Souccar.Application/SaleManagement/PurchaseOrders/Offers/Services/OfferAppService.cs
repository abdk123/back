using Souccar.SaleManagement.PurchaseOrders.Offers.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.UI;
using System;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus;
using Souccar.SaleManagement.PurchaseOrders.Invoises.Events;
using Souccar.SaleManagement.Logs.Events;
using Souccar.SaleManagement.Logs;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Services
{
    public class OfferAppService :
        AsyncSouccarAppService<Offer, OfferDto, int, FullPagedRequestDto, CreateOfferDto, UpdateOfferDto>, IOfferAppService
    {
        private readonly IOfferDomainService _offerDomainService;

        public OfferAppService(IOfferDomainService offerDomainService)
        : base(offerDomainService)
        {
            _offerDomainService = offerDomainService;
        }

        public async Task<OfferDto> ChangeStatusAsync(ChangeOfferStatusDto input)
        {
            var offer = await _offerDomainService.GetAsync(input.Id);

            if (string.IsNullOrEmpty(input.PorchaseOrderId))
            {
                throw new UserFriendlyException(ValidationMessage.PoIsRequired);
            }

            offer.PorchaseOrderId = input.PorchaseOrderId;
            var approveDate = DateTime.Now;
            DateTime.TryParse(input.ApproveDate, out approveDate);
            offer.ApproveDate = approveDate;
            offer.Status = (OfferStatus)input.Status;
            if (input.SupplierId != null)
            {
                offer.SupplierId = input.SupplierId;
            }
            await _offerDomainService.UpdateAsync(offer);
            if (input.GenerateInvoice)
            {
                if (input.Status == (int)OfferStatus.Pending)
                {
                    throw new UserFriendlyException(ValidationMessage.TheOfferMustBeApprovedFirst);
                }
                if (input.SupplierId == null)
                {
                    throw new UserFriendlyException(ValidationMessage.SupplierIsRequired);
                }
                var offerItems = _offerDomainService.GetItemsByOfferId(offer.Id);
                await EventBus.Default.TriggerAsync(new CreateInvoiceEventData()
                {
                    OfferId = offer.Id,
                    OfferItems = offerItems
                });

                var currentUser = await GetCurrentUserAsync();
                await EventBus.Default.TriggerAsync(new CreateOrderLogEventData(new OrderLog()
                {
                    ActionId = offer.Id,
                    RelatedId = offer.Id,
                    Type = OrderLogType.CreatePurchaseInvoice,
                    FullName = currentUser?.FullName,
                    Attributes = new List<OrderLogAttribute>()
                    {
                        new OrderLogAttribute("ApproveDate",input.ApproveDate),
                        new OrderLogAttribute("PorchaseOrderId",input.PorchaseOrderId),
                    }
                }));
            }
            return GetOfferWithDetailId(input.Id);
        }

        public IList<UpdateOfferItemDto> GetItemsByOfferId(int offerId)
        {
            var items = _offerDomainService.GetItemsByOfferId(offerId);
            return ObjectMapper.Map<IList<UpdateOfferItemDto>>(items);
        }

        public OfferDto GetOfferWithDetailId(int offerId)
        {
            var offer = _offerDomainService.GetOfferWithDetail(offerId);
            return ObjectMapper.Map<OfferDto>(offer);
        }

        public override async Task<OfferDto> UpdateAsync(UpdateOfferDto input)
        {
            var oldOffer = await _offerDomainService.GetAsync(input.Id);
            ObjectMapper.Map<UpdateOfferDto, Offer>(input, oldOffer);
            var newOffer = await _offerDomainService.UpdateAsync(oldOffer);
            var items = await Task.FromResult(_offerDomainService.GetItemsByOfferId(oldOffer.Id));
            foreach (var item in items)
            {
                if (!input.OfferItems.Any(x => x.Id == item.Id))
                {
                    await _offerDomainService.DeleteItemAsync(item.Id);
                }
            }
            var currentUser = await GetCurrentUserAsync();
            await EventBus.Default.TriggerAsync(new CreateOrderLogEventData(new OrderLog()
            {
                ActionId = newOffer.Id,
                RelatedId = newOffer.Id,
                Type = OrderLogType.UpdateOffer,
                FullName = currentUser?.FullName,
                Attributes = new List<OrderLogAttribute>()
            }));
            return ObjectMapper.Map<OfferDto>(newOffer);

        }

        public override async Task<OfferDto> CreateAsync(CreateOfferDto input)
        {
            var dto = await base.CreateAsync(input);
            var currentUser = await GetCurrentUserAsync();
            await EventBus.Default.TriggerAsync(new CreateOrderLogEventData(new OrderLog()
            {
                ActionId = dto.Id,
                RelatedId = dto.Id,
                Type = OrderLogType.CreateOffer,
                FullName = currentUser?.FullName,
                Attributes = new List<OrderLogAttribute>()
                {
                    new OrderLogAttribute("OfferId",dto.Id.ToString()),
                    new OrderLogAttribute("TotalQuantity",dto.TotalQuantity.ToString()),
                    new OrderLogAttribute("TotalPrice",dto.TotalPrice.ToString()),
                }
            }));
            return dto;
        }

        protected override IQueryable<Offer> ApplySearching(IQueryable<Offer> query, Type typeDto, FullPagedRequestDto input)
        {
            if (string.IsNullOrEmpty(input.Keyword))
                return query;
            return query.Where(x => x.Customer.FullName.Contains(input.Keyword));
        }

        public async Task<string> GetPoForByOfferItemId(int offerItemId)
        {
            var po = await _offerDomainService.GetPoForByOfferItemId(offerItemId);
            return po;
        }
    }
}

