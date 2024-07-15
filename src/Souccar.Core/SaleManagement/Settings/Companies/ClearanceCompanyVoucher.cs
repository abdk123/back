using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.Settings.Customers;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.Settings.Companies
{
    public class ClearanceCompanyVoucher:FullAuditedAggregateRoot
    {
        /// <summary>
        /// نوع السند
        /// </summary>
        public VoucherType VoucherType { get; set; }
        /// <summary>
        /// العملة
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// مبلغ التسديد
        /// </summary>
        public double Amount { get; set; }

        public string VoucherNumber { get; set; }

        /// <summary>
        /// تاريخ السند
        /// </summary>
        public DateTime VoucherDate { get; set; }

        /// <summary>
        /// شركة التخليص
        /// </summary>
        #region ClearanceCompany
        public int? ClearanceCompanyId { get; set; }

        [ForeignKey(nameof(ClearanceCompanyId))]
        public ClearanceCompany ClearanceCompany { get; set; }
        #endregion
    }
}
