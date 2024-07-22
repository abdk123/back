using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class ClearanceCompanyVoucherDomainService : SouccarDomainService<ClearanceCompanyVoucher, int>, IClearanceCompanyVoucherDomainService
    {
        private readonly IRepository<ClearanceCompanyVoucher> _repository;

        public ClearanceCompanyVoucherDomainService(IRepository<ClearanceCompanyVoucher> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
