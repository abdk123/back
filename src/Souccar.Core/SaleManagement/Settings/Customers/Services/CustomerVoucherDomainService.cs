using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Events;
using Souccar.SaleManagement.Settings.Companies;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Settings.Customers.Services
{
    public class CustomerVoucherDomainService : SouccarDomainService<CustomerVoucher, int>, ICustomerVoucherDomainService
    {
        private readonly IRepository<CustomerVoucher> _repository;

        public CustomerVoucherDomainService(IRepository<CustomerVoucher> repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<CustomerVoucher> InsertAsync(CustomerVoucher input)
        {
            var voucher = await base.InsertAsync(input);
            EventBus.Default.Trigger(
                    new CustomerCashFlowCreateEventData(
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Receive ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Receive ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        "", "",
                        voucher.VoucherType == Customers.VoucherType.Receive ? CashFlows.TransactionName.Receive : CashFlows.TransactionName.Spend,
                        voucher.CustomerId
                        ));
            return voucher;
        }

        public override async Task DeleteAsync(int id)
        {
            var voucher = await _repository.GetAsync(id);
            EventBus.Default.Trigger(
                new CustomerCashFlowDeleteEventData(
                        voucher.Currency == Currencies.Currency.Dollar ? voucher.Amount : 0,
                        voucher.Currency == Currencies.Currency.Dinar ? voucher.Amount : 0,
                        "", "", voucher.VoucherType == Customers.VoucherType.Receive ? CashFlows.TransactionName.Receive : CashFlows.TransactionName.Spend,
                        voucher.CustomerId
                    ));
            await base.DeleteAsync(id);
        }

        public override async Task<CustomerVoucher> UpdateAsync(CustomerVoucher input)
        {
            var oldVoucher = await _repository.GetAsync(input.Id);
            EventBus.Default.Trigger(
                new CustomerCashFlowDeleteEventData(
                        oldVoucher.Currency == Currencies.Currency.Dollar ? oldVoucher.Amount : 0,
                        oldVoucher.Currency == Currencies.Currency.Dinar ? oldVoucher.Amount : 0,
                        "", "", oldVoucher.VoucherType == Customers.VoucherType.Receive ? CashFlows.TransactionName.Receive : CashFlows.TransactionName.Spend,
                        oldVoucher.CustomerId
                    ));

            var voucher = await base.UpdateAsync(input);

            EventBus.Default.Trigger(
                    new CustomerCashFlowCreateEventData(
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Receive ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Receive ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        "", "",
                        voucher.VoucherType == Customers.VoucherType.Receive ? CashFlows.TransactionName.Receive : CashFlows.TransactionName.Spend,
                        voucher.CustomerId
                        ));

            return voucher;
        }
    }
}
