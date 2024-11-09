using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Companies.Dto;

namespace Souccar.SaleManagement.Receives.Dto
{
    public class CompleteReceivingDto: EntityDto
    {
        public double TransportCost { get; set; }
        public int TransportCostCurrency { get; set; }
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public int? TransportCompanyId { get; set; }
        public double ClearanceCost { get; set; }
        public int ClearanceCostCurrency { get; set; }
        public int? ClearanceCompanyId { get; set; }
    }
}
