using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Abp.UI;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises.Events
{
    public class CreateInvoiceEventHandler : IAsyncEventHandler<CreateInvoiceEventData>,ITransientDependency
    {
        private readonly IInvoiceDomainService _invoiceDomainService;

        public CreateInvoiceEventHandler(IInvoiceDomainService invoiceDomainService)
        {
            _invoiceDomainService = invoiceDomainService;
        }

        public async Task HandleEventAsync(CreateInvoiceEventData eventData)
        {
            Invoice existedInvoice = await _invoiceDomainService.GetByOfferIdAsync(eventData.OfferId);
            if(existedInvoice is not null)
            {
                throw new UserFriendlyException("ThereIsAnotherInvoiceForThisOffer");
            }
            var invoice = new Invoice()
            {
                Status = InvoiceStatus.NotPriced,
                OfferId = eventData.OfferId,
                InvoiseDetails = eventData.OfferItems.Select(x => new InvoiceItem()
                {
                    OfferItemId = x.Id,
                    Quantity = x.Quantity,
                    TotalMaterilPrice = x.TotalPrice
                }).ToList()
            };
            await _invoiceDomainService.InsertAsync(invoice);
        }
    }
}
