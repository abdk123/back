using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Deliveries.Dto
{
    public class UpdateDeliveryDto : EntityDto<int>
    {
        public UpdateDeliveryDto()
        {
            DeliveryItems = new List<UpdateDeliveryItemDto>();
        }
        public double TransportCost { get; set; }
        public int TransportCostCurrency { get; set; }
        public string DriverName { get; set; }
        public string VehicleNumber { get; set; }
        public string GrNumber { get; set; }
        public string DriverPhoneNumber { get; set; }
        public int Status { get; set; }
        public double DeliveredQuantity { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? ApproveDate { get; set; }
        public IList<UpdateDeliveryItemDto> DeliveryItems { get; set; }

    }
}

