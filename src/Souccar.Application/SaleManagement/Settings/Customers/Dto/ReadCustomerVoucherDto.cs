using System;
using Abp.Application.Services.Dto;
using Souccar.Core.Dto;

namespace Souccar.SaleManagement.Settings.Customers.Dto
{
   public class ReadCustomerVoucherDto : EntityDto<int>
    {
        public int voucherType { get; set; }
        public int currency { get; set; }
        public double amount { get; set; }
        public string voucherNumber { get; set; }
        public string voucherDate { get; set; }
        public int? customerId { get; set; }
        public DropdownDto Customer { get; set; }
    }
}

