using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.SaleManagement.Stocks.Services;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Stocks.Event
{
    public class UpdateStockEventHandler : IAsyncEventHandler<UpdateStockEventData>, ITransientDependency
    {
        private readonly IStockDomainService _stockDomainService;

        public UpdateStockEventHandler(IStockDomainService stockDomainService)
        {
            _stockDomainService = stockDomainService;
        }

        public async Task HandleEventAsync(UpdateStockEventData eventData)
        {
            var stock = await _stockDomainService.GetFirstByMaterialId(eventData.MaterialId);
            if(stock is not null)
            {
                stock.NumberInLargeUnit += eventData.NumberInLargeUnit;
                stock.NumberInSmallUnit += eventData.NumberInSmallUnit;
                stock.DamagedNumberInLargeUnit += eventData.DamagedNumberInLargeUnit;
                stock.DamagedNumberInSmallUnit += eventData.DamagedNumberInSmallUnit;
                await _stockDomainService.UpdateAsync(stock);
            }
        }
    }
}
