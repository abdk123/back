using AutoMapper;
using Souccar.SaleManagement.Settings.Companies.Dto;

namespace Souccar.SaleManagement.Settings.Companies.Map
{
   public class TransportCompanyVoucherMapProfile : Profile
    {
        public TransportCompanyVoucherMapProfile()
        {
            CreateMap<TransportCompanyVoucher, TransportCompanyVoucherDto>();
            CreateMap<TransportCompanyVoucher, ReadTransportCompanyVoucherDto>();
            CreateMap<CreateTransportCompanyVoucherDto, TransportCompanyVoucher>();
            CreateMap<TransportCompanyVoucher, CreateTransportCompanyVoucherDto>();
            CreateMap<UpdateTransportCompanyVoucherDto, TransportCompanyVoucher>();
            CreateMap<TransportCompanyVoucher, UpdateTransportCompanyVoucherDto>();
        }
    }
}

