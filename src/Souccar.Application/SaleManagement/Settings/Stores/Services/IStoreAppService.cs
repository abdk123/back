using Souccar.SaleManagement.Settings.Stores.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Stores.Services
{
    public interface IStoreAppService : IAsyncSouccarAppService<StoreDto, int, FullPagedRequestDto, CreateStoreDto, UpdateStoreDto>
    {
    }
}

