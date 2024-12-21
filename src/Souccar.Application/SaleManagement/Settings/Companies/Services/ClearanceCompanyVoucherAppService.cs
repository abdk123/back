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
                        oldVoucher.VoucherType == Customers.VoucherType.Receipt ? CashFlows.TransactionName.Receipt : CashFlows.TransactionName.Spend,
                        oldVoucher.ClearanceCompanyId,
                        input.Id
                    ));

            var voucherDto = await base.UpdateAsync(input);
            var voucher = ObjectMapper.Map<ClearanceCompanyVoucher>(voucherDto);

            EventBus.Default.Trigger(
                    new ClearanceCompanyCashFlowCreateEventData(
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Receipt ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Receipt ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        
                        voucher.VoucherType == Customers.VoucherType.Receipt ? CashFlows.TransactionName.Receipt : CashFlows.TransactionName.Spend,
                        voucher.ClearanceCompanyId,
                        voucherDto.Id
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
                        voucher.VoucherType == Customers.VoucherType.Receipt ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Receipt ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        voucher.VoucherType == Customers.VoucherType.Receipt ? CashFlows.TransactionName.Receipt : CashFlows.TransactionName.Spend,
                        voucher.ClearanceCompanyId,
                        voucherDto.Id
                        ));

            return voucherDto;
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var voucher = await _clearanceCompanyVoucherDomainService.GetAsync(input.Id);
            EventBus.Default.Trigger(
                new ClearanceCompanyCashFlowDeleteEventData(
                        voucher.VoucherType == Customers.VoucherType.Receipt ? CashFlows.TransactionName.Receipt : CashFlows.TransactionName.Spend,
                        voucher.ClearanceCompanyId,
                        input.Id
                    ));

            await base.DeleteAsync(input);
        }
    }
}

