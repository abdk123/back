using Souccar.SaleManagement.SupplierOffers.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.SupplierOffers.Services
{
    public interface ISupplierOfferAppService : IAsyncSouccarAppService<SupplierOfferDto, int, FullPagedRequestDto, CreateSupplierOfferDto, UpdateSupplierOfferDto>
    {
        IList<UpdateSupplierOfferItemDto> GetItemsBySupplierOfferId(int supplierOfferId);
        SupplierOfferDto GetSupplierOfferWithDetailId(int supplierOfferId);
        Task<SupplierOfferDto> ConvertToPurchaseInvoice(ConvertSupplierOfferToPurchaseInvoiceDto input);
    }
}

