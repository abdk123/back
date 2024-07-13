using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Stocks.Services
{
    public class StockDomainService : SouccarDomainService<Stock, int>,IStockDomainService
    {
        private readonly IRepository<Stock, int> _stockRepository;
        public StockDomainService(IRepository<Stock, int> stockRepository):base(stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<List<Stock>> GetAllByMaterialIdAsync(int materialId)
        {
            var stocks = await Task.FromResult(_stockRepository.GetAll().Where(x => x.MaterialId == materialId).ToList());
            return stocks;
        }
    }
}

