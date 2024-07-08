using AutoMapper;
using Souccar.Hr.Employees.Dto;
using Souccar.Hr.Employees;

namespace Souccar.Hr.Employees.Map
{
    public class EmployeeMapProfile : Profile
    {
        public EmployeeMapProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, ReadEmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<Employee, CreateEmployeeDto>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, UpdateEmployeeDto>();
        }
    }
}

