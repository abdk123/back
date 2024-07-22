using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Abp.Application.Services.Dto;
using Abp.Events.Bus;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class ClearanceCompanyVoucherAppService :
        AsyncSouccarAppService<ClearanceCompanyVoucher, ClearanceCompanyVoucherDto, int, FullPagedRequestDto, CreateClearanceCompanyVoucherDto, UpdateClearanceCompanyVoucherDto>, IClearanceCompanyVoucherAppService
    {
        private readonly IClearanceCompanyVoucherDomainService _clearanceCompanyVoucherDomainService;

        public ClearanceCompanyVoucherAppService(IClearanceCompanyVoucherDomainService clearanceCompanyVoucherDomainService)
        : base(clearanceCompanyVoucherDomainService)
        {
            _clearanceCompanyVoucherDomainService = clearanceCompanyVoucherDomainService;
        }

        public override async Task<ClearanceCompanyVoucherDto> UpdateAsync(UpdateClearanceCompanyVoucherDto input)
        {

            var oldVoucher = await _clearanceCompanyVoucherDomainService.GetAsync(input.Id);
            EventBus.Default.Trigger(
                new ClearanceCompanyCashFlowDeleteEventData(
                        oldVoucher.Currency == Currencies.Currency.Dollar ? oldVoucher.Amount : 0,
                        oldVoucher.Currency == Currencies.Currency.Dinar ? oldVoucher.Amount : 0,
                        "", "", oldVoucher.VoucherType == Customers.VoucherType.Receive ? CashFlows.TransactionName.Receive : CashFlows.TransactionName.Spend,
                        oldVoucher.ClearanceCompanyId
                    ));

            var voucherDto = await base.UpdateAsync(input);
            var voucher = ObjectMapper.Map<ClearanceCompanyVoucher>(voucherDto);

            EventBus.Default.Trigger(
                    new ClearanceCompanyCashFlowCreateEventData(
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
                        voucher.ClearanceCompanyId
                        ));

            return voucherDto;
        }

        public override async Task<ClearanceCompanyVoucherDto> CreateAsync(CreateClearanceCompanyVoucherDto input)
        {
            var voucherDto = await base.CreateAsync(input);
            var voucher = ObjectMapper.Map<ClearanceCompanyVoucher>(voucherDto);

            EventBus.Default.Trigger(
                    new ClearanceCompanyCashFlowCreateEventData(
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
                        voucher.ClearanceCompanyId
                        ));

            return voucherDto;
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var voucher = await _clearanceCompanyVoucherDomainService.GetAsync(input.Id);
            EventBus.Default.Trigger(
                new ClearanceCompanyCashFlowDeleteEventData(
                        voucher.Currency == Currencies.Currency.Dollar ? voucher.Amount : 0,
                        voucher.Currency == Currencies.Currency.Dinar ? voucher.Amount : 0,
                        "", "", voucher.VoucherType == Customers.VoucherType.Receive ? CashFlows.TransactionName.Receive : CashFlows.TransactionName.Spend,
                        voucher.ClearanceCompanyId
                    ));

            await base.DeleteAsync(input);
        }
    }
}

