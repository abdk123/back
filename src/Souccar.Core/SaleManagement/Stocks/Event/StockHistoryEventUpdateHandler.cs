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
    public class StockHistoryEventUpdateHandler : IAsyncEventHandler<StockHistoryEventUpdateData>, ITransientDependency
    {
        private readonly IStockHistoryDomainService _historyDomainService;
        private readonly IStockDomainService _stockDomainService;
        private readonly IStoreDomainService _storeDomainService;

        public StockHistoryEventUpdateHandler(IStockHistoryDomainService historyDomainService, IStockDomainService stockDomainService, IStoreDomainService storeDomainService)
        {
            _historyDomainService = historyDomainService;
            _stockDomainService = stockDomainService;
            _storeDomainService = storeDomainService;
        }

        public async Task HandleEventAsync(StockHistoryEventUpdateData eventData)
        {
            var existingHistory = await _historyDomainService.FirstOrDefaultAsync(x =>
            x.RelatedId == eventData.RelatedId && x.Reason == eventData.Reason && x.Type == eventData.Type);
            
            if(existingHistory != null)
            {
                existingHistory.Quantity = eventData.Quantity;
                await _historyDomainService.InsertAsync(existingHistory);
            }
            else
            {
                int? stockId = null;
                var stock = await _stockDomainService
                    .FirstOrDefaultAsync(x => x.SizeId == eventData.SizeId);
                if(stock is not null)
                {
                    stockId = stock.Id;
                }
                else
                {
                    Store store = _storeDomainService.GetAll().FirstOrDefault();
                    var createdStok = new Stock
                    {
                        SizeId = eventData.SizeId,
                        MaterialId = eventData.MaterialId,
                        StoreId = store?.Id
                    };
                    stockId = (await _stockDomainService.InsertAsync(createdStok))?.Id;
                }
                
                var stockHistory = new StockHistory()
                {
                    Quantity = eventData.Quantity,
                    Reason = eventData.Reason,
                    StockId = stockId,
                    Title = eventData.Title,
                    Type = eventData.Type,
                    RelatedId = eventData.RelatedId,
                };
                await _historyDomainService.InsertAsync(stockHistory);
            }
        }
    }
}
