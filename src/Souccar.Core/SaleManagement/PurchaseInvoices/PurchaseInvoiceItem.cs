using Abp.Domain.Entities;
using Souccar.SaleManagement.PurchaseInvoices.Receives;
using Souccar.SaleManagement.PurchaseOrders.Offers;
using Souccar.SaleManagement.PurchaseOrders.SupplierOffers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Souccar.SaleManagement.PurchaseInvoices
{
    public class PurchaseInvoiceItem : Entity
    {
        public PurchaseInvoiceItem()
        {
            ReceivingItems = new List<ReceivingItem>();
        }
        /// <summary>
        /// الكمية الجديدة     
        /// </summary>
        public double Quantity { get; set; } // من الممكن ان لا يكون لدى المورد المادةالمطلوبة بشكل كامل لذا سنعدل الكمية من الفاتورة ونحتفظ بالكمية المدخلة في العرض دون تعديل ككمية قديمة


        #region Offer Item
        public int? OfferItemId { get; set; }

        [ForeignKey(nameof(OfferItemId))]
        public OfferItem OfferItem { get; set; }
        #endregion

        #region Supplier Offer Item
        public int? SupplierOfferItemId { get; set; }

        [ForeignKey(nameof(SupplierOfferItemId))]
        public SupplierOfferItem SupplierOfferItem { get; set; }
        #endregion

        #region Invoice
        public int? InvoiceId { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public PurchaseInvoice Invoice { get; set; }
        #endregion

        #region
        public IList<ReceivingItem> ReceivingItems { get; set; }
        //{
        //    get
        //    {
        //        if (Invoice == null)
        //            return new List<ReceivingItem>();

        //        return Invoice.Receivings
        //            .SelectMany(x => x.ReceivingItems)
        //            .Where(x => x.InvoiceItemId == Id)
        //            .ToList();
        //    }
        //}

        /// <summary>
        /// السعر الكلي الجديد
        /// </summary>
        public double TotalMaterilPrice { get; set; }

        /// <summary>
        /// الكمية المستلمة
        /// </summary>
        public double ReceivedQuantity => ReceivingItems.Any() ? ReceivingItems.Sum(x => x.ReceivedQuantity) : 0;

        /// <summary>
        /// العدد بالوحدة الصغيرة
        /// </summary>
        public double NumberInSmallUnit
        {
            get
            {
                if (OfferItem == null)
                    return 0;
                if (OfferItem.AddedBySmallUnit)
                {
                    return OfferItem.TransitionValue > 0 ? Math.Round(Quantity / OfferItem.TransitionValue, 1) : 0;
                }

                return Quantity;
            }
        }

        #endregion
    }
}
