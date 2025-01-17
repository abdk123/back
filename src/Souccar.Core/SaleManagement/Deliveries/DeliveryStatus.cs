﻿namespace Souccar.SaleManagement.Deliveries
{
    public enum DeliveryStatus
    {
        /// <summary>
        /// بأنتظار الموافقة
        /// </summary>
        WaitingApprove,
        /// <summary>
        /// موافق عليه
        /// </summary>
        Approved,
        /// <summary>
        /// تم ارسال الشحنة
        /// </summary>
        Shipped,
        /// <summary>
        /// تم استلام كامل الشحنة من الزبون
        /// </summary>
        Delivered,
        /// <summary>
        /// تم إرجاع الشحنة وعدم استلاما
        /// </summary>
        Rejected,
        /// <summary>
        /// تم ارجاع جزء من الشحنة
        /// </summary>
        PartialRejected,
        /// <summary>
        /// تم إنشاء فاتورة مبيعات
        /// </summary>
        CreateSaleInoice,
        /// <summary>
        /// تم الدفع
        /// </summary>
        Paid,
    }
}
