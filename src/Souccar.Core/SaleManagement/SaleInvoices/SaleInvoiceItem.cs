using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Souccar.SaleManagement.Deliveries;

namespace Souccar.SaleManagement.SaleInvoices
{
    public class SaleInvoiceItem : Entity
    {
        public double TotalQuantity { get; set; }
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
