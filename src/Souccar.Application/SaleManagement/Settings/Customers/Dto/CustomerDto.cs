using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Customers.Dto
{
   public class CustomerDto : EntityDto<int>
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double BalanceInDollar { get; set; }
        public double BalanceInDinar { get; set; }
        public double InitialBalance { get; set; }
        public int Type { get; set; }
    }
}

