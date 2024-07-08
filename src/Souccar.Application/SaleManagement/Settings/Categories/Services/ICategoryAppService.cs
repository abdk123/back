using Souccar.SaleManagement.Settings.Categories.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Categories.Services
{
    public interface ICategoryAppService : IAsyncSouccarAppService<CategoryDto, int, FullPagedRequestDto, CreateCategoryDto, UpdateCategoryDto>
    {
    }
}

