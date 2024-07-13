using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class ClearanceBalanceCompanyDomainService : SouccarDomainService<ClearanceCompanyBalance, int>, IClearanceCompanyBalanceDomainService
    {
        private readonly IRepository<ClearanceCompanyBalance> _repository;

        public ClearanceBalanceCompanyDomainService(IRepository<ClearanceCompanyBalance> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
