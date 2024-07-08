using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Settings.Units.Services
{
    public class UnitSizeDomainService : SouccarDomainService<UnitSize, int>,IUnitSizeDomainService
    {
        private readonly IRepository<UnitSize, int> _unitSizeRepository;
        public UnitSizeDomainService(IRepository<UnitSize, int> unitSizeRepository):base(unitSizeRepository)
        {
            _unitSizeRepository = unitSizeRepository;
        }
    }
}

