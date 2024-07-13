using AutoMapper;
using Souccar.SaleManagement.Settings.Customers.Dto;

namespace Souccar.SaleManagement.Settings.Customers.Map
{
   public class CustomerVoucherMapProfile : Profile
    {
        public CustomerVoucherMapProfile()
        {
            CreateMap<CustomerVoucher, CustomerVoucherDto>();
            CreateMap<CustomerVoucher, ReadCustomerVoucherDto>();
            CreateMap<CreateCustomerVoucherDto, CustomerVoucher>();
            CreateMap<CustomerVoucher, CreateCustomerVoucherDto>();
            CreateMap<UpdateCustomerVoucherDto, CustomerVoucher>();
            CreateMap<CustomerVoucher, UpdateCustomerVoucherDto>();
        }
    }
}

