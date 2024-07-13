using Abp.Domain.Entities;
using Souccar.SaleManagement.PurchaseOrders.Invoises;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.PurchaseOrders.Receives
{
    public class ReceivingItem:Entity
    {
        public double ReceivedQuantity { get; set; }

        #region Invoice Item
        public int? InvoiceItemId { get; set; }

        [ForeignKey(nameof(InvoiceItemId))]
        public InvoiceItem InvoiceItem { get; set; }
        #endregion
    }
}
