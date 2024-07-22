using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.Settings.Currencies;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class TransportCompanyDomainService : SouccarDomainService<TransportCompany,int>, ITransportCompanyDomainService
    {
        private readonly IRepository<TransportCompany, int> _transportCompanyRepository;
        public TransportCompanyDomainService(IRepository<TransportCompany, int> transportCompanyRepository):base(transportCompanyRepository)
        {
            _transportCompanyRepository = transportCompanyRepository;
        }

        public async Task<double> GetTransportCompanyBalance(int? transportCompanyId, Currency currency)
        {
            double balance = 0;

            var transportCompany = await _transportCompanyRepository.GetAsync((int)transportCompanyId);
            if (transportCompany != null)
            {
                if (currency == Currency.Dinar)
                {
                    balance = transportCompany.BalanceInDinar;
                }
                else
                {
                    balance = transportCompany.BalanceInDollar;
                }
            }

            return balance;
        }
    }
}

