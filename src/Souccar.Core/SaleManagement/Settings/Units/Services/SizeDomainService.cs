using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Settings.Units.Services
{
    public class SizeDomainService : SouccarDomainService<Size, int>, ISizeDomainService
    {
        private readonly IRepository<Size, int> _sizeRepository;
        public SizeDomainService(IRepository<Size, int> sizeRepository):base(sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }
    }
}

