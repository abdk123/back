using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Companies;
using Souccar.SaleManagement.Settings.Companies.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Receives.Dto
{
    public class ReceivingDto : EntityDto<int>
    {
        public ReceivingDto()
        {
            ReceivingItems = new List<ReceivingItemDto>();
        }
        public double TransportCost { get; set; }
        public int TransportCostCurrency { get; set; }
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public int? TransportCompanyId { get; set; }
        public TransportCompanyDto TransportCompany { get; set; }
        public double ClearanceCost { get; set; }
        public int ClearanceCostCurrency { get; set; }
        public int? ClearanceCompanyId { get; set; }
        public ClearanceCompanyDto ClearanceCompany { get; set; }
        public int? InvoiceId { get; set; }
        public int? SupplierId { get; set; }
        public double TotalReceivedQuantity { get; set; }
        public IList<ReceivingItemDto> ReceivingItems { get; set; }
        public string CreationTime { get; set; }
        public string CreatorUser { get; set; }
    }
}

