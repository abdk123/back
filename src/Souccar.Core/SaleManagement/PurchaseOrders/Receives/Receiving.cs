using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.PurchaseInvoises;
using Souccar.SaleManagement.Settings.Companies;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.Settings.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Receives
{
    public class Receiving : FullAuditedAggregateRoot
    {
        #region Transport Company Info
        /// <summary>
        /// كلفة النقل للوحدة الكبيرة
        /// </summary>
        public double TransportCost { get; set; }
        public Currency TransportCostCurrency { get; set; }
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }

        #region Transport Company
        public int? TransportCompanyId { get; set; }

        [ForeignKey(nameof(TransportCompanyId))]
        public TransportCompany TransportCompany { get; set; }
        #endregion

        #endregion

        #region Clearnace Company Info
        public double ClearanceCost { get; set; }
        public Currency ClearanceCostCurrency { get; set; }

        #region Clearance Company Info
        public int? ClearanceCompanyId { get; set; }

        [ForeignKey(nameof(ClearanceCompanyId))]
        public ClearanceCompany ClearanceCompany { get; set; }
        #endregion

        #endregion

        #region Invoice
        public int? InvoiceId { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public Invoice Invoice { get; set; }
        #endregion

        /// <summary>
        /// المورد
        /// </summary>
        #region Supplier
        public int? SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Customer Supplier { get; set; }
        #endregion
    }
}
