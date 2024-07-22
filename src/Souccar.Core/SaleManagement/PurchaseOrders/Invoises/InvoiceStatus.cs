namespace Souccar.SaleManagement.PurchaseOrders.Invoises
{
    public enum InvoiceStatus
    {
        /// <summary>
        /// لم يسعر بعد
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
