using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Customers.Dto
{
   public class UpdateCustomerVoucherDto : EntityDto<int>
    {
        public int VoucherType { get; set; }
        public int Currency { get; set; }
        public double Amount { get; set; }
        public string VoucherNumber { get; set; }
        public string VoucherDate { get; set; }
        public int? CustomerId { get; set; }
    }
}

