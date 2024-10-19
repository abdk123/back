using Abp.Domain.Entities;
using Souccar.SaleManagement.Deliveries;
using Souccar.SaleManagement.PurchaseInvoices;
using Souccar.SaleManagement.PurchaseInvoices.Receives;
using Souccar.SaleManagement.Settings.Customers;
using Souccar.SaleManagement.Settings.Materials;
using Souccar.SaleManagement.Settings.Units;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Souccar.SaleManagement.Offers
{
    public class OfferItem : Entity
    {
        /// <summary>
        /// اسم المادة من الزبون
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// اسم الوحدة من الزبون
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// الكمية    
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// سعر الافرادي للوحدة 
        /// </summary>
        public double UnitPrice { get; set; }

        /// <summary>
        /// مواصفات المادة
        /// </summary>
        public string Specefecation { get; set; }

        /// <summary>
        /// السعر الكلي
        /// </summary>
        public double TotalPrice => UnitPrice * Quantity;

        /// <summary>
        /// الإضافة من خلال الوحدة الصغيرة
        /// </summary>
        public bool AddedBySmallUnit { get; set; }

        /// <summary>
        /// المادة
        /// </summary>
        #region Material
        public int? MaterialId { get; set; }

        [ForeignKey(nameof(MaterialId))]
        public Material Material { get; set; }
        #endregion

        /// <summary>
        /// طلب المشتريات
        /// </summary>
        #region Offer
        public int? OfferId { get; set; }

        [ForeignKey(nameof(OfferId))]
        public Offer Offer { get; set; }
        #endregion

        /// <summary>
        /// الوحدة
        /// </summary>
        #region Unit
        public int? UnitId { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }
        #endregion

        /// <summary>
        /// الوحدة الصغيرة
        /// </summary>
        #region Size
        public int? SizeId { get; set; }

        [ForeignKey("SizeId")]
        public Size Size { get; set; }
        #endregion

        /// <summary>
        /// المورد
        /// </summary>
        #region Supplier
        public int? SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Customer Supplier { get; set; }
        #endregion

        /// <summary>
        /// قيمة التحويل بين العملة الصغيرة والكبيرة
        /// </summary>
        public double TransitionValue
        {
            get
            {
                var stocks = Material?.Stocks?.FirstOrDefault(x => x.SizeId == SizeId);
                if (stocks != null)
                {
                    return stocks.Count;
                }
                return 0;
            }
        }

        public double NumberInSmallUnit
        {
            get
            {
                if (AddedBySmallUnit)
                    return Quantity;
                return Quantity * TransitionValue;
            }
        }

        public IList<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; }
        //{
        //    get
        //    {
        //        if(Offer == null)
        //            return new List<PurchaseInvoiceItem>();

        //        return Offer.PurchaseInvoices
        //            .SelectMany(x => x.InvoiseDetails)
        //            .Where(x => x.OfferItemId == Id)
        //            .ToList();
        //    }
        //}

        public IList<DeliveryItem> DeliveryItems { get; set; }

        /// <summary>
        /// المواد المسلمة الموافق عليها
        /// </summary>
        public double DeliveredQuantity => DeliveryItems.Any() ? DeliveryItems.Sum(x => x.DeliveredQuantity) : 0;

    }
}
