using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public interface ITransportCompanyVoucherAppService : IAsyncSouccarAppService<TransportCompanyVoucherDto, int, FullPagedRequestDto, CreateTransportCompanyVoucherDto, UpdateTransportCompanyVoucherDto>
    {
        
    }
}

