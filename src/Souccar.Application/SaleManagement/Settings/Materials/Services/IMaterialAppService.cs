using Souccar.SaleManagement.Settings.Materials.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Core.Dto;
using System.Collections.Generic;

namespace Souccar.SaleManagement.Settings.Materials.Services
{
    public interface IMaterialAppService : IAsyncSouccarAppService<MaterialDto, int, FullPagedRequestDto, CreateMaterialDto, UpdateMaterialDto>
    {
        IList<DropdownDto> GetForDropdown();
        
    }
}

