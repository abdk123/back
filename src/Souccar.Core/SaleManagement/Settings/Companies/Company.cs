using Abp.Domain.Entities.Auditing;

namespace Souccar.SaleManagement.Settings.Companies
{
    public class Company: FullAuditedAggregateRoot
    {
        /// <summary>
        /// اسم الشركة
        /// </summary>
        public string Name { get; set; }

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
    }
}
