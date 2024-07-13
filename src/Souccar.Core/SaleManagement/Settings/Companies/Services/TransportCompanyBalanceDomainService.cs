using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class TransportBalanceCompanyDomainService : SouccarDomainService<TransportCompanyBalance, int>, ITransportCompanyBalanceDomainService
    {
        private readonly IRepository<TransportCompanyBalance> _repository;

        public TransportBalanceCompanyDomainService(IRepository<TransportCompanyBalance> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
