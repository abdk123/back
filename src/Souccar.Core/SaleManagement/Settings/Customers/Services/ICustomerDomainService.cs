using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.Settings.Currencies;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Settings.Customers.Services
{
    public interface ICustomerDomainService : ISouccarDomainService<Customer,int>
    {
        Task<double> GetCustomerBalance(int? customerId, Currency currency);
    }
}

