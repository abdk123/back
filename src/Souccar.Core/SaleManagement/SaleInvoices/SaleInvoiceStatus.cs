namespace Souccar.SaleManagement.SaleInvoices
{
    public enum SaleInvoiceStatus
    {
        /// <summary>
        /// فاتورة مبيعات بدون تسديد
        /// </summary>
        UnpaidSalesInvoice,

        /// <summary>
        /// فاتورة مبيعات سديد
        /// </summary>
        Paid,
        DelayInPaid
    }
}
