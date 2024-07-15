using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Core.Dto;
using System.Collections.Generic;
using System.Linq;

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

        public IList<DropdownDto> GetForDropdownAsync()
        {
            var entities = _clearanceCompanyDomainService.GetAll();
            if (entities.Any())
                return ObjectMapper.Map<List<DropdownDto>>(entities.ToList());

            return new List<DropdownDto>();
        }
    }
}

