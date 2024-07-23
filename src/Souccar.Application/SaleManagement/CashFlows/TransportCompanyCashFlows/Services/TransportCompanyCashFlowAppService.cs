using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto;
using Souccar.SaleManagement.CachFlows.TransportCompanyCachFlows;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Services
{
    public class TransportCompanyCashFlowAppService :
        AsyncSouccarAppService<TransportCompanyCashFlow, TransportCompanyCashFlowDto, int, FullPagedRequestDto, TransportCompanyCashFlowDto, TransportCompanyCashFlowDto>, ITransportCompanyCashFlowAppService
    {
        private readonly ITransportCompanyCashFlowDomainService _transportCompanyCashFlowDomainService;

        public TransportCompanyCashFlowAppService(ITransportCompanyCashFlowDomainService transportCompanyCashFlowDomainService) : base(transportCompanyCashFlowDomainService)
        {
            _transportCompanyCashFlowDomainService = transportCompanyCashFlowDomainService;
        }

        public async Task<List<TransportCompanyCashFlowDto>> GetAllByTransportCompanyId(int transportCompanyId)
        {
            var cashFlows = await
                 Task.FromResult(_transportCompanyCashFlowDomainService.GetAllWithIncluding("TransportCompany")
                 .Where(x => x.TransportCompanyId == transportCompanyId).ToList());
            return ObjectMapper.Map<List<TransportCompanyCashFlowDto>>(cashFlows);
        }
    }
}
