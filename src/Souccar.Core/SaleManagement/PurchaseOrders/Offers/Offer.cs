using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.Settings.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Souccar.SaleManagement.PurchaseOrders.Offers
{
    public class Offer : FullAuditedAggregateRoot
    {
        public Offer()
        {
            OfferItems = new List<OfferItem>();
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
        public OfferStatus Status { get; set; }

        /// <summary>
        /// تاريخ نهاية العرض
        /// </summary>
        public DateTime OfferEndDate { get; set; }

        /// <summary>
        /// العملة
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// الزبون
        /// </summary>
        #region Customer
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        #endregion

        /// <summary>
        /// المورد
        /// </summary>
        #region Supplier
        public int? SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Customer Supplier { get; set; }
        #endregion

        public IList<OfferItem> OfferItems { get; set; }

        #region Getters
        public double TotalQuantity => OfferItems.Any() ? OfferItems.Sum(x => x.Quantity) : 0;
        public double TotalPrice => OfferItems.Any() ? OfferItems.Sum(x => x.TotalPrice) : 0;
        #endregion
    }
}
