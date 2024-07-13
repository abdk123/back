using Souccar.SaleManagement.PurchaseOrders.Offers.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Services
{
    public interface IOfferAppService : IAsyncSouccarAppService<OfferDto, int, FullPagedRequestDto, CreateOfferDto, UpdateOfferDto>
    {
    }
}

