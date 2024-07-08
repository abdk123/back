using AutoMapper;
using Souccar.SaleManagement.Settings.Customers.Dto;

namespace Souccar.SaleManagement.Settings.Customers.Map
{
   public class CustomerMapProfile : Profile
    {
        public CustomerMapProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Customer, ReadCustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, CreateCustomerDto>();
            CreateMap<UpdateCustomerDto, Customer>();
            CreateMap<Customer, UpdateCustomerDto>();
        }
    }
}

