using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Core.Dto;
using System.Collections.Generic;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public interface ITransportCompanyAppService : IAsyncSouccarAppService<TransportCompanyDto, int, FullPagedRequestDto, CreateTransportCompanyDto, UpdateTransportCompanyDto>
    {
        IList<DropdownDto> GetForDropdownAsync();
    }
}

