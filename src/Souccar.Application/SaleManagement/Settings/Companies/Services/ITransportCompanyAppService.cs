using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public interface ITransportCompanyAppService : IAsyncSouccarAppService<TransportCompanyDto, int, FullPagedRequestDto, CreateTransportCompanyDto, UpdateTransportCompanyDto>
    {
    }
}

