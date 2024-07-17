using Souccar.SaleManagement.PurchaseOrders.Offers.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Collections;
using System.Collections.Generic;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Services
{
    public interface IOfferAppService : IAsyncSouccarAppService<OfferDto, int, FullPagedRequestDto, CreateOfferDto, UpdateOfferDto>
    {
        IList<UpdateOfferItemDto> GetItemsByOfferId(int offerId);
    }
}

