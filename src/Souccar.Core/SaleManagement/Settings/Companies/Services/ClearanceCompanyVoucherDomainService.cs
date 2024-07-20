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

        public override async Task<ClearanceCompanyVoucher> InsertAsync(ClearanceCompanyVoucher input)
        {
            var voucher = await base.InsertAsync(input);
            EventBus.Default.Trigger(
                    new ClearanceCompanyCashFlowCreateEventData(
                        input.Currency == Currencies.Currency.Dollar? input.Amount : 0,
                        input.Currency == Currencies.Currency.Dinar? input.Amount : 0,
                        "","",input.VoucherType == Customers.VoucherType.Receive? CashFlows.TransactionName.Receive: CashFlows.TransactionName.Spend,
                        input.ClearanceCompanyId
                        ));
            return voucher;
        }
    }
}
