using Abp.Domain.Entities.Auditing;
using Souccar.Authorization.Users;
using Souccar.SaleManagement.Settings.Companies;
using Souccar.SaleManagement.Settings.Currencies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Souccar.SaleManagement.PurchaseInvoices.Receives
{
    public class Receiving : FullAuditedAggregateRoot<int, User>
    {
        public Receiving()
        {
            ReceivingItems = new List<ReceivingItem>();
        }
        public DateTime? ReceivingDate { get; set; }
        public string Note { get; set; }

        #region Transport Company Info
        /// <summary>
        /// كلفة النقل للوحدة الكبيرة
        /// </summary>
        public double TransportCost { get; set; }
        public Currency TransportCostCurrency { get; set; }
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public double TotalReceivedQuantity => ReceivingItems.Any() ? ReceivingItems.Sum(x => x.ReceivedQuantity) : 0;

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
        public PurchaseInvoice Invoice { get; set; }
        #endregion

        

        public virtual IList<ReceivingItem> ReceivingItems { get; set; }

    }
}
