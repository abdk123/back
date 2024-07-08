using Souccar.SaleManagement.Settings.Categories.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Categories.Services
{
    public class CategoryAppService :
        AsyncSouccarAppService<Category, CategoryDto, int, FullPagedRequestDto, CreateCategoryDto, UpdateCategoryDto>, ICategoryAppService
    {
        private readonly ICategoryDomainService _categoryDomainService;
        public CategoryAppService(ICategoryDomainService categoryDomainService) : base(categoryDomainService)
        {
            _categoryDomainService = categoryDomainService;
        }
    }
}

