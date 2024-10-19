using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.PurchaseInvoices;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.Settings.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Souccar.SaleManagement.SupplierOffers
{
    public class SupplierOffer : FullAuditedAggregateRoot
    {
        public SupplierOffer()
        {
            SupplierOfferItems = new List<SupplierOfferItem>();
            PurchaseInvoices = new List<PurchaseInvoice>();
        }

        /// <summary>
        /// PO
        /// </summary>
        public string PorchaseOrderId { get; set; }

        /// <summary>
        /// تسلسل العرض
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// ملاحظات العرض
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// حالة العرض
        /// </summary>
        public SupplierOfferStatus Status { get; set; }

        /// <summary>
        /// تاريخ نهاية العرض
        /// </summary>
        public DateTime SupplierOfferEndDate { get; set; }

        /// <summary>
        /// تاريخ الموافقة على العرض
        /// </summary>
        public DateTime? ApproveDate { get; set; }

        /// <summary>
        /// العملة
        /// </summary>
        public Currency Currency { get; set; }

        public IList<SupplierOfferItem> SupplierOfferItems { get; set; }
        public IList<PurchaseInvoice> PurchaseInvoices { get; set; }

        /// <summary>
        /// الزبون
        /// </summary>
        #region Supplier
        public int? SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Customer Supplier { get; set; }
        #endregion

        #region Getters
        public double TotalQuantity => SupplierOfferItems.Any() ? SupplierOfferItems.Sum(x => x.Quantity) : 0;
        public double TotalPrice => SupplierOfferItems.Any() ? SupplierOfferItems.Sum(x => x.TotalPrice) : 0;
        #endregion
    }
}
