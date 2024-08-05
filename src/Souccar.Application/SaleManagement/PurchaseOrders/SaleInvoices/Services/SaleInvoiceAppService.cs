using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto;
using Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Dto;
using System;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services
{
    public class SaleInvoiceAppService :
        AsyncSouccarAppService<SaleInvoice, SaleInvoiceDto, int, FullPagedRequestDto, CreateSaleInvoiceDto, UpdateSaleInvoiceDto>, ISaleInvoiceAppService
    {
        private readonly ISaleInvoiceDomainService _saleInvoiceDomainService;

        public SaleInvoiceAppService(ISaleInvoiceDomainService saleInvoiceDomainService) : base(saleInvoiceDomainService)
        {
            _saleInvoiceDomainService = saleInvoiceDomainService;
        }

        public override Task<SaleInvoiceDto> CreateAsync(CreateSaleInvoiceDto input)
        {
            input.DateForPaid = DateTime.Now.AddDays(input.DaysForPaid).ToString();
            return base.CreateAsync(input);
        }

        public async Task<SaleInvoiceDto> GetWithDetailsByIdAsync(int saleInvoiceId)
        {
            var invoice = await _saleInvoiceDomainService.GetWithDetailsByIdAsync(saleInvoiceId);
            return ObjectMapper.Map<SaleInvoiceDto>(invoice);
        }
    }
}
