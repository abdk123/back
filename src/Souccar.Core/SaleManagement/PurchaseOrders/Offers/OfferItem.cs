using Abp.Domain.Entities;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.Settings.Customers;
using Souccar.SaleManagement.Settings.Materials;
using Souccar.SaleManagement.Settings.Units;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.PurchaseOrders.Offers
{
    public class OfferItem : Entity
    {
        /// <summary>
        /// الكمية    
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// سعر الافرادي للوحدة 
        /// </summary>
        public double UnitPrice { get; set; }

        /// <summary>
        /// السعر الكلي
        /// </summary>
        public double TotalPrice => UnitPrice * Quantity;

        /// <summary>
        /// الإضافة من خلال الوحدة الصغيرة
        /// </summary>
        public bool AddedBySmallUnit;

        /// <summary>
        /// المورد
        /// </summary>
        #region Customer
        public int? SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Customer Supplier { get; set; }
        #endregion

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
        #region Purchase Order
        public int? PurchaseOrderId { get; set; }

        [ForeignKey(nameof(PurchaseOrderId))]
        public Offer PurchaseOrder { get; set; }
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
    }
}
