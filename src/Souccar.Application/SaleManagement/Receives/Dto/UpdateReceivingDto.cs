using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Receives.Dto
{
    public class UpdateReceivingDto : EntityDto<int>
    {
        public string ReceivingDate { get; set; }
        public string Note { get; set; }
        public double TransportCost { get; set; }
        public int TransportCostCurrency { get; set; }
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public int? TransportCompanyId { get; set; }
        public double ClearanceCost { get; set; }
        public int ClearanceCostCurrency { get; set; }
        public int? ClearanceCompanyId { get; set; }
        public int? InvoiceId { get; set; }
        public int? SupplierId { get; set; }
        public IList<UpdateReceivingItemDto> ReceivingItems { get; set; }
    }
}

