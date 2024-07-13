namespace Souccar.SaleManagement.PurchaseInvoises
{
    public enum InvoiceStatus
    {
        /// <summary>
        /// لم يستر بعد
        /// </summary>
        NotPriced,
        /// <summary>
        /// بأنتظار الاستلام
        /// </summary>
        PendingReceived,
        /// <summary>
        /// استلام جزئي للمواد
        /// </summary>
        PartialRecieved,
        /// <summary>
        /// استلام كامل للمواد
        /// </summary>
        Received
    }
}
