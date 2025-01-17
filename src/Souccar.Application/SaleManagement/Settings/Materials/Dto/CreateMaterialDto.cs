using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Validation;
using Souccar.SaleManagement.Settings.Units.Dto;
using Souccar.SaleManagement.Stocks.Dto;

namespace Souccar.SaleManagement.Settings.Materials.Dto
{
    public class CreateMaterialDto : EntityDto<int>,ICustomValidate
    {
        public CreateMaterialDto()
        {
            Stocks = new List<CreateStockDto>();
        }
        public string Name { get; set; }
        public string Specification { get; set; }
        public int? UnitId { get; set; }
        public int? CategoryId { get; set; }
        public IList<CreateStockDto> Stocks { get; set; }
        public void AddValidationErrors(CustomValidationContext context)
        {
            using (var scope = context.IocResolver.CreateScope())
            {
                using (var uow = scope.Resolve<IUnitOfWorkManager>().Begin())
                {
                    var repository = scope.Resolve<IRepository<Material, int>>();

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

