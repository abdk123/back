using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Validation;
using Souccar.SaleManagement.Settings.Categories;

namespace Souccar.SaleManagement.Settings.Customers.Dto
{
   public class CreateCustomerDto : EntityDto<int>, ICustomValidate
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double BalanceInDollar { get; set; }
        public double BalanceInDinar { get; set; }
        //public double InitialBalance { get; set; }
        public int Type { get; set; }
        public void AddValidationErrors(CustomValidationContext context)
        {
            using (var scope = context.IocResolver.CreateScope())
            {
                using (var uow = scope.Resolve<IUnitOfWorkManager>().Begin())
                {
                    var repository = scope.Resolve<IRepository<Customer, int>>();

                    var nameExists = repository.GetAll()
                        .Any(x => x.FullName == FullName && x.Id != Id);

                    if (nameExists)
                    {
                        var key = ValidationMessage.NameAlreadyExist;
                        var errorMessage = context.Localize(SouccarConsts.LocalizationSourceName, key);
                        var memberNames = new[] { nameof(FullName) };
                        context.Results.Add(new ValidationResult(errorMessage, memberNames));
                    }

                    uow.Complete();
                }
            }
        }
    }
}

