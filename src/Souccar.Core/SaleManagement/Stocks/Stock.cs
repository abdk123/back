using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.Settings.Categories;
using Souccar.SaleManagement.Settings.Materials;
using Souccar.SaleManagement.Settings.Stores;
using Souccar.SaleManagement.Settings.Units;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.Stocks
{
    public class Stock : FullAuditedAggregateRoot
    {
        /// <summary>
        /// باركود
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// ملاحظات
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// قيمة التحويل بين الوحدة الكبيرة والصغيرة
        /// </summary>
        public double Count { get; set; }

        /// <summary>
        /// العدد الموجود بالوحدة الكبيرة
        /// </summary>
        public double NumberInLargeUnit { get; set; }

        /// <summary>
        /// العدد التالف الموجود بالوحدة الصغيرة
        /// </summary>
        public double NumberInSmallUnit { get; set; }

        /// <summary>
        /// العدد التالف الموجود بالوحدة الكبيرة
        /// </summary>
        public double DamagedNumberInLargeUnit { get; set; }

        /// <summary>
        /// العدد الموجود بالوحدة الصغيرة
        /// </summary>
        public double DamagedNumberInSmallUnit { get; set; }

        /// <summary>
        ///  كمية الوحدة الكبيرة
        /// </summary>
        public double QuantityInLargeUnit => Math.Round(NumberInLargeUnit * Count, 1);

        /// <summary>
        /// العدد الكلي بالوحدة الصغيرة
        /// </summary>
        public double TotalNumberInSmallUnit => (QuantityInLargeUnit + NumberInSmallUnit);

        /// <summary>
        ///  كمية الوحدة الكبيرة التالفة
        /// </summary>
        public double DamagedQuantityInLargeUnit => Math.Round(DamagedNumberInLargeUnit * Count, 1);

        /// <summary>
        /// العدد الكلي بالوحدة الصغيرة التالفة
        /// </summary>
        public double DamagedTotalNumberInSmallUnit => (DamagedQuantityInLargeUnit + DamagedNumberInSmallUnit);


        #region الوحدة
        public int? UnitId { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }
        #endregion

        #region الوحدة الصغيرة
        public int? SizeId { get; set; }

        [ForeignKey("SizeId")]
        public Size Size { get; set; }
        #endregion

        #region المادة
        public int? MaterialId { get; set; }

        [ForeignKey("MaterialId")]
        public Material Material { get; set; }
        #endregion

        #region المخزن
        public int? StoreId { get; set; }

        [ForeignKey("StoreId")]
        public Store Store { get; set; }
        #endregion


    }
}
