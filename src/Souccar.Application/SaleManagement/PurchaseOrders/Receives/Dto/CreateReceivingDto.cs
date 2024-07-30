using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;


namespace Souccar.SaleManagement.PurchaseOrders.Receives.Dto
{
   public class CreateReceivingDto
    {
        public CreateReceivingDto()
        {
            ReceivingItems = new List<CreateReceivingItemDto>();
        }
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
        public string CreationTime { get; set; }
        public IList<CreateReceivingItemDto> ReceivingItems { get; set; }
    }
}

