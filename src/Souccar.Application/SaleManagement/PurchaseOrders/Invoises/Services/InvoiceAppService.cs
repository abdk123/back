using Souccar.SaleManagement.PurchaseOrders.Invoises.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Linq;
using System;
using System.Threading.Tasks;
using Abp.Events.Bus;
using Souccar.SaleManagement.PurchaseOrders.Invoises.Events;

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

        protected override IQueryable<Invoice> CreateFilteredQuery(FullPagedRequestDto input)
        {
            return _invoiceDomainService.GetAllWithDetail();
        }

        protected override IQueryable<Invoice> ApplySearching(IQueryable<Invoice> query, Type typeDto, FullPagedRequestDto input)
        {
            if (string.IsNullOrEmpty(input.Keyword))
                return query;
            return query.Where(x => x.Offer.Supplier.FullName.Contains(input.Keyword));
        }

        public InvoiceDto GetWithDetail(int id)
        {
            var invoice = _invoiceDomainService.GetWithDetail(id);
            return ObjectMapper.Map<InvoiceDto>(invoice);
        }

        public async Task<InvoiceDto> SaveInvoiceDetail(InvoiceDto input)
        {
            var invoice = _invoiceDomainService.GetAllWithIncluding("InvoiseDetails")
                .FirstOrDefault(x => x.Id == input.Id);
            invoice.Status = InvoiceStatus.PendingReceived;
            foreach (var item in invoice.InvoiseDetails)
            {
                var dto = input.InvoiseDetails.FirstOrDefault(x => x.Id == item.Id);
                item.TotalMaterilPrice = dto.TotalMaterilPrice;
                item.Quantity = dto.Quantity;
            }

            await _invoiceDomainService.UpdateAsync(invoice);
            return ObjectMapper.Map<InvoiceDto>(invoice);
        }

        public async Task<InvoiceDto> GetByOfferId(int offerId)
        {
            var invoice = _invoiceDomainService.GetByOfferIdAsync(offerId);
            return ObjectMapper.Map<InvoiceDto>(invoice);
        }
    }
}

