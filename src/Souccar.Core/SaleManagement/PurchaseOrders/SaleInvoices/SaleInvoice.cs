using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.Settings.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices
{
    public class SaleInvoice : FullAuditedAggregateRoot
    {
        public SaleInvoice()
        {
            SaleInvoiceItems = new List<SaleInvoiceItem>();
        }

        /// <summary>
        /// خصم الفاتورة
        /// </summary>
        public int SaleDescount { get; set; }

        /// <summary>
        /// عملة البيع
        /// </summary>
        public Currency SaleCurrency { get; set; }

        /// <summary>
        /// مجموع سعر الفاتورة
        /// </summary>
        public int SaeltotalPrice => SaleInvoiceItems.Any() ? SaleInvoiceItems.Sum(x => x.TotalItemPrice) : 0;

        /// <summary>
        /// مجموع كميات الفاتورة
        /// </summary>
        public double InvoiceTotalQuantity => SaleInvoiceItems.Any() ? SaleInvoiceItems.Sum(x => x.TotalQuantity) : 0;

        /// <summary>
        /// ملاحظات الفاتورة
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// مبلغ مستلم عن الفاتورة
        /// </summary>
        public int SaleTakeBalance { get; set; }

        /// <summary>
        /// الحالة
        /// </summary>
        public SaleInvoiceStatus Status { get; set; }

        /// <summary>
        /// عدد الايام لاستحقاق التسديد , يتم ادخاله من المستخدم عند انشاء الفاتورة
        /// </summary>
        public int DaysForPaid { get; set; }

        /// <summary>
        /// تاريخ التسديد
        /// </summary>
        public DateTime DateForPaid { get; set; }

        /// <summary>
        /// عدد الايام المتبقية للتسديد
        /// </summary>
        public int RemainingDaysForPaid => (DateForPaid - DateTime.Now).Days;

        /// <summary>
        /// نوع التسديد
        /// </summary>
        public PaidType PaidType { get; set; }


        public string PDFFilePath { get; set; }
        public string PillURN { get; set; }

        public bool Notified { get; set; }

        #region Cusromer
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        #endregion

        public IList<SaleInvoiceItem> SaleInvoiceItems { get; set; }
    }
}
