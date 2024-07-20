using Abp.Events.Bus.Handlers;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Events
{
    public class CreateInvoiceEventHandler : IAsyncEventHandler<CreateInvoiceEventData>
    {
        private readonly IInvoiceDomainService _invoiceDomainService;

        public CreateInvoiceEventHandler(IInvoiceDomainService invoiceDomainService)
        {
            _invoiceDomainService = invoiceDomainService;
        }

        public async Task HandleEventAsync(CreateInvoiceEventData eventData)
        {
            var invoice = new Invoice()
            {
                Status = InvoiceStatus.NotPriced,
                OfferId = eventData.Offer.Id,
                InvoiseDetails = eventData.Offer.OfferItems.Select(x => new InvoiceItem()
                {
                    OfferItemId = x.Id
                }).ToList()
            };
            await _invoiceDomainService.InsertAsync(invoice);
        }
    }
}
