using Abp.Domain.Entities;
using Souccar.SaleManagement.PurchaseOrders.Deliveries;
using Souccar.SaleManagement.PurchaseOrders.Offers;
using Souccar.SaleManagement.PurchaseOrders.Receives;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises
{
    public class InvoiceItem : Entity
    {
        public InvoiceItem()
        {
            ReceivingItems = new List<ReceivingItem>();
            DeliveryItems = new List<DeliveryItem>();
        }
        /// <summary>
        /// الكمية الجديدة     
        /// </summary>
        public double Quantity { get; set; } // من الممكن ان لا يكون لدى المورد المادةالمطلوبة بشكل كامل لذا سنعدل الكمية من الفاتورة ونحتفظ بالكمية المدخلة في العرض دون تعديل ككمية قديمة

        /// <summary>
        /// السعر الكلي الجديد
        /// </summary>
        public double TotalMaterilPrice { get; set; }

        /// <summary>
        /// الكمية المستلمة
        /// </summary>
        public double ReceivedQuantity => ReceivingItems.Any() ? ReceivingItems.Sum(x => x.ReceivedQuantity) : 0;

        /// <summary>
        /// المواد المسلمة الموافق عليها
        /// </summary>
        public double DeliveredQuantity => DeliveryItems.Any() ? ReceivingItems.Sum(x => x.ReceivedQuantity) : 0;

        #region Offer Item
        public int? OfferItemId { get; set; }

        [ForeignKey(nameof(OfferItemId))]
        public OfferItem OfferItem { get; set; }
        #endregion

        #region Invoice
        public int? InvoiceId { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public Invoice Invoice { get; set; }
        #endregion

        public IList<ReceivingItem> ReceivingItems { get; set; }
        public IList<DeliveryItem> DeliveryItems { get; set; }

    }
}
