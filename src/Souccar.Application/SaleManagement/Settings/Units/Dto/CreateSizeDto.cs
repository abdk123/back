using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Validation;
using Souccar.SaleManagement.Settings.Materials;

namespace Souccar.SaleManagement.Settings.Units.Dto
{
   public class CreateSizeDto : EntityDto<int>,ICustomValidate
    {
        public string Name { get; set; }
        public void AddValidationErrors(CustomValidationContext context)
        {
            using (var scope = context.IocResolver.CreateScope())
            {
                using (var uow = scope.Resolve<IUnitOfWorkManager>().Begin())
                {
                    var repository = scope.Resolve<IRepository<Size, int>>();

                    var nameExists = repository.GetAll()
                        .Any(x => x.Name == Name && x.Id != Id);

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

