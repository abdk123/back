using AutoMapper;
using Souccar.Core.Dto;
using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.SaleManagement.Settings.Customers;

namespace Souccar.SaleManagement.Settings.Companies.Map
{
   public class TransportCompanyMapProfile : Profile
    {
        public TransportCompanyMapProfile()
        {
            CreateMap<TransportCompany, TransportCompanyDto>();
            CreateMap<TransportCompany, ReadTransportCompanyDto>();
            CreateMap<CreateTransportCompanyDto, TransportCompany>();
            CreateMap<TransportCompany, CreateTransportCompanyDto>();
            CreateMap<UpdateTransportCompanyDto, TransportCompany>();
            CreateMap<TransportCompany, UpdateTransportCompanyDto>();
            CreateMap<TransportCompany, DropdownDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));
        }
    }
}

