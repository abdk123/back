using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Settings.Stores.Services
{
    public class StoreDomainService : SouccarDomainService<Store, int>, IStoreDomainService
    {
        private readonly IRepository<Store, int> _storeRepository;
        public StoreDomainService(IRepository<Store, int> storeRepository) : base(storeRepository)
        {
            _storeRepository = storeRepository;
        }

    }
}

