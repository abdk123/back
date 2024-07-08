using Souccar.SaleManagement.Settings.Materials.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Materials.Services
{
    public class MaterialAppService :
        AsyncSouccarAppService<Material, MaterialDto, int, FullPagedRequestDto, CreateMaterialDto, UpdateMaterialDto>, IMaterialAppService
    {
        private readonly IMaterialDomainService _materialDomainService;
        public MaterialAppService(IMaterialDomainService materialDomainService) : base(materialDomainService)
        {
            _materialDomainService = materialDomainService;
        }
    }
}

