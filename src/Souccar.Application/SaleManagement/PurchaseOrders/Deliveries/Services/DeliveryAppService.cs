using Abp.Events.Bus;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Souccar.SaleManagement.Stocks.Event;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public class DeliveryAppService :
        AsyncSouccarAppService<Delivery, DeliveryDto, int, FullPagedRequestDto, CreateDeliveryDto, UpdateDeliveryDto>, IDeliveryAppService
    {
        private readonly IDeliveryDomainService _deliveryDomainService;
        public DeliveryAppService(IDeliveryDomainService deliveryDomainService) : base(deliveryDomainService)
        {
            _deliveryDomainService = deliveryDomainService;
        }

        public async Task<DeliveryDto> GetWithDetailsByIdAsync(int deliveryId)
        {
            var delivery = await _deliveryDomainService.GetWithDetailsByIdAsync(deliveryId);
            return ObjectMapper.Map<DeliveryDto>(delivery);
        }

        public IList<DeliveryDto> GetAllByCustomerId(int customerId)
        {
            var receiving = _deliveryDomainService.GetAllByCustomerId(customerId).ToList();
            return ObjectMapper.Map<List<DeliveryDto>>(receiving);
        }

        public IList<DeliveryDto> GetForSaleInvoice(int customerId)
        {
            var receiving = _deliveryDomainService.GetForSaleInvoice(customerId).ToList();
            return ObjectMapper.Map<List<DeliveryDto>>(receiving);
        }

        public async Task<List<DeliveryDto>> GetAllDeliverdAsync()
        {
            var deliveries = await _deliveryDomainService.GetAllDeliverdAsync();
            var dto = ObjectMapper.Map<List<DeliveryDto>>(deliveries);
            return dto;
        }

        public async Task<DeliveryItemDto> ChangeItemStatusAsync(ChangeItemStatusInputDto input)
        {
            var updatedDeliveryItem = await _deliveryDomainService.ChangeItemStatusAsync(input.Id, input.Status);
            return ObjectMapper.Map<DeliveryItemDto>(updatedDeliveryItem);
        }

        protected override IQueryable<Delivery> CreateFilteredQuery(FullPagedRequestDto input)
        {
            var data = _deliveryDomainService.GetAllWithDetail();
            return data;
        }

        public async override Task<DeliveryDto> CreateAsync(CreateDeliveryDto input)
        {
            var createdDelivery = await base.CreateAsync(input);
            var delivery = await _deliveryDomainService.GetWithDetailsByIdAsync(createdDelivery.Id);
            foreach(var item in delivery.DeliveryItems)
            {
                var numberInLargeQuentity = item.OfferItem.AddedBySmallUnit ? 0 : (item.DeliveredQuantity * -1);
                var numberInSmallQuentity = item.OfferItem.AddedBySmallUnit ? (item.DeliveredQuantity * -1) : 0;
                await EventBus.Default.TriggerAsync(new UpdateStockEventData(
                    item.OfferItem.MaterialId,
                    numberInLargeQuentity, numberInSmallQuentity));

                //999 Õ—ﬂ… ⁄·Ï —’Ìœ «·“»Ê‰
            }
            //999 ﬂ·›… «·‰ﬁ· ⁄·Ï «·“»Ê‰
            return createdDelivery;
        }

        public async override Task<DeliveryDto> UpdateAsync(UpdateDeliveryDto input)
        {
            var delivery =  await GetEntityByIdAsync(input.Id);
            delivery.Status = (DeliveryStatus)input.Status;
            delivery.GrNumber = input.GrNumber;
            delivery.ApproveDate = DateTime.Now;
            foreach (var deliveryItem in delivery.DeliveryItems)
            {
                var item = input.DeliveryItems.FirstOrDefault(x => x.Id == deliveryItem.Id);
                if(item is not null)
                {
                    deliveryItem.ApprovedQuantity = item.DeliveredQuantity;
                    deliveryItem.DeliveryItemStatus = DeliveryItemStatus.Approved;
                }
            }
            var updatedDelivery = await _deliveryDomainService.UpdateAsync(delivery);
            
            return ObjectMapper.Map<DeliveryDto>(updatedDelivery);
        }

        public async Task<DeliveryDto> RejectDeliveryAsync(RejectDeliveryDto input)
        {
            var delivery = await GetEntityByIdAsync(input.DeliveryId);
            foreach (var item in delivery.DeliveryItems)
            {
                var gap = input.RejectedQuantity - item.RejectedQuantity;//old quantity - new 

                if (item.Id == input.DeliveryItemId)
                {
                    item.RejectedQuantity = input.RejectedQuantity;

                    item.RejectionDate = input.RejectionDate != null ? input.RejectionDate : DateTime.Now;
                    item.DeliveryItemStatus = input.ReturnToSupplier ? DeliveryItemStatus.RejectAndReturnToSupplier : DeliveryItemStatus.RejectAndRecordAsDamaged;
                    delivery.Status = DeliveryStatus.PartialRejected;
                    if (delivery.DeliveryItems.All(x => x.DeliveredQuantity == x.RejectedQuantity))
                    {
                        delivery.Status = DeliveryStatus.Rejected;
                    }
                    await _deliveryDomainService.UpdateAsync(delivery);
                    if (!input.ReturnToSupplier) // «—Ã«⁄Â« ﬂ„Â ·ﬂ
                    {
                        var largeQuentity = item.OfferItem.AddedBySmallUnit ? 0 : (gap * -1);
                        var smallQuentity = item.OfferItem.AddedBySmallUnit ? (gap * -1) : 0;
                        var damagedLargeQuentity = item.OfferItem.AddedBySmallUnit ? 0 : (gap);
                        var damagedSmallQuentity = item.OfferItem.AddedBySmallUnit ? (gap) : 0;
                        await EventBus.Default.TriggerAsync(new UpdateStockEventData(
                            item.OfferItem.MaterialId,
                            largeQuentity, smallQuentity, damagedLargeQuentity, damagedSmallQuentity));
                    }
                    break;
                }
                
            }
            return ObjectMapper.Map<DeliveryDto>(delivery);
        }

        public IList<DeliveryDto> GetByOfferItems(int[] offerItemsIds)
        {
            var deliveryItems = _deliveryDomainService.GetByOfferItems(offerItemsIds);
            return ObjectMapper.Map<List<DeliveryDto>>(deliveryItems);
        }
    }
}

