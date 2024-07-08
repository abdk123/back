using System;
using Abp.Application.Services.Dto;

namespace Souccar.Hr.Employees.Dto
{
   public class CreateEmployeeDto : EntityDto<int>
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
        public string Email { get; set; }
    }
}

