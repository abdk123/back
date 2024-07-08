using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class ClearanceCompanyAppService :
        AsyncSouccarAppService<ClearanceCompany, ClearanceCompanyDto, int, FullPagedRequestDto, CreateClearanceCompanyDto, UpdateClearanceCompanyDto>, IClearanceCompanyAppService
    {
        private readonly IClearanceCompanyDomainService _clearanceCompanyDomainService;
        public ClearanceCompanyAppService(IClearanceCompanyDomainService clearanceCompanyDomainService) : base(clearanceCompanyDomainService)
        {
            _clearanceCompanyDomainService = clearanceCompanyDomainService;
        }
    }
}

