using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Companies.Dto
{
   public class ReadCompanyDto : EntityDto<int>
    {
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public double balanceInDollar { get; set; }
        public double balanceInDinar { get; set; }
    }
}

