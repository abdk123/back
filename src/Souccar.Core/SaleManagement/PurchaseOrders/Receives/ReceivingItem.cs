using Souccar.SaleManagement.PurchaseInvoises;
using Souccar.SaleManagement.Settings.Companies;
using Souccar.SaleManagement.Settings.Currencies;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.PurchaseOrders.Receives
{
    public class ReceivingItem
    {
        public double ReceivedQuantity { get; set; }

        #region Invoice Item
        public int? InvoiceItemId { get; set; }

        [ForeignKey(nameof(InvoiceItemId))]
        public InvoiceItem InvoiceItem { get; set; }
        #endregion
    }
}
