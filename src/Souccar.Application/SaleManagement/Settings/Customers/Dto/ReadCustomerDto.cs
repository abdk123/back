using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Customers.Dto
{
   public class ReadCustomerDto : EntityDto<int>
    {
        public string fullName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public double balanceInDollar { get; set; }
        public double balanceInDinar { get; set; }
        public double initialBalance { get; set; }
        public int type { get; set; }
    }
}

