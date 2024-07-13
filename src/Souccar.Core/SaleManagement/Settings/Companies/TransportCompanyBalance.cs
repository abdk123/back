using Abp.Domain.Entities;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.Settings.Customers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.Settings.Companies
{
    public class TransportCompanyBalance : Entity
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
        /// شركة التخليص
        /// </summary>
        #region TransportCompany
        public int? TransportCompanyId { get; set; }

        [ForeignKey(nameof(TransportCompanyId))]
        public Customer TransportCompany { get; set; }
        #endregion
    }
}
