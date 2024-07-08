using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Settings.Materials.Services
{
    public class MaterialDomainService : SouccarDomainService<Material, int>, IMaterialDomainService
    {
        private readonly IRepository<Material, int> _materialRepository;
        public MaterialDomainService(IRepository<Material, int> materialRepository):base(materialRepository)
        {
            _materialRepository = materialRepository;
        }
        
    }
}

