using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Settings.Units.Services
{
    public class UnitDomainService : SouccarDomainService<Unit, int>, IUnitDomainService
    {
        private readonly IRepository<Unit, int> _unitRepository;
        public UnitDomainService(IRepository<Unit, int> unitRepository):base(unitRepository)
        {
            _unitRepository = unitRepository;
        }
    }
}

