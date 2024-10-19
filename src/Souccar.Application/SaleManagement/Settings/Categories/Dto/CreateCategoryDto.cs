using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Validation;

namespace Souccar.SaleManagement.Settings.Categories.Dto
{
   public class CreateCategoryDto : EntityDto<int>, ICustomValidate
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            using (var scope = context.IocResolver.CreateScope())
            {
                using (var uow = scope.Resolve<IUnitOfWorkManager>().Begin())
                {
                    var categoryRepository = scope.Resolve<IRepository<Category, int>>();

                    var nameExists = categoryRepository.GetAll()
                        .Any(s => s.Name == Name);

                    if (nameExists)
                    {
                        var key = ValidationMessage.NameAlreadyExist;
                        var errorMessage = context.Localize(SouccarConsts.LocalizationSourceName, key);
                        var memberNames = new[] { nameof(Name) };
                        context.Results.Add(new ValidationResult(errorMessage, memberNames));
                    }

                    uow.Complete();
                }
            }
        }
    }
}

