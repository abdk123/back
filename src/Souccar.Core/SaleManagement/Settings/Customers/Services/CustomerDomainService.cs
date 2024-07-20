using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.Settings.Currencies;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Settings.Customers.Services
{
    public class CustomerDomainService : SouccarDomainService<Customer,int>,ICustomerDomainService
    {
        private readonly IRepository<Customer, int> _customerRepository;
        public CustomerDomainService(IRepository<Customer, int> customerRepository):base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<double> GetCustomerBalance(int? customerId, Currency currency)
        {
            double balance = 0;

            var customer = await _customerRepository.GetAsync((int)customerId);
            if (customer != null)
            {
                if (currency == Currency.Dinar)
                {
                    balance = customer.BalanceInDinar;
                }
                else
                {
                    balance = customer.BalanceInDollar;
                }
            }

            return balance;
        }
    }
}

