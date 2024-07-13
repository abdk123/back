using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Settings.Customers.Services
{
    public class CustomerVoucherDomainService : SouccarDomainService<CustomerVoucher, int>, ICustomerVoucherDomainService
    {
        private readonly IRepository<CustomerVoucher> _repository;

        public CustomerVoucherDomainService(IRepository<CustomerVoucher> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
