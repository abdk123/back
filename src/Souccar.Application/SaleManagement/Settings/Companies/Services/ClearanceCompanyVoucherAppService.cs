using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class ClearanceCompanyVoucherAppService :
        AsyncSouccarAppService<ClearanceCompanyVoucher, ClearanceCompanyVoucherDto, int, FullPagedRequestDto, CreateClearanceCompanyVoucherDto, UpdateClearanceCompanyVoucherDto>, IClearanceCompanyVoucherAppService
    {
        private readonly IClearanceCompanyVoucherDomainService _clearanceCompanyVoucherDomainService;

        public ClearanceCompanyVoucherAppService(IClearanceCompanyVoucherDomainService clearanceCompanyVoucherDomainService)
        : base(clearanceCompanyVoucherDomainService)
        {
            _clearanceCompanyVoucherDomainService = clearanceCompanyVoucherDomainService;
        }
    }
}

