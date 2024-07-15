using System;
using Abp.Application.Services.Dto;
using Souccar.Core.Dto;

namespace Souccar.SaleManagement.Settings.Companies.Dto
{
    public class TransportCompanyVoucherDto : EntityDto<int>
    {
        public int VoucherType { get; set; }
        public int Currency { get; set; }
        public double Amount { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime? VoucherDate { get; set; }
        public int? TransportCompanyId { get; set; }
        public DropdownDto TransportCompany { get; set; }
    }
}

