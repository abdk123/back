using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Handlers;
using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.Stocks;
using Souccar.SaleManagement.Stocks.Services;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.StockHistories.Event
{
    public class StockHistoryEventCreateHandler : IAsyncEventHandler<StockHistoryEventCreateData>, ITransientDependency
    {
        private readonly IStockHistoryDomainService _coreDomainService;

        public StockHistoryEventCreateHandler(IStockHistoryDomainService coreDomainService)
        {
            _coreDomainService = coreDomainService;
        }

        public async Task HandleEventAsync(StockHistoryEventCreateData eventData)
        {
            var stockHistory = new StockHistory()
            {
                Quantity = eventData.Quantity,
                Reason = eventData.Reason,
                StockId = eventData.StockId,
                Title = eventData.Title,
                Type = eventData.Type
            };
            await _coreDomainService.InsertAsync(stockHistory);
        }
    }
}
