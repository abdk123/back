using AutoMapper;
using Souccar.SaleManagement.CachFlows.TransportCompanyCachFlows;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Map
{
    public class TransportCompanyCashFlowMapProfile : Profile
    {
        public TransportCompanyCashFlowMapProfile()
        {
            CreateMap<TransportCompanyCashFlow, TransportCompanyCashFlowDto>();
            CreateMap<TransportCompanyCashFlowDto, TransportCompanyCashFlow>();
        }
    }
}
