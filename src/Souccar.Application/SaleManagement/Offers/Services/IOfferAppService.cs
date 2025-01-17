using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Souccar.SaleManagement.Offers.Dto;

namespace Souccar.SaleManagement.Offers.Services
{
    public interface IOfferAppService : IAsyncSouccarAppService<OfferDto, int, FullPagedRequestDto, CreateOfferDto, UpdateOfferDto>
    {
        IList<UpdateOfferItemDto> GetItemsByOfferId(int offerId);
        OfferDto GetOfferWithDetailId(int offerId);
        OfferDto GetByPoNumber(string poNumber);
        Task<OfferDto> ChangeStatusAsync(ChangeOfferStatusDto input);
        Task<string> GetPoForByOfferItemId(int offerItemId);
        Task<OfferDto> ConvertToPurchaseInvoice(ConvertToPurchaseInvoiceDto input);
        IList<OfferDto> GetByCustomerId(int customerId);
        ProfitDto GetProfit(int offerId);


    }
}

