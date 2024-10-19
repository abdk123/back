using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Deliveries.Dto
{
    public class ReadDeliveryDto : EntityDto<int>
    {
        public double transportCost { get; set; }
        public int transportCostCurrency { get; set; }
        public string driverName { get; set; }
        public string vehicleNumber { get; set; }
        public string driverPhoneNumber { get; set; }
        public int status { get; set; }
        public double transportedQuantity { get; set; }
        public int? customerId { get; set; }
    }
}

