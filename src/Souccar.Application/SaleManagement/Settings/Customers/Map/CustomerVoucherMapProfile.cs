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
            CreateMap<CustomerVoucherDto, CustomerVoucher>();
            CreateMap<CreateCustomerVoucherDto, CustomerVoucher>()
                .ForMember(x=>x.VoucherDate, opt=>opt.Ignore());
            CreateMap<CustomerVoucher, CreateCustomerVoucherDto>();
            CreateMap<UpdateCustomerVoucherDto, CustomerVoucher>()
                 .ForMember(x => x.VoucherDate, opt => opt.Ignore());
            CreateMap<CustomerVoucher, UpdateCustomerVoucherDto>();
        }
    }
}

