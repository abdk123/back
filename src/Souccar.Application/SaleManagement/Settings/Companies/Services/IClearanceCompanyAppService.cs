using Souccar.Core.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.Settings.Companies.Dto;
using System.Collections.Generic;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public interface IClearanceCompanyAppService : IAsyncSouccarAppService<ClearanceCompanyDto, int, FullPagedRequestDto, CreateClearanceCompanyDto, UpdateClearanceCompanyDto>
    {
        IList<DropdownDto> GetForDropdownAsync();
    }
}

