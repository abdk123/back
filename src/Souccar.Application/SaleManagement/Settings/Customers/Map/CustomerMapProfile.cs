using AutoMapper;
using Souccar.Core.Dto;
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
            CreateMap<Customer, DropdownDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName));
            CreateMap<Customer, CustomerForDropdownDto>();
        }
    }
}

