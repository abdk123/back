using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class TransportCompanyVoucherDomainService : SouccarDomainService<TransportCompanyVoucher, int>, ITransportCompanyVoucherDomainService
    {
        private readonly IRepository<TransportCompanyVoucher> _repository;

        public TransportCompanyVoucherDomainService(IRepository<TransportCompanyVoucher> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
