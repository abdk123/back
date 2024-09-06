using Abp.Domain.Entities;
using Souccar.SaleManagement.Settings.Customers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.PurchaseInvoices.Receives
{
    public class ReceivingItem : Entity
    {
        public double ReceivedQuantity { get; set; }

        #region Invoice Item
        public int? InvoiceItemId { get; set; }

        [ForeignKey(nameof(InvoiceItemId))]
        public PurchaseInvoiceItem InvoiceItem { get; set; }
        #endregion

        #region Receiving Item
        public int? ReceivingId { get; set; }

        [ForeignKey(nameof(ReceivingId))]
        public Receiving Receiving { get; set; }
        #endregion

        #region Supplier
        public int? SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Customer Supplier { get; set; }
        #endregion
    }
}
