using Abp.Domain.Entities;
using Souccar.SaleManagement.Settings.Currencies;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.Settings.Customers
{
    public class CustomerBalance : Entity
    {
        /// <summary>
        /// العملة
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// الرصيد
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// المورد أو الزبون
        /// </summary>
        #region Customer
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        #endregion
    }
}
