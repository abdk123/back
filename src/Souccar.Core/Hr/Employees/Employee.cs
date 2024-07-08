using Abp.Domain.Entities.Auditing;

namespace Souccar.Hr.Employees
{
    public class Employee : FullAuditedAggregateRoot
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
        /// الراتب
        /// </summary>
        public double Salary { get; set; }

        /// <summary>
        /// البريد الالكتروني
        /// </summary>
        public string Email { get; set; }
    }
}
