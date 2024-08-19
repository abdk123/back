namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices
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
