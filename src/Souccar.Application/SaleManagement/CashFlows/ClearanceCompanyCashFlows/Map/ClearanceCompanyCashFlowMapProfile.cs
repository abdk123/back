using AutoMapper;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Dto;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Map
{
    public class ClearanceCompanyCashFlowMapProfile : Profile
    {
        public ClearanceCompanyCashFlowMapProfile()
        {
            CreateMap<ClearanceCompanyCashFlow, ClearanceCompanyCashFlowDto>();
            CreateMap<ClearanceCompanyCashFlowDto, ClearanceCompanyCashFlow>();
        }
    }
}
