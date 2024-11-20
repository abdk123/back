using Souccar.SaleManagement.Settings.Units.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Threading.Tasks;
using System.Linq;

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

        public async override Task<UnitDto> CreateAsync(CreateUnitDto input)
        {
            var existingUnits = _unitDomainService.Get(x=>x.Name.ToLower() == input.Name.ToLower());
            if(existingUnits.Any())
            {
                var existingUnit = existingUnits.First();
                return ObjectMapper.Map<UnitDto>(existingUnit);
            }
            return await base.CreateAsync(input);
        }
    }
}

