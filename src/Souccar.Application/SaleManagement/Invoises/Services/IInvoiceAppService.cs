using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Souccar.SaleManagement.Invoises.Dto;

namespace Souccar.SaleManagement.Invoises.Services
{
    public interface IInvoiceAppService : IAsyncSouccarAppService<InvoiceDto, int, FullPagedRequestDto, CreateInvoiceDto, UpdateInvoiceDto>
    {
        InvoiceDto GetWithDetail(int id);
        Task<InvoiceDto> SaveInvoiceDetail(InvoiceDto input);
        IList<InvoiceDto> GetByOfferId(int offerId);
        IList<InvoiceItemForDeliveryDto> GetForDelivery(int customerId);
    }
}

