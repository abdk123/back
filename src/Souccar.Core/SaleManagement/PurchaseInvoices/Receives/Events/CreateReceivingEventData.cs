using Abp.Events.Bus;
using Souccar.SaleManagement.PurchaseInvoices;
using System.Collections.Generic;

namespace Souccar.SaleManagement.PurchaseInvoices.Receives.Events
{
    public class CreateReceivingEventData : EventData
    {
        public int InvoiceId { get; set; }
        public IList<PurchaseInvoiceItem> InvoiceItems { get; set; }
    }
}
