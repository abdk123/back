using AutoMapper;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Dto;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Map
{
    public class CustomerCashFlowMapProfile : Profile
    {
        public CustomerCashFlowMapProfile()
        {
            CreateMap<CustomerCashFlow, CustomerCashFlowDto>();
            CreateMap<CustomerCashFlowDto, CustomerCashFlow>();
        }
    }
}
