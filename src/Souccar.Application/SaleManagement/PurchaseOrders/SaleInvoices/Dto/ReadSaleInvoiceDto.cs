using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Currencies;
using System;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Dto
{
    public class ReadSaleInvoiceDto : EntityDto
    {
        public string creationTime { get; set; }
        public int saleDescount { get; set; }

        /// <summary>
        /// عملة البيع
        /// </summary>
        public Currency saleCurrency { get; set; }

        /// <summary>
        /// ملاحظات الفاتورة
        /// </summary>
        public string note { get; set; }

        /// <summary>
        /// مبلغ مستلم عن الفاتورة
        /// </summary>
        public int saleTakeBalance { get; set; }

        /// <summary>
        /// الحالة
        /// </summary>
        public SaleInvoiceStatus status { get; set; }

        /// <summary>
        /// عدد الايام لاستحقاق التسديد , يتم ادخاله من المستخدم عند انشاء الفاتورة
        /// </summary>
        public int daysForPaid { get; set; }

        /// <summary>
        /// تاريخ التسديد
        /// </summary>
        public string dateForPaid { get; set; }

        /// <summary>
        /// عدد الايام المتبقية للتسديد
        /// </summary>
        public int remainingDaysForPaid => (DateTime.Parse(dateForPaid) - DateTime.Now).Days;

        /// <summary>
        /// نوع التسديد
        /// </summary>
        public PaidType paidType { get; set; }


        public string pDFFilePath { get; set; }
        public string PillURN { get; set; }

        public int? customerId { get; set; }
    }
}
