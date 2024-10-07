using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Dto;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Services
{
    public interface ICustomerCashFlowAppService : IAsyncSouccarAppService<CustomerCashFlowDto, int, FullPagedRequestDto, CustomerCashFlowDto, CustomerCashFlowDto>
    {
        Task<List<CustomerCashFlowDto>> GetAllByCustomerId(int customerId, string fromDate, string toDate, Currency? currency);
        Task<BalanceInfoDto> GetBalance(int id);
        IList<BalanceInfoDto> GetAllBalances();
    }
}
