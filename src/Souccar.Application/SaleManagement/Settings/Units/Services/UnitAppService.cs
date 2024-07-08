using Souccar.SaleManagement.Settings.Units.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Units.Services
{
    public class UnitAppService :
        AsyncSouccarAppService<Unit, UnitDto, int, FullPagedRequestDto, CreateUnitDto, UpdateUnitDto>, IUnitAppService
    {
        private readonly IUnitDomainService _unitDomainService;
        public UnitAppService(IUnitDomainService unitDomainService) : base(unitDomainService)
        {
            _unitDomainService = unitDomainService;
        }
    }
}

