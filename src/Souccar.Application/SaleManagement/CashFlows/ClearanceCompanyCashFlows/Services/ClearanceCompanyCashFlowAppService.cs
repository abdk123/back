using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Dto;
using System;
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

        public async Task<List<ClearanceCompanyCashFlowDto>> GetAllByClearanceCompanyId(int clearanceCompanyId, string fromDate, string toDate)
        {
            var fromDateSearch = DateTime.Now;
            if (!string.IsNullOrEmpty(fromDate))
            {
                fromDateSearch = DateTime.Parse(fromDate);
            }
            fromDateSearch = new DateTime(fromDateSearch.Year, fromDateSearch.Month, fromDateSearch.Day, 12, 0, 0);

            var toDateSearch = DateTime.Now;
            if (!string.IsNullOrEmpty(toDate))
            {
                toDateSearch = DateTime.Parse(toDate);
            }
            toDateSearch = new DateTime(toDateSearch.Year, toDateSearch.Month, toDateSearch.Day, 23, 59, 59);

            var cashFlows = await
                 Task.FromResult(_clearanceCompanyCashFlowDomainService.GetAllWithIncluding("ClearanceCompany")
                 .Where(x => x.ClearanceCompanyId == clearanceCompanyId && x.CreationTime >= fromDateSearch && x.CreationTime <= toDateSearch).ToList());
            return ObjectMapper.Map<List<ClearanceCompanyCashFlowDto>>(cashFlows);
        }
    }
}
