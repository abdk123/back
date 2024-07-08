using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Materials.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Souccar.Tests.Hcpc.Materials
{
    public class MaterialAppService_Test : SouccarTestBase
    {
        private readonly IMaterialAppService _materialAppService;

        public MaterialAppService_Test()
        {
            _materialAppService = Resolve<IMaterialAppService>();
        }

        //[Fact]
        //public async Task CreateMaterials_Test()
        //{
        //    //Get all units
        //    var pagedRequest = new PagedMaterialRequestDto();
        //    pagedRequest.MaxResultCount = 100;
        //    pagedRequest.SkipCount = 0;
        //    var materials = await _materialAppService.GetAllAsync(pagedRequest);

        //    if (!materials.Items.Any(x => x.Name.ToLower().Equals("Oil")))
        //    {
        //        var oil = new CreateMaterialDto();
        //        oil.Name = "Oil";
        //        oil.Description = "Oil";
        //        oil.LeadTime = 1;
        //        oil.Price = 10;
        //        await _materialAppService.CreateAsync(oil);
        //    }

        //    if (!materials.Items.Any(x => x.Name.ToLower().Equals("Phosphate")))
        //    {
        //        var phosphate = new CreateMaterialDto();
        //        phosphate.Name = "Phosphate";
        //        phosphate.Description = "Phosphate";
        //        phosphate.LeadTime = 30;
        //        await _materialAppService.CreateAsync(phosphate);
        //    }

        //    if (!materials.Items.Any(x => x.Name.ToLower().Equals("Silicone")))
        //    {
        //        var silicone = new CreateMaterialDto();
        //        silicone.Name = "Silicone";
        //        silicone.Description = "Silicone";
        //        silicone.LeadTime = 10;
        //        await _materialAppService.CreateAsync(silicone);
        //    }

        //}
    }
}
