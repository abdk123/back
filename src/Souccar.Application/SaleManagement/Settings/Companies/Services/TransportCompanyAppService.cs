using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class TransportCompanyAppService :
        AsyncSouccarAppService<TransportCompany, TransportCompanyDto, int, FullPagedRequestDto, CreateTransportCompanyDto, UpdateTransportCompanyDto>, ITransportCompanyAppService
    {
        public TransportCompanyAppService(ITransportCompanyDomainService transportCompanyDomainService) : base(transportCompanyDomainService)
        {
           
        }
    }
}

