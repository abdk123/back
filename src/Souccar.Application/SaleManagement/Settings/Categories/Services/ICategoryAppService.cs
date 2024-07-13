using Souccar.SaleManagement.Settings.Categories.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Souccar.SaleManagement.Settings.Categories.Services
{
    public interface ICategoryAppService : IAsyncSouccarAppService<CategoryDto, int, FullPagedRequestDto, CreateCategoryDto, UpdateCategoryDto>
    {
        Task<List<CategoryForDropdownDto>> GetForDropdown();
    }
}

