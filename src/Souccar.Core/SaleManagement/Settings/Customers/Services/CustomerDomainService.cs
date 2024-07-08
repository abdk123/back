using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Settings.Customers.Services
{
    public class CustomerDomainService : SouccarDomainService<Customer,int>,ICustomerDomainService
    {
        private readonly IRepository<Customer, int> _customerRepository;
        public CustomerDomainService(IRepository<Customer, int> customerRepository):base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

    }
}

