using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Services
{
    public class ClearanceCompanyCashFlowAppService :
        AsyncSouccarAppService<ClearanceCompanyCashFlow, ClearanceCompanyCashFlowDto, int, FullPagedRequestDto, ClearanceCompanyCashFlowDto, ClearanceCompanyCashFlowDto>, IClearanceCompanyCashFlowAppService
    {
        private readonly IClearanceCompanyCashFlowDomainService _clearanceCompanyCashFlowDomainService;

        public ClearanceCompanyCashFlowAppService(IClearanceCompanyCashFlowDomainService clearanceCompanyCashFlowDomainService) : base(clearanceCompanyCashFlowDomainService)
        {
            _clearanceCompanyCashFlowDomainService = clearanceCompanyCashFlowDomainService;
        }

        public async Task<List<ClearanceCompanyCashFlowDto>> GetAllByClearanceCompanyId(int clearanceCompanyId)
        {
            var cashFlows = await
                 Task.FromResult(_clearanceCompanyCashFlowDomainService.GetAllWithIncluding("ClearanceCompany")
                 .Where(x => x.ClearanceCompanyId == clearanceCompanyId).ToList());
            return ObjectMapper.Map<List<ClearanceCompanyCashFlowDto>>(cashFlows);
        }
    }
}
