using Abp.Domain.Entities.Auditing;

namespace Souccar.SaleManagement.Settings.Customers
{
    public class Customer : FullAuditedAggregateRoot
    {
        /// <summary>
        /// الاسم الكامل
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// رقم الهاتف
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// العنوان
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// الرصيد بالدولار
        /// </summary>
        public double BalanceInDollar { get; set; }

        /// <summary>
        /// الرصيد بالدينار
        /// </summary>
        public double BalanceInDinar { get; set; }

        /// <summary>
        /// الرصيد الاولي بالدولار (الافتتاحي)
        /// </summary>
        public double InitialBalance { get; set; }

        /// <summary>
        /// النوع 
        /// </summary>
        public CustomerType Type { get; set; }
    }
}
