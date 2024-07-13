using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.Settings.Customers
{
    public class CustomerVoucher : FullAuditedAggregateRoot
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
        //أو الزبون
        /// </summary>
        #region Customer
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        #endregion
    }
}
