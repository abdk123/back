using Souccar.SaleManagement.Settings.Units.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Settings.Units.Services
{
    public interface IUnitAppService : IAsyncSouccarAppService<UnitDto, int, FullPagedRequestDto, CreateUnitDto, UpdateUnitDto>
    {
        
    }
}

