using AutoMapper;
using Souccar.SaleManagement.Settings.Companies.Dto;

namespace Souccar.SaleManagement.Settings.Companies.Map
{
   public class ClearanceCompanyVoucherMapProfile : Profile
    {
        public ClearanceCompanyVoucherMapProfile()
        {
            CreateMap<ClearanceCompanyVoucher, ClearanceCompanyVoucherDto>();
            CreateMap<ClearanceCompanyVoucherDto, ClearanceCompanyVoucher>();
            CreateMap<ClearanceCompanyVoucher, ReadClearanceCompanyVoucherDto>();
            CreateMap<CreateClearanceCompanyVoucherDto, ClearanceCompanyVoucher>();
            CreateMap<ClearanceCompanyVoucher, CreateClearanceCompanyVoucherDto>();
            CreateMap<UpdateClearanceCompanyVoucherDto, ClearanceCompanyVoucher>();
            CreateMap<ClearanceCompanyVoucher, UpdateClearanceCompanyVoucherDto>();
        }
    }
}

