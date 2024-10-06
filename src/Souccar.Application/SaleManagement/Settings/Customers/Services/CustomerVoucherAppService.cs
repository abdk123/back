using Souccar.SaleManagement.Settings.Customers.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Abp.Application.Services.Dto;
using Abp.Events.Bus;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Events;
using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.SaleManagement.Settings.Companies;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Settings.Customers.Services
{
    public class CustomerVoucherAppService :
        AsyncSouccarAppService<CustomerVoucher, CustomerVoucherDto, int, FullPagedRequestDto, CreateCustomerVoucherDto, UpdateCustomerVoucherDto>, ICustomerVoucherAppService
    {
        private readonly ICustomerVoucherDomainService _customerVoucherDomainService;
        public CustomerVoucherAppService(ICustomerVoucherDomainService customerVoucherDomainService) : base(customerVoucherDomainService)
        {
            _customerVoucherDomainService = customerVoucherDomainService;
        }

        public override async Task<CustomerVoucherDto> UpdateAsync(UpdateCustomerVoucherDto input)
        {

            var oldVoucher = await _customerVoucherDomainService.GetAsync(input.Id);
            EventBus.Default.Trigger(
                new CustomerCashFlowDeleteEventData(
                        oldVoucher.Currency == Currencies.Currency.Dollar ? oldVoucher.Amount : 0,
                        oldVoucher.Currency == Currencies.Currency.Dinar ? oldVoucher.Amount : 0,
                        "", "", oldVoucher.VoucherType == Customers.VoucherType.Receipt ? CashFlows.TransactionName.Receipt : CashFlows.TransactionName.Spend,
                        oldVoucher.CustomerId
                    ));

            var voucherDto = await base.UpdateAsync(input);
            var voucher = ObjectMapper.Map<CustomerVoucher>(voucherDto);

            EventBus.Default.Trigger(
                    new CustomerCashFlowCreateEventData(
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Receipt ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Receipt ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        voucher.VoucherType == Customers.VoucherType.Receipt ? CashFlows.TransactionName.Receipt : CashFlows.TransactionName.Spend,
                        voucher.CustomerId
                        ));

            return voucherDto;
        }

        public override async Task<CustomerVoucherDto> CreateAsync(CreateCustomerVoucherDto input)
        {
            var voucherDto = await base.CreateAsync(input);
            var voucher = ObjectMapper.Map<CustomerVoucher>(voucherDto);

            EventBus.Default.Trigger(
                    new CustomerCashFlowCreateEventData(
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Receipt ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Receipt ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        voucher.VoucherType == Customers.VoucherType.Receipt ? CashFlows.TransactionName.Receipt : CashFlows.TransactionName.Spend,
                        voucher.CustomerId
                        ));

            return voucherDto;
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var voucher = await _customerVoucherDomainService.GetAsync(input.Id);
            EventBus.Default.Trigger(
                new CustomerCashFlowDeleteEventData(
                        voucher.Currency == Currencies.Currency.Dollar ? voucher.Amount : 0,
                        voucher.Currency == Currencies.Currency.Dinar ? voucher.Amount : 0,
                        "", "", voucher.VoucherType == Customers.VoucherType.Receipt ? CashFlows.TransactionName.Receipt : CashFlows.TransactionName.Spend,
                        voucher.CustomerId
                    ));

            await base.DeleteAsync(input);
        }
    }
}

