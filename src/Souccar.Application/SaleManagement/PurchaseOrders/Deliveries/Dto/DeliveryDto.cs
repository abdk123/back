using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto
{
    public class DeliveryDto : EntityDto<int>
    {
        public string CreationTime { get; set; }
        public double TransportCost { get; set; }
        public int TransportCostCurrency { get; set; }
        public string DriverName { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverPhoneNumber { get; set; }
        public int Status { get; set; }
        public double TransportedQuantity { get; set; }
        public int? CustomerId { get; set; }
        public IList<DeliveryItemDto> DeliveryItems { get; set; }
    }
}

