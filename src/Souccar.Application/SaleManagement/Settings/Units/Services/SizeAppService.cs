using Souccar.SaleManagement.Settings.Units.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

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
    }
}

