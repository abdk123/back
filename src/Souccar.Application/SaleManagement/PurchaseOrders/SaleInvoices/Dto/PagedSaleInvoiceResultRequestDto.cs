using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Dto
{
    public class PagedSaleInvoiceResultRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}
