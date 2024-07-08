using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Stocks.Services
{
    public class StockDomainService : SouccarDomainService<Stock, int>,IStockDomainService
    {
        private readonly IRepository<Stock, int> _stockRepository;
        public StockDomainService(IRepository<Stock, int> stockRepository):base(stockRepository)
        {
            _stockRepository = stockRepository;
        }
    }
}

