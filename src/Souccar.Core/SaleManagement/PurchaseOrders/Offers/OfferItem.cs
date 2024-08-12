using Abp.Domain.Entities;
using Souccar.SaleManagement.Settings.Materials;
using Souccar.SaleManagement.Settings.Units;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        /// قيمة التحويل بين العملة الصغيرة والكبيرة
        /// </summary>
        public double TransitionValue
        {
            get
            {
                var stocks = Material.Stocks.FirstOrDefault(x => x.SizeId == SizeId);
                if(stocks != null)
                {
                    return stocks.Count;
                }
                return 0;
            }
        }
    }
}
