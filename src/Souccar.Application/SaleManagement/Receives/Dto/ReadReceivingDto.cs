using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Receives.Dto
{
    public class ReadReceivingDto : EntityDto<int>
    {
        public double transportCost { get; set; }
        public int transportCostCurrency { get; set; }
        public string driverName { get; set; }
        public string driverPhoneNumber { get; set; }
        public int? transportCompanyId { get; set; }
        public double clearanceCost { get; set; }
        public int clearanceCostCurrency { get; set; }
        public int? clearanceCompanyId { get; set; }
        public int? invoiceId { get; set; }
        public int? supplierId { get; set; }
    }
}

