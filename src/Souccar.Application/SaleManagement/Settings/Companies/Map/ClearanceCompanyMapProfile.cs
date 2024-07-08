using AutoMapper;
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
        }
    }
}

