using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public interface IClearanceCompanyVoucherAppService : IAsyncSouccarAppService<ClearanceCompanyVoucherDto, int, FullPagedRequestDto, CreateClearanceCompanyVoucherDto, UpdateClearanceCompanyVoucherDto>
    {
       
    }
}

