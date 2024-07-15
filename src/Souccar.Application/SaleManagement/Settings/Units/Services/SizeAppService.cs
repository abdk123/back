using Souccar.SaleManagement.Settings.Units.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Souccar.SaleManagement.Settings.Units.Services
{
    public class SizeAppService :
        AsyncSouccarAppService<Size, SizeDto, int, FullPagedRequestDto, CreateSizeDto, UpdateSizeDto>, ISizeAppService
    {
        private readonly ISizeDomainService _sizeDomainService;
        public SizeAppService(ISizeDomainService sizeDomainService) : base(sizeDomainService)
        {
            _sizeDomainService = sizeDomainService;
        }

        public async Task<List<SizeForDropdownDto>> GetForDropdown()
        {
            var sizes = await Task.FromResult(_sizeDomainService.GetAll().ToList());
            return ObjectMapper.Map<List<SizeForDropdownDto>>(sizes);
        }
    }
}

