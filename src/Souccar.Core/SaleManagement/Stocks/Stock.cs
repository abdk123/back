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
        public double ConversionValue { get; set; }

        /// <summary>
        /// الكمية الموجود بالوحدة الكبيرة
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// العدد الموجود بالوحدة الصغيرة
        /// </summary>
        public double NumberInSmallUnit => Math.Round(Quantity / ConversionValue, 1);

        /// <summary>
        /// العدد التالف الموجود بالوحدة الكبيرة
        /// </summary>
        public double DamagedQuantity { get; set; }

        /// <summary>
        /// العدد الموجود بالوحدة الصغيرة
        /// </summary>
        public double DamagedNumberInSmallUnit => Math.Round(DamagedQuantity / ConversionValue,1);
        

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
