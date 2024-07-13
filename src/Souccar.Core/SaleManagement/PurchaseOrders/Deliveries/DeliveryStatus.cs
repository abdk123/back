namespace Souccar.SaleManagement.Deliveries
{
    public enum DeliveryStatus
    {
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
        Returend,
        /// <summary>
        /// تم ارجاع جزء من الشحنة
        /// </summary>
        PartialReturned
    }
}
