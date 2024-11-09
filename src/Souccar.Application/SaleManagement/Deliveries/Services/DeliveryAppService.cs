using Abp.Events.Bus;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Souccar.SaleManagement.Stocks.Event;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events;
using Souccar.SaleManagement.CashFlows;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Events;
using Souccar.SaleManagement.Deliveries.Dto;

namespace Souccar.SaleManagement.Deliveries.Services
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
            foreach (var item in delivery.DeliveryItems)
            {
                var numberInLargeQuentity = item.OfferItem.AddedBySmallUnit ? 0 : item.DeliveredQuantity * -1;
                var numberInSmallQuentity = item.OfferItem.AddedBySmallUnit ? item.DeliveredQuantity * -1 : 0;
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
            var delivery = await GetEntityByIdAsync(input.Id);
            delivery.Status = (DeliveryStatus)input.Status;
            delivery.GrNumber = input.GrNumber;
            delivery.ApproveDate = DateTime.Now;

            await EventBus.Default.TriggerAsync(new CustomerCashFlowCreateEventData(
                    (int)delivery.TransportCostCurrency == 1 ? -1 * delivery.TransportCost : 0,
                    delivery.TransportCostCurrency == 0 ? -1 * delivery.TransportCost : 0,
                    TransactionName.DeliveryTransportCost,
                    delivery.CustomerId,
                    delivery.Id,
                    L(LocalizationResource.DeliveryTransportCost)
                    ));
            foreach (var deliveryItem in delivery.DeliveryItems)
            {
                var item = input.DeliveryItems.FirstOrDefault(x => x.Id == deliveryItem.Id);
                if (item is not null)
                {
                    deliveryItem.ApprovedQuantity = item.DeliveredQuantity;
                    deliveryItem.DeliveryItemStatus = DeliveryItemStatus.Approved;

                }
            }
            var updatedDelivery = await _deliveryDomainService.UpdateAsync(delivery);

            var deliveryWithDetail = await _deliveryDomainService.GetWithDetailsByIdAsync(input.Id);
            foreach (var deliveryItem in deliveryWithDetail.DeliveryItems)
            {
                var item = delivery.DeliveryItems.FirstOrDefault(x => x.Id == deliveryItem.Id);
                if (item is not null)
                {
                    var currency = (int)deliveryItem.OfferItem.Offer.Currency;
                    await EventBus.Default.TriggerAsync(new CustomerCashFlowCreateEventData(
                       currency == 1 ? -1 * (item.ApprovedQuantity * deliveryItem.OfferItem.UnitPrice) : 0,
                       currency == 0 ? -1 * (item.ApprovedQuantity * deliveryItem.OfferItem.UnitPrice) : 0,
                       TransactionName.DeliveryCost,
                       delivery.CustomerId,
                       delivery.Id,
                       L(LocalizationResource.DeliveryCostForMaterial, new[] { deliveryItem?.OfferItem?.Material?.Name, deliveryItem?.OfferItem?.Offer?.PorchaseOrderId })
                       ));
                }

            }
            return ObjectMapper.Map<DeliveryDto>(updatedDelivery);
        }

        public async Task<DeliveryDto> RejectDeliveryAsync(List<RejectedMaterialDto> list)
        {
            var deliveryItem = _deliveryDomainService.GetItemById(list[0].DeliveryItemId.Value);
            var delivery = deliveryItem.Delivery;
            await _deliveryDomainService.CreateRejectedMaterials(list);
            foreach (var input in list)
            {
                var gap = input.RejectedQuantity - deliveryItem.RejectedQuantity;//old quantity - new 

                if (deliveryItem.Id == input.DeliveryItemId)
                {
                    deliveryItem.RejectedQuantity = input.RejectedQuantity;

                    deliveryItem.RejectionDate = input.RejectionDate != null ? input.RejectionDate : DateTime.Now;
                    deliveryItem.DeliveryItemStatus = input.MaterialSource ? MaterialSource.Store: DeliveryItemStatus.RejectAndRecordAsDamaged;
                    delivery.Status = DeliveryStatus.PartialRejected;
                    if (delivery.DeliveryItems.All(x => x.DeliveredQuantity == x.RejectedQuantity))
                    {
                        delivery.Status = DeliveryStatus.Rejected;
                    }
                    await _deliveryDomainService.UpdateAsync(delivery);
                    if (!input.ReturnToSupplier) // «—Ã«⁄Â« ﬂ„Â ·ﬂ
                    {
                        var largeQuentity = deliveryItem.OfferItem.AddedBySmallUnit ? 0 : gap * -1;
                        var smallQuentity = deliveryItem.OfferItem.AddedBySmallUnit ? gap * -1 : 0;
                        var damagedLargeQuentity = deliveryItem.OfferItem.AddedBySmallUnit ? 0 : gap;
                        var damagedSmallQuentity = deliveryItem.OfferItem.AddedBySmallUnit ? gap : 0;
                        await EventBus.Default.TriggerAsync(new UpdateStockEventData(
                            deliveryItem.OfferItem.MaterialId,
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

