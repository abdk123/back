using Souccar.SaleManagement.Settings.Units.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Settings.Units.Services
{
    public interface ISizeAppService : IAsyncSouccarAppService<SizeDto, int, FullPagedRequestDto, CreateSizeDto, UpdateSizeDto>
    {
        Task<List<SizeForDropdownDto>> GetForDropdown();
    }
}

