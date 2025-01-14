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
using Souccar.SaleManagement.Offers.Dto;
using Souccar.SaleManagement.Stocks;
using Souccar.SaleManagement.Deliveries;
using Souccar.SaleManagement.PurchaseInvoices.Receives.Services;
using Souccar.SaleManagement.PurchaseInvoices;
using Souccar.SaleManagement.PurchaseInvoices.Receives;

namespace Souccar.SaleManagement.Offers.Services
{
    public class OfferAppService :
        AsyncSouccarAppService<Offer, OfferDto, int, FullPagedRequestDto, CreateOfferDto, UpdateOfferDto>, IOfferAppService
    {
        private readonly IOfferDomainService _offerDomainService;
        private readonly IReceivingDomainService _receivingDomainService;

        public OfferAppService(IOfferDomainService offerDomainService, IReceivingDomainService receivingDomainService)
        : base(offerDomainService)
        {
            _offerDomainService = offerDomainService;
            _receivingDomainService = receivingDomainService;
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
            await _offerDomainService.UpdateAsync(offer);
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

        public IList<OfferItemForDeliveryDto> GetForDelivery(int customerId)
        {
            var list = new List<OfferItemForDeliveryDto>();
            var offers = _offerDomainService.GetForDelivery(customerId);
            foreach (var item in offers)
            {
                list.Add(new OfferItemForDeliveryDto()
                {
                    MaterialName = item.Material?.Name,
                    OfferItemId = item.Id,
                    NumberInSmallUnit = item.NumberInSmallUnit,
                    Quantity = item.Quantity,
                    DeliveredQuantity = item.DeliveredQuantity,
                    Unit = item.Unit?.Name,
                    SmallUnit = item.Size?.Name,
                    PoNumber = item.Offer.PorchaseOrderId,
                    TotalPrice = item.TotalPrice,
                    AddedBySmallUnit = item.AddedBySmallUnit,
                    OfferId = item.OfferId
                });
            }

            return list;
        }

        public override async Task<OfferDto> UpdateAsync(UpdateOfferDto input)
        {
            var oldOffer = await _offerDomainService.GetAsync(input.Id);
            ObjectMapper.Map(input, oldOffer);
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
            //var currentUser = await GetCurrentUserAsync();
            //await EventBus.Default.TriggerAsync(new CreateOrderLogEventData(new OrderLog()
            //{
            //    ActionId = dto.Id,
            //    RelatedId = dto.Id,
            //    Type = OrderLogType.CreateOffer,
            //    FullName = currentUser?.FullName,
            //    Attributes = new List<OrderLogAttribute>()
            //    {
            //        new OrderLogAttribute("OfferId",dto.Id.ToString()),
            //        new OrderLogAttribute("TotalQuantity",dto.TotalQuantity.ToString()),
            //        new OrderLogAttribute("TotalPrice",dto.TotalPrice.ToString()),
            //    }
            //}));
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

        public async Task<OfferDto> ConvertToPurchaseInvoice(ConvertToPurchaseInvoiceDto input)
        {
            var offer = await _offerDomainService.GetAsync(input.OfferId);
            if (offer is null)
                throw new UserFriendlyException("Offer not found");

            if (offer.Status != OfferStatus.Approved)
            {
                throw new UserFriendlyException(ValidationMessage.TheOfferMustBeApprovedFirst);
            }

            await EventBus.Default.TriggerAsync(new CreateInvoiceEventData(input.SupplierId, input.OfferId, input.OfferItemsIds, offer.Currency));
            //await EventBus.Default.TriggerAsync(new ChangeOfferStatusEventData(input.OfferId,OfferStatus.TransformToPurchaseInvoice));

            //var currentUser = await GetCurrentUserAsync();
            //await EventBus.Default.TriggerAsync(new CreateOrderLogEventData(new OrderLog()
            //{
            //    ActionId = offerItem.Id,
            //    RelatedId = offerItem.OfferId.Value,
            //    Type = OrderLogType.TransformToPurchaseInvoice,
            //    FullName = currentUser?.FullName,
            //    Attributes = new List<OrderLogAttribute>()
            //}));
            return ObjectMapper.Map<OfferDto>(offer);
        }

        public IList<OfferDto> GetByCustomerId(int customerId)
        {
            var offers = _offerDomainService.Get(x => x.CustomerId == customerId);
            return ObjectMapper.Map<List<OfferDto>>(offers);
        }

        public IList<OfferDto> GetApproved()
        {
            var includes = new string[]
            {
                $"{nameof(OfferDto.Customer)}",
                $"{nameof(Offer.OfferItems)}.{nameof(OfferItem.Material)}.{nameof(OfferItem.Material.Unit)}",
                $"{nameof(Offer.OfferItems)}.{nameof(OfferItem.Material)}.{nameof(OfferItem.Material.Stocks)}.{nameof(Stock.Size)}",
            };
            var offers = _offerDomainService
                .Get(filter: x => x.Status == OfferStatus.Approved,
                include: includes)
                .ToList();
            return ObjectMapper.Map<List<OfferDto>>(offers);
        }

        public ProfitDto GetProfit(int offerId)
        {
            var includes = new string[]
            {
                $"{nameof(Offer.OfferItems)}.{nameof(OfferItem.DeliveryItems)}",
                $"{nameof(Offer.OfferItems)}.{nameof(OfferItem.PurchaseInvoiceItems)}.{nameof(PurchaseInvoiceItem.ReceivingItems)}.{nameof(ReceivingItem.Receiving)}",
                $"{nameof(Offer.OfferItems)}.{nameof(OfferItem.Material)}.{nameof(OfferItem.Material.Stocks)}",
            };
            var offer = _offerDomainService
                .Get(filter: x => x.Status == OfferStatus.Approved,
                include: includes)
                .FirstOrDefault();

            var deliveryItems = offer.OfferItems
                .SelectMany(x => x.DeliveryItems)
                .Where(x => x.DeliveryItemStatus == DeliveryItemStatus.Approved);

            var profit = new ProfitDto(offer.Id);
            foreach (var offerItem in offer.OfferItems)
            {
                var approvedQuantity = offerItem.DeliveryItems
                    .Where(x => x.OfferItemId == offerItem.Id && x.DeliveryItemStatus == DeliveryItemStatus.Approved)
                    .Sum(x => (x.ApprovedQuantity));

                var sellingPrice = GetSellingPrice(offerItem, approvedQuantity);

                //Transport cost & Clearance cost
                var receivings = offerItem.PurchaseInvoiceItems.Any() ?
                    offerItem.PurchaseInvoiceItems
                    .SelectMany(x => x.ReceivingItems).Select(x => x.Receiving)
                    .DistinctBy(x => x.Id) : new List<Receiving>();

                var transportCost = receivings.Any() ? receivings.Sum(x => x.TransportCost) : 0.0;
                var clearanceCost = receivings.Any() ? receivings.Sum(x => x.ClearanceCost) : 0.0;

                var price = offerItem.PurchaseInvoiceItems.Any()
                    ? offerItem.PurchaseInvoiceItems.Last().TotalMaterilPrice
                    : offerItem.Material.Stocks.Last().Price;

                var purchasePrice = approvedQuantity * price;
                profit.ProfitItems.Add(
                    new ProfitItemDto(
                        offerItem.Id, 
                        offerItem.Material.Name, 
                        approvedQuantity, 
                        sellingPrice, 
                        purchasePrice,
                        transportCost,
                        clearanceCost
                        ));
            }


            return profit;
        }

        private double GetSellingPrice(OfferItem offerItem, double approvedQuantity)
        {
            if (!offerItem.AddedBySmallUnit)
                return approvedQuantity * offerItem.UnitPrice;

            return (approvedQuantity / offerItem.TransitionValue) * offerItem.UnitPrice;
        }

        private double GetPurchasePrice(OfferItem offerItem, double approvedQuantity)
        {
            var price = offerItem.PurchaseInvoiceItems.Any()
                    ? offerItem.PurchaseInvoiceItems.Last().TotalMaterilPrice
                    : offerItem.Material.Stocks.Last().Price;

            if (!offerItem.AddedBySmallUnit)
                return approvedQuantity * price;

            return (approvedQuantity / offerItem.TransitionValue) * price;
        }

        public OfferDto GetByPoNumber(string poNumber)
        {
            var offer = _offerDomainService.Get(filter: x=>x.PorchaseOrderId == poNumber);
            if (offer.Any())
            {
                return ObjectMapper.Map<OfferDto>(offer.First());
            }
            return new OfferDto();
        }
    }
}

