using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.Settings.Stores;
using Souccar.SaleManagement.Settings.Stores.Services;
using Souccar.SaleManagement.Stocks;
using Souccar.SaleManagement.Stocks.Services;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.StockHistories.Event
{
    public class StockHistoryEventDeleteHandler : IAsyncEventHandler<StockHistoryEventDeleteData>, ITransientDependency
    {
        private readonly IStockHistoryDomainService _historyDomainService;
        private readonly IStockDomainService _stockDomainService;
        private readonly IStoreDomainService _storeDomainService;

        public StockHistoryEventDeleteHandler(IStockHistoryDomainService historyDomainService, IStockDomainService stockDomainService, IStoreDomainService storeDomainService)
        {
            _historyDomainService = historyDomainService;
            _stockDomainService = stockDomainService;
            _storeDomainService = storeDomainService;
        }

        public async Task HandleEventAsync(StockHistoryEventDeleteData eventData)
        {
            var existingHistory = await _historyDomainService.FirstOrDefaultAsync(x =>
            x.RelatedId == eventData.RelatedId && x.Reason == eventData.Reason && x.Type == eventData.Type);
            
            if(existingHistory != null)
            {
                await _historyDomainService.DeleteAsync(existingHistory.Id);
            }
            
        }
    }
}
