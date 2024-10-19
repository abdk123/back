using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Validation;
using Souccar.SaleManagement.Settings.Categories;

namespace Souccar.SaleManagement.Settings.Companies.Dto
{
   public class CreateClearanceCompanyDto : EntityDto<int>,ICustomValidate
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double BalanceInDollar { get; set; }
        public double BalanceInDinar { get; set; }
        public void AddValidationErrors(CustomValidationContext context)
        {
            using (var scope = context.IocResolver.CreateScope())
            {
                using (var uow = scope.Resolve<IUnitOfWorkManager>().Begin())
                {
                    var repository = scope.Resolve<IRepository<ClearanceCompany, int>>();

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

