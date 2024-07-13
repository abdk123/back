using Abp.Domain.Entities;
using Souccar.SaleManagement.PurchaseOrders.Invoises;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries
{
    public class DeliveryItem : Entity
    {
        public string BatchNumber { get; set; }

        #region Delivery
        public int? DeliveryId { get; set; }

        [ForeignKey(nameof(DeliveryId))]
        public Delivery Delivery { get; set; }
        #endregion

        #region Invoice Item
        public int? InvoiceItemId { get; set; }

        [ForeignKey(nameof(InvoiceItemId))]
        public InvoiceItem InvoiceItem { get; set; }
        #endregion
    }
}
