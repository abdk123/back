using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Customers.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto
{
    public class DeliveryDto : EntityDto<int>
    {
        public DateTime CreationTime { get; set; }
        public DateTime ApproveDate { get; set; }
        public double TransportCost { get; set; }
        public int TransportCostCurrency { get; set; }
        public string DriverName { get; set; }
        public string GrNumber { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverPhoneNumber { get; set; }
        public int Status { get; set; }
        public double TotalPrice => DeliveryItems.Any() ? DeliveryItems.Sum(x => x.ToralPrice) : 0;
        public double TotalTransportedQuantity => DeliveryItems.Any() ? DeliveryItems.Sum(x => x.TransportedQuantity) : 0;
        public int? CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public IList<DeliveryItemDto> DeliveryItems { get; set; }
    }
}

