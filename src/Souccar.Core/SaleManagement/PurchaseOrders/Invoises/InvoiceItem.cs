using Abp.Domain.Entities;
using Souccar.SaleManagement.PurchaseOrders.Offers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises
{
    public class InvoiceItem : Entity
    {
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
        public double ReceivedQuantity { get; set; }

        #region Offer Item
        public int? OfferItemId { get; set; }

        [ForeignKey(nameof(OfferItemId))]
        public OfferItem OfferItem { get; set; }
        #endregion

    }
}
