using Souccar.Core.Dto.PagedRequests;
using Souccar.Hcpc.Units.Dto.Units;
using Souccar.Hcpc.Units.Services.Units;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Souccar.Tests.Hcpc.Units
{
    public class UnitAppService_Test : SouccarTestBase
    {
        private readonly IUnitAppService _unitAppService;
        public UnitAppService_Test()
        {
            _unitAppService = Resolve<IUnitAppService>();
        }

        [Fact]
        public async Task CreateUnits_Test()
        {
            //Get all units
            var pagedUnitRequest = new FullPagedRequestDto();
            pagedUnitRequest.MaxResultCount = 100;
            pagedUnitRequest.SkipCount = 0;
            var units = await _unitAppService.GetAllAsync(pagedUnitRequest);

            var values = new List<string> { "kg" , "g", "ml" , "l" };
            foreach (var value in values)
            {
                if (!units.Items.Any(x => x.Name.ToLower().Equals(value)))
                {
                    var unit = new CreateUnitDto();
                    unit.Name = value;
                    await _unitAppService.CreateAsync(unit);
                }
            }
        }
    }
}
