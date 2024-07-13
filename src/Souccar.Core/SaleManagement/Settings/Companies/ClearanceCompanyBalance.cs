using Abp.Domain.Entities;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.Settings.Customers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.Settings.Companies
{
    public class ClearanceCompanyBalance:Entity
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
        #region ClearanceCompany
        public int? ClearanceCompanyId { get; set; }

        [ForeignKey(nameof(ClearanceCompanyId))]
        public Customer ClearanceCompany { get; set; }
        #endregion
    }
}
