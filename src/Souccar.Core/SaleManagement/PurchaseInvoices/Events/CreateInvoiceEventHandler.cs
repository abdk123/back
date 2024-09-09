using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Abp.UI;
using Souccar.SaleManagement.PurchaseInvoices.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseInvoices.Events
{
    public class CreateInvoiceEventHandler : IAsyncEventHandler<CreateInvoiceEventData>, ITransientDependency
    {
        private readonly IInvoiceDomainService _invoiceDomainService;

        public CreateInvoiceEventHandler(IInvoiceDomainService invoiceDomainService)
        {
            _invoiceDomainService = invoiceDomainService;
        }

        public async Task HandleEventAsync(CreateInvoiceEventData eventData)
        {
            //PurchaseInvoice existedInvoice = await _invoiceDomainService.GetByOfferIdAsync(eventData.OfferId, eventData.SupplierId);
            //if (existedInvoice is not null)
            //{
            //    throw new UserFriendlyException("ThereIsAnotherInvoiceForThisSupplier");
            //}
            var invoice = new PurchaseInvoice()
            {
                Status = PurchaseInvoiceStatus.NotPriced,
                OfferId = eventData.OfferId,
                SupplierId = eventData.SupplierId,
                Currency = eventData.Currency,
                InvoiseDetails = eventData.OfferItemsIds.Select(offerItemId => new PurchaseInvoiceItem()
                {
                    OfferItemId = offerItemId,
                }).ToList()
            };
            await _invoiceDomainService.InsertAsync(invoice);
        }
    }
}
