using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Abp.UI;
using Souccar.SaleManagement.PurchaseInvoices.Receives.Services;
using Souccar.SaleManagement.PurchaseInvoices.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseInvoices.Receives.Events
{
    public class CreateReceivingEventHandler : IAsyncEventHandler<CreateReceivingEventData>, ITransientDependency
    {
        private readonly IReceivingDomainService _receivingDomainService;
        private readonly IInvoiceDomainService _invoiceDomainService;

        public CreateReceivingEventHandler(IReceivingDomainService receivingDomainService, IInvoiceDomainService invoiceDomainService)
        {
            _receivingDomainService = receivingDomainService;
            _invoiceDomainService = invoiceDomainService;
        }

        public async Task HandleEventAsync(CreateReceivingEventData eventData)
        {
            var invoice = _invoiceDomainService.GetWithDetail(eventData.InvoiceId);

            var receiving = new Receiving()
            {
                InvoiceId = eventData.InvoiceId,
                ReceivingItems = eventData.InvoiceItems.Select(x => new ReceivingItem()
                {
                    InvoiceItemId = x.Id
                }).ToList()
            };
            await _receivingDomainService.InsertAsync(receiving);
        }
    }
}
