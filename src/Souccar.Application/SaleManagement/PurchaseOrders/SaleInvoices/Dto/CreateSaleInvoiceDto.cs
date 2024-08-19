using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Collections.Generic;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Dto
{
    public class CreateSaleInvoiceDto
    {
        public CreateSaleInvoiceDto()
        {
            SaleInvoiceItems = new List<CreateSaleInvoiceItemDto>();
        }
        public int SaleDescount { get; set; }

        /// <summary>
        /// عملة البيع
        /// </summary>
        public Currency SaleCurrency { get; set; }

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
        public string DateForPaid { get; set; }

        /// <summary>
        /// نوع التسديد
        /// </summary>
        public PaidType PaidType { get; set; }
        public string PDFFilePath { get; set; }
        public string PillURN { get; set; }
        public int? CustomerId { get; set; }
        public IList<CreateSaleInvoiceItemDto> SaleInvoiceItems { get; set; }
    }
}
