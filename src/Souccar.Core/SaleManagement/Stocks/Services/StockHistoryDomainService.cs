using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.Stocks;
using Souccar.SaleManagement.Stocks.Services;

namespace Souccar.SaleManagement.StockHistorys.Services
{
    public class StockHistoryDomainService : SouccarDomainService<StockHistory, int>,IStockHistoryDomainService
    {
        private readonly IRepository<StockHistory, int> _stockRepository;
        public StockHistoryDomainService(IRepository<StockHistory, int> stockRepository):base(stockRepository)
        {
            _stockRepository = stockRepository;
        }
    }
}

