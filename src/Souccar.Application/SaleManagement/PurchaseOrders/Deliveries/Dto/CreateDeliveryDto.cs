using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto
{
   public class CreateDeliveryDto : EntityDto<int>
    {
        public CreateDeliveryDto()
        {
            DeliveryItems = new List<CreateDeliveryItemDto>();
        }
        public double TransportCost { get; set; }
        public int TransportCostCurrency { get; set; }
        public string DriverName { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverPhoneNumber { get; set; }
        public int Status { get; set; } = 0;
        public double TransportedQuantity { get; set; }
        public int? CustomerId { get; set; }
        public IList<CreateDeliveryItemDto> DeliveryItems { get; set; }
    }
}

