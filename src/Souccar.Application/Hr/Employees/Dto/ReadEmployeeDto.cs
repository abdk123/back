using System;
using Abp.Application.Services.Dto;

namespace Souccar.Hr.Employees.Dto
{
   public class ReadEmployeeDto : EntityDto<int>
    {
        public string fullName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public double salary { get; set; }
        public string email { get; set; }
    }
}

