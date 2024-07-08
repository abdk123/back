using Souccar.Hcpc.Formulas.Services.Formulas;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Materials.Services;
using Souccar.Hcpc.Products;
using Souccar.Hcpc.Products.Dto.Formulas;
using Souccar.Hcpc.Products.Dto.Products;
using Souccar.Hcpc.Products.Services.Products;
using Souccar.Hcpc.Units.Dto.Units;
using Souccar.Hcpc.Units.Services.Units;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Souccar.Tests.Hcpc.Products
{
    public class ProductAppSevice_Test : SouccarTestBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IMaterialAppService _materialAppService;
        private readonly IUnitAppService _unitAppService;

        public ProductAppSevice_Test()
        {
            _productAppService = Resolve<IProductAppService>();
            _unitAppService = Resolve<IUnitAppService>();
            _materialAppService = Resolve<IMaterialAppService>();
        }

        [Fact]
        public async Task CreateProduct_Test()
        {
            Thread.Sleep(5000);
            //Get all units
            //var pagedProductRequest = new PagedProductRequestDto();
            //pagedProductRequest.MaxResultCount = 100;
            //pagedProductRequest.SkipCount = 0;
            //var products = await _productAppService.GetAllAsync(pagedProductRequest);

            //var pagedMaterialRequest = new PagedMaterialRequestDto();
            //pagedMaterialRequest.MaxResultCount = 100;
            //pagedMaterialRequest.SkipCount = 0;
            //var materials = await _materialAppService.GetAllAsync(pagedMaterialRequest);

            //var pagedUnitRequest = new PagedUnitRequestDto();
            //pagedUnitRequest.MaxResultCount = 100;
            //pagedUnitRequest.SkipCount = 0;
            //var units = await _unitAppService.GetAllAsync(pagedUnitRequest);

            //if (!products.Items.Any(x => x.Name.ToLower().Equals("Men shampoo")))
            //{

            //    var shampoo = new CreateProductDto();
            //    shampoo.Name = "Men shampoo";
            //    await _productAppService.CreateAsync(shampoo);
            //}

            //if (!products.Items.Any(x => x.Name.ToLower().Equals("Oil replacement")))
            //{
            //    var replacement = new CreateProductDto();
            //    replacement.Name = "Oil replacement";
            //    await _productAppService.CreateAsync(replacement);
            //}
        }
    }
}
