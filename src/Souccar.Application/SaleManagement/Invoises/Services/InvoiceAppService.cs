using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Linq;
using System;
using System.Threading.Tasks;
using Abp.Events.Bus;
using System.Collections.Generic;
using Souccar.SaleManagement.PurchaseInvoices.Services;
using Souccar.SaleManagement.PurchaseInvoices;
using Souccar.SaleManagement.Invoises.Dto;

namespace Souccar.SaleManagement.Invoises.Services
{
    public class InvoiceAppService :
        AsyncSouccarAppService<PurchaseInvoice, InvoiceDto, int, FullPagedRequestDto, CreateInvoiceDto, UpdateInvoiceDto>, IInvoiceAppService
    {
        private readonly IInvoiceDomainService _invoiceDomainService;
        public InvoiceAppService(IInvoiceDomainService invoiceDomainService) : base(invoiceDomainService)
        {
            _invoiceDomainService = invoiceDomainService;
        }

        protected override IQueryable<PurchaseInvoice> CreateFilteredQuery(FullPagedRequestDto input)
        {
            return _invoiceDomainService.GetAllWithDetail();
        }

        protected override IQueryable<PurchaseInvoice> ApplySearching(IQueryable<PurchaseInvoice> query, Type typeDto, FullPagedRequestDto input)
        {
            if (string.IsNullOrEmpty(input.Keyword))
                return query;
            return query.Where(x => x.Offer.OfferItems.Any(y => y.Supplier.FullName.Contains(input.Keyword)));
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
            invoice.Status = PurchaseInvoiceStatus.PendingReceived;
            foreach (var item in invoice.InvoiseDetails)
            {
                var dto = input.InvoiseDetails.FirstOrDefault(x => x.Id == item.Id);
                item.TotalMaterilPrice = dto.TotalMaterilPrice;
                item.Quantity = dto.Quantity;
                item.OfferItemId = dto.OfferItemId;
            }

            await _invoiceDomainService.UpdateAsync(invoice);
            return ObjectMapper.Map<InvoiceDto>(invoice);
        }

        public IList<InvoiceDto> GetByOfferId(int offerId)
        {
            var invoices = _invoiceDomainService.GetAllByOfferId(offerId).ToList();
            var dto = ObjectMapper.Map<List<InvoiceDto>>(invoices);
            return dto;
        }

        public IList<InvoiceItemForDeliveryDto> GetForDelivery(int customerId)
        {
            var list = new List<InvoiceItemForDeliveryDto>();
            var invoices = _invoiceDomainService.GetForDelivery(customerId);
            foreach (var invoice in invoices)
            {
                foreach (var item in invoice.InvoiseDetails)
                {
                    list.Add(new InvoiceItemForDeliveryDto()
                    {
                        MaterialName = item.OfferItem?.Material?.Name,
                        InvoiceItemId = item.Id,
                        NumberInSmallUnit = item.NumberInSmallUnit,
                        ReceivedQuantity = item.ReceivedQuantity,
                        RequiredQuantity = item.Quantity,
                        Unit = item.OfferItem?.Unit?.Name,
                        SmallUnit = item.OfferItem?.Size?.Name,
                        PoNumber = invoice.Offer.PorchaseOrderId,
                        TotalMaterilPrice = item.TotalMaterilPrice,
                        AddedBySmallUnit = item.OfferItem.AddedBySmallUnit,
                        InvoiceId = invoice.Id
                    });
                }
            }

            return list;
        }

        
    }
}

