using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class TransportCompanyVoucherAppService :
        AsyncSouccarAppService<TransportCompanyVoucher, TransportCompanyVoucherDto, int, FullPagedRequestDto, CreateTransportCompanyVoucherDto, UpdateTransportCompanyVoucherDto>, ITransportCompanyVoucherAppService
    {
        private readonly ITransportCompanyVoucherDomainService _transportCompanyVoucherDomainService;

        public TransportCompanyVoucherAppService(ITransportCompanyVoucherDomainService transportCompanyVoucherDomainService)
        :base(transportCompanyVoucherDomainService)
        {
            _transportCompanyVoucherDomainService = transportCompanyVoucherDomainService;
        }
    }
}

