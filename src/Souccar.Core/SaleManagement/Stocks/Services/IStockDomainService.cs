using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Stocks.Services
{
    public interface IStockDomainService : ISouccarDomainService<Stock, int>
    {
        Task<List<Stock>> GetAllByMaterialIdAsync(int materialId);
    }
}

