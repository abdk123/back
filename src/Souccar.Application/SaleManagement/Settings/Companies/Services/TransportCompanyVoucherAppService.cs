using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Events;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class TransportCompanyVoucherAppService :
        AsyncSouccarAppService<TransportCompanyVoucher, TransportCompanyVoucherDto, int, FullPagedRequestDto, CreateTransportCompanyVoucherDto, UpdateTransportCompanyVoucherDto>, ITransportCompanyVoucherAppService
    {
        private readonly ITransportCompanyVoucherDomainService _transportCompanyVoucherDomainService;

        public TransportCompanyVoucherAppService(ITransportCompanyVoucherDomainService transportCompanyVoucherDomainService)
        :base(transportCompanyVoucherDomainService)
        {
            _transportCompanyVoucherDomainService = transportCompanyVoucherDomainService;
        }

        public override async Task<TransportCompanyVoucherDto> UpdateAsync(UpdateTransportCompanyVoucherDto input)
        {

            var oldVoucher = await _transportCompanyVoucherDomainService.GetAsync(input.Id);
            EventBus.Default.Trigger(
                new TransportCompanyCashFlowDeleteEventData(
                        oldVoucher.Currency == Currencies.Currency.Dollar ? oldVoucher.Amount : 0,
                        oldVoucher.Currency == Currencies.Currency.Dinar ? oldVoucher.Amount : 0,
                        "", "", oldVoucher.VoucherType == Customers.VoucherType.Receipt ? CashFlows.TransactionName.Receipt : CashFlows.TransactionName.Spend,
                        oldVoucher.TransportCompanyId
                    ));

            var voucherDto = await base.UpdateAsync(input);
            var voucher = ObjectMapper.Map<TransportCompanyVoucher>(voucherDto);

            EventBus.Default.Trigger(
                    new TransportCompanyCashFlowCreateEventData(
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Receipt ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Receipt ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        voucher.VoucherType == Customers.VoucherType.Receipt ? CashFlows.TransactionName.Receipt : CashFlows.TransactionName.Spend,
                        voucher.TransportCompanyId
                        ));

            return voucherDto;
        }

        public override async Task<TransportCompanyVoucherDto> CreateAsync(CreateTransportCompanyVoucherDto input)
        {
            var voucherDto = await base.CreateAsync(input);
            var voucher = ObjectMapper.Map<TransportCompanyVoucher>(voucherDto);

            EventBus.Default.Trigger(
                    new TransportCompanyCashFlowCreateEventData(
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Receipt ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dollar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Receipt ? voucher.Amount :
                        voucher.Currency == Currencies.Currency.Dinar &&
                        voucher.VoucherType == Customers.VoucherType.Spend ? (-1 * voucher.Amount) : 0,

                        voucher.VoucherType == Customers.VoucherType.Receipt ? CashFlows.TransactionName.Receipt : CashFlows.TransactionName.Spend,
                        voucher.TransportCompanyId
                        ));

            return voucherDto;
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var voucher = await _transportCompanyVoucherDomainService.GetAsync(input.Id);
            EventBus.Default.Trigger(
                new TransportCompanyCashFlowDeleteEventData(
                        voucher.Currency == Currencies.Currency.Dollar ? voucher.Amount : 0,
                        voucher.Currency == Currencies.Currency.Dinar ? voucher.Amount : 0,
                        "", "", voucher.VoucherType == Customers.VoucherType.Receipt ? CashFlows.TransactionName.Receipt : CashFlows.TransactionName.Spend,
                        voucher.TransportCompanyId
                    ));

           await base.DeleteAsync(input);
        }
    }
}

