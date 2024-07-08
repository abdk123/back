using AutoMapper;
using Souccar.SaleManagement.Settings.Companies.Dto;

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
        }
    }
}

