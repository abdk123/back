using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Companies.Dto
{
   public class CreateClearanceCompanyDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double BalanceInDollar { get; set; }
        public double BalanceInDinar { get; set; }
    }
}

