using AutoMapper;
using Souccar.SaleManagement.Settings.Companies.Dto;

namespace Souccar.SaleManagement.Settings.Companies.Map
{
   public class CompanyMapProfile : Profile
    {
        public CompanyMapProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<Company, ReadCompanyDto>();
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<Company, CreateCompanyDto>();
            CreateMap<UpdateCompanyDto, Company>();
            CreateMap<Company, UpdateCompanyDto>();
        }
    }
}

