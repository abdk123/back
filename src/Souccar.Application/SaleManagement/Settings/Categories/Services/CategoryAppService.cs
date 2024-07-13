using Souccar.SaleManagement.Settings.Categories.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

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

        public async Task<List<CategoryForDropdownDto>> GetForDropdown()
        {
            var categories = await Task.FromResult(_categoryDomainService.GetAll().ToList());
            return ObjectMapper.Map<List<CategoryForDropdownDto>>(categories);
        }

        public IList<CategoryForDropdownDto> GetForDropdown(string keyword)
        {
            var categories = _categoryDomainService.GetAll();
            if(!string.IsNullOrEmpty(keyword))
            {
                categories = categories.Where(x => x.Name.ToLower().Contains(keyword.ToLower()));
            }

            return ObjectMapper.Map<List<CategoryForDropdownDto>>(categories);
        }
    }
}

