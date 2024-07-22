using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.Settings.Currencies;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class ClearanceCompanyDomainService : SouccarDomainService<ClearanceCompany, int>, IClearanceCompanyDomainService
    {
        private readonly IRepository<ClearanceCompany, int> _clearanceCompanyRepository;
        public ClearanceCompanyDomainService
            (IRepository<ClearanceCompany, int> clearanceCompanyRepository) : base(clearanceCompanyRepository)
        {
            _clearanceCompanyRepository = clearanceCompanyRepository;
        }

        public async Task<double> GetClearanceCompanyBalance(int? clearanceCompanyId, Currency currency)
        {
            double balance = 0;

            var clearanceCompany = await _clearanceCompanyRepository.GetAsync((int)clearanceCompanyId);
            if (clearanceCompany != null)
            {
                if (currency == Currency.Dinar)
                {
                    balance = clearanceCompany.BalanceInDinar;
                }
                else
                {
                    balance = clearanceCompany.BalanceInDollar;
                }
            }

            return balance;
        }

    }
}

