using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class ClearanceCompanyVoucherDomainService : SouccarDomainService<ClearanceCompanyVoucher, int>, IClearanceCompanyVoucherDomainService
    {
        private readonly IRepository<ClearanceCompanyVoucher> _repository;

        public ClearanceCompanyVoucherDomainService(IRepository<ClearanceCompanyVoucher> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
