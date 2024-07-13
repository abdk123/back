using Souccar.SaleManagement.PurchaseOrders.Invoises.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Services
{
    public class InvoiceAppService :
        AsyncSouccarAppService<Invoice, InvoiceDto, int, FullPagedRequestDto, CreateInvoiceDto, UpdateInvoiceDto>, IInvoiceAppService
    {
        private readonly IInvoiceDomainService _invoiceDomainService;
        public InvoiceAppService(IInvoiceDomainService invoiceDomainService) : base(invoiceDomainService)
        {
            _invoiceDomainService = invoiceDomainService;
        }
    }
}

