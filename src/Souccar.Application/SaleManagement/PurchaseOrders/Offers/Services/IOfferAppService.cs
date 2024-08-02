using Souccar.SaleManagement.PurchaseOrders.Offers.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Services
{
    public interface IOfferAppService : IAsyncSouccarAppService<OfferDto, int, FullPagedRequestDto, CreateOfferDto, UpdateOfferDto>
    {
        IList<UpdateOfferItemDto> GetItemsByOfferId(int offerId);
        OfferDto GetOfferWithDetailId(int offerId);
        Task<OfferDto> ChangeStatusAsync(ChangeOfferStatusDto input);
        Task<string> GetPoForByOfferItemId(int offerItemId);
    }
}

