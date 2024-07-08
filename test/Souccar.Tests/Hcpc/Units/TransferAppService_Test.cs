using NSubstitute;
using Souccar.Hcpc.Formulas.Services.Formulas;
using Souccar.Hcpc.Products.Dto.Formulas;
using Souccar.Hcpc.Transfers.Services.Transfers;
using Souccar.Hcpc.Units.Dto.Transfers;
using Souccar.Hcpc.Units.Dto.Units;
using Souccar.Hcpc.Units.Services.Units;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Souccar.Tests.Hcpc.Units
{
    public class TransferAppService_Test : SouccarTestBase
    {
        private readonly ITransferAppService _transferAppService;
        private readonly IFormulaAppService _formulaAppService;
        
        public TransferAppService_Test()
        {
            _transferAppService = Resolve<ITransferAppService>();
            
            _formulaAppService = Resolve<IFormulaAppService>();
        }

        [Fact]
        public async Task ConvertTo()
        {
            //FormulaDto formula = null;
            ////Get all units
            //var pagedFormulaRequest = new PagedFormulaRequestDto();
            //pagedFormulaRequest.MaxResultCount = 100;
            //pagedFormulaRequest.SkipCount = 0;
            //var formulas = await _formulaAppService.GetAllAsync(pagedFormulaRequest);
            //if (formulas.TotalCount > 0)
            //{
                
            //}


            //var input = new ConvertToInputDto()
            //{
            //    FromId = 1,
            //    ToId = 2,
            //    Value = 100
            //};

            //await _transferAppService.ConvertTo(input);
        }
    }
}
