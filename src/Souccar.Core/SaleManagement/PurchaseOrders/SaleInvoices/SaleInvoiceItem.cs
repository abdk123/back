using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Souccar.SaleManagement.PurchaseOrders.Deliveries;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices
{
    public class SaleInvoiceItem : Entity
    {
        public decimal TotalQuantity { get; set; }
        public int TotalItemPrice { get; set; }

        #region SaleInvoice
        public int? SaleInvoiceId { get; set; }

        [ForeignKey(nameof(SaleInvoiceId))]
        public SaleInvoice SaleInvoice { get; set; }
        #endregion

        #region DeliveryItem
        public int? DeliveryItemId { get; set; }

        [ForeignKey(nameof(DeliveryItemId))]
        public DeliveryItem DeliveryItem { get; set; }
        #endregion
    }
}
