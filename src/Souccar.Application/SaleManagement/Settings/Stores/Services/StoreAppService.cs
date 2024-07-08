using Souccar.SaleManagement.Settings.Stores.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Stores.Services
{
    public class StoreAppService :
        AsyncSouccarAppService<Store, StoreDto, int, FullPagedRequestDto, CreateStoreDto, UpdateStoreDto>, IStoreAppService
    {
        private readonly IStoreDomainService _storeDomainService;
        public StoreAppService(IStoreDomainService storeDomainService) : base(storeDomainService)
        {
            _storeDomainService = storeDomainService;
        }
    }
}

