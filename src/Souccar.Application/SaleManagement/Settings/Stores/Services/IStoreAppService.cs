using Souccar.SaleManagement.Settings.Stores.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Settings.Stores.Services
{
    public interface IStoreAppService : IAsyncSouccarAppService<StoreDto, int, FullPagedRequestDto, CreateStoreDto, UpdateStoreDto>
    {
        Task<List<StoreForDropdownDto>> GetForDropdown();
    }
}

