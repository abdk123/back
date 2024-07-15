using AutoMapper;
using Souccar.Core.Dto;
using Souccar.SaleManagement.Settings.Companies.Dto;

namespace Souccar.SaleManagement.Settings.Companies.Map
{
   public class ClearanceCompanyMapProfile : Profile
    {
        public ClearanceCompanyMapProfile()
        {
            CreateMap<ClearanceCompany, ClearanceCompanyDto>();
            CreateMap<ClearanceCompany, ReadClearanceCompanyDto>();
            CreateMap<CreateClearanceCompanyDto, ClearanceCompany>();
            CreateMap<ClearanceCompany, CreateClearanceCompanyDto>();
            CreateMap<UpdateClearanceCompanyDto, ClearanceCompany>();
            CreateMap<ClearanceCompany, UpdateClearanceCompanyDto>();
            CreateMap<ClearanceCompany, DropdownDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));
        }
    }
}

