using Souccar.SaleManagement.Settings.Stores.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<List<StoreForDropdownDto>> GetForDropdown()
        {
            var stores = await Task.FromResult(_storeDomainService.GetAll().ToList());
            return ObjectMapper.Map<List<StoreForDropdownDto>>(stores);
        }
    }
}

