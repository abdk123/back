using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Events;
using System.Threading.Tasks;

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
