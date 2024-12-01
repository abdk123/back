using Abp.Events.Bus;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Souccar.SaleManagement.CashFlows;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Events;
using Souccar.SaleManagement.Deliveries.Dto;
using System.Text;
using Souccar.SaleManagement.StockHistories.Event;
using Souccar.SaleManagement.Stocks;

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
            this.LocalizationSourceName = "Souccar";
            foreach (var item in delivery.DeliveryItems)
            {
                //var numberInLargeQuentity = item.OfferItem.AddedBySmallUnit ? 0 : item.DeliveredQuantity * -1;
                //var numberInSmallQuentity = item.OfferItem.AddedBySmallUnit ? item.DeliveredQuantity * -1 : 0;
                //await EventBus.Default.TriggerAsync(new UpdateStockEventData(
                //    item.OfferItem.MaterialId,
                //    numberInLargeQuentity, numberInSmallQuentity));

                await EventBus.Default.TriggerAsync(new StockHistoryEventUpdateData(
                    StockType.Exit,
                    StockReason.Delivery,
                    L(LocalizationResource.SendDeliveryForCustomer, delivery.Customer?.FullName),
                    (-1 * item.DeliveredQuantity),
                    item.Id,
                    item.OfferItem.UnitId,
                    item.OfferItem.SizeId,
                    item.OfferItem.MaterialId,
                    item.OfferItem.UnitPrice
                    ));

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
            if(delivery.Status == DeliveryStatus.Approved)
            {
                delivery.ApproveDate = DateTime.Now;
            }

            
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
            await EventBus.Default.TriggerAsync(new CustomerCashFlowCreateEventData(
                    (int)delivery.TransportCostCurrency == 1 ? -1 * delivery.TransportCost : 0,
                    delivery.TransportCostCurrency == 0 ? -1 * delivery.TransportCost : 0,
                    TransactionName.DeliveryTransportCost,
                    delivery.CustomerId,
                    delivery.Id,
                    GetTransportTransactionDetail(deliveryWithDetail)
                    ));
            //foreach (var deliveryItem in deliveryWithDetail.DeliveryItems)
            //{
            //    var item = delivery.DeliveryItems.FirstOrDefault(x => x.Id == deliveryItem.Id);
            //    if (item is not null)
            //    {
            //        var currency = (int)deliveryItem.OfferItem.Offer.Currency;
            //        await EventBus.Default.TriggerAsync(new CustomerCashFlowCreateEventData(
            //           currency == 1 ? -1 * (item.ApprovedQuantity * deliveryItem.OfferItem.UnitPrice) : 0,
            //           currency == 0 ? -1 * (item.ApprovedQuantity * deliveryItem.OfferItem.UnitPrice) : 0,
            //           TransactionName.DeliveryCost,
            //           delivery.CustomerId,
            //           delivery.Id,
            //           L(LocalizationResource.DeliveryCostForMaterial, new[] { deliveryItem?.OfferItem?.Material?.Name, deliveryItem?.OfferItem?.Offer?.PorchaseOrderId })
            //           ));
            //    }
            //}
            return ObjectMapper.Map<DeliveryDto>(updatedDelivery);
        }

        public async Task<DeliveryDto> RejectDeliveryAsync(RejectDeliveryDto input)
        {
            var delivery = await _deliveryDomainService.GetWithDetailsByIdAsync(input.DeliveryId);
            var deliveryItem = delivery.DeliveryItems.First(x => x.Id == input.DeliveryItemId);
            var qty = input.RejectedMaterials.Sum(x => x.RejectedQuantity);
            var oldRejectedQuantity = deliveryItem.RejectedQuantity;
            var offerQuantity = deliveryItem.OfferItem.Quantity;
            qty =(qty + oldRejectedQuantity) > offerQuantity ? offerQuantity : (qty + oldRejectedQuantity);
            deliveryItem.RejectedQuantity = qty;



            deliveryItem.DeliveryItemStatus = DeliveryItemStatus.PartialRejected;
            if (qty == offerQuantity)
                deliveryItem.DeliveryItemStatus = DeliveryItemStatus.Rejected;

            delivery.Status = DeliveryStatus.PartialRejected;
            if (delivery.DeliveryItems.All(x => x.DeliveredQuantity == x.RejectedQuantity))
            {
                delivery.Status = DeliveryStatus.Rejected;
            }
            await _deliveryDomainService.UpdateItemAsync(deliveryItem);
            await _deliveryDomainService.UpdateAsync(delivery);
            var rejectedMaterials = ObjectMapper.Map<List<RejectedMaterial>>(input.RejectedMaterials);
            await _deliveryDomainService.CreateRejectedMaterials(rejectedMaterials);
            return ObjectMapper.Map<DeliveryDto>(delivery);
        }

        public IList<DeliveryDto> GetByOfferItems(int[] offerItemsIds)
        {
            var deliveryItems = _deliveryDomainService.GetByOfferItems(offerItemsIds);
            return ObjectMapper.Map<List<DeliveryDto>>(deliveryItems);
        }

        private string GetTransportTransactionDetail(Delivery delivery)
        {
            var builder = new StringBuilder();
            builder.Append(L(LocalizationResource.DeliveryTransportCost));
            builder.Append(" | ");
            builder.Append(L(LocalizationResource.Materials));
            builder.Append(":");
            var materialsNames = "";
            foreach (var item in delivery.DeliveryItems)
            {
                materialsNames += item.OfferItem.Material.Name + "-";
            }
            materialsNames = materialsNames.Substring(0, materialsNames.Length - 1);
            builder.Append($"({materialsNames})");
            
            builder.Append(" | ");
            builder.Append(L(LocalizationResource.DriverName));
            builder.Append(":");
            builder.Append(delivery.DriverName);
            return builder.ToString();
        }
    }
}

