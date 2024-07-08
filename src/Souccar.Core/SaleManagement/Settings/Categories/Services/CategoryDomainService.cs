using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using System.Linq;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.Settings.Companies.Services;
using Souccar.SaleManagement.Settings.Companies;

namespace Souccar.SaleManagement.Settings.Categories.Services
{
    public class CategoryDomainService : SouccarDomainService<Category, int>, ICategoryDomainService
    {
        private readonly IRepository<Category, int> _categoryRepository;
        public CategoryDomainService(IRepository<Category, int> categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}

