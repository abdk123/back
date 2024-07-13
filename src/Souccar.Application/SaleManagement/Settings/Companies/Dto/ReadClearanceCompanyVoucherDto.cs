using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Companies.Dto
{
   public class ReadClearanceCompanyVoucherDto : EntityDto<int>
    {
        public int voucherType { get; set; }
        public int currency { get; set; }
        public double amount { get; set; }
        public string voucherNumber { get; set; }
        public DateTime? voucherDate { get; set; }
        public int? clearanceCompanyId { get; set; }
    }
}

