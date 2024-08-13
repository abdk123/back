using Abp.Application.Services.Dto;
using Abp.Events.Bus;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.Logs.Events;
using Souccar.SaleManagement.Logs;
using Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto;
using Souccar.SaleManagement.PurchaseOrders.Offers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Souccar.SaleManagement.PurchaseOrders.Invoises;
using System;
using Abp.Domain.Entities;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public class DeliveryAppService :
        AsyncSouccarAppService<Delivery, DeliveryDto, int, FullPagedRequestDto, CreateDeliveryDto, UpdateDeliveryDto>, IDeliveryAppService
    {
        private readonly IDeliveryDomainService _deliveryDomainService;
        private readonly IInvoiceDomainService _invoiceDomainService;
        public DeliveryAppService(IDeliveryDomainService deliveryDomainService, IInvoiceDomainService invoiceDomainService) : base(deliveryDomainService)
        {
            _deliveryDomainService = deliveryDomainService;
            _invoiceDomainService = invoiceDomainService;
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

        public async Task<List<DeliveryDto>> GetAllDeliverdAsync()
        {
            var deliveries = await _deliveryDomainService.GetAllDeliverdAsync();
            return ObjectMapper.Map<List<DeliveryDto>>(deliveries);
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
                    deliveryItem.TransportedQuantity = item.DeliveredQuantity;
                    deliveryItem.DeliveryItemStatus = DeliveryItemStatus.Approved;
                }
            }
            var updatedDelivery = await _deliveryDomainService.UpdateAsync(delivery);
            var invoiceItemsIds = updatedDelivery.DeliveryItems.Select(x => x.InvoiceItemId.Value).ToArray();
            var offersIds = _invoiceDomainService.GetOffersIds(invoiceItemsIds);
            var currentUser = await GetCurrentUserAsync();
            foreach (var offerId in offersIds)
            {
                await EventBus.Default.TriggerAsync(new CreateOrderLogEventData(new OrderLog()
                {
                    ActionId = updatedDelivery.Id,
                    RelatedId = offerId,
                    Type = OrderLogType.UpdateDelivery,
                    FullName = currentUser?.FullName
                }));
            }
            
            return ObjectMapper.Map<DeliveryDto>(updatedDelivery);
        }
    }
}

