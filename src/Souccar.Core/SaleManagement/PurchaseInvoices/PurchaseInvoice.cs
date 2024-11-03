using Abp.Domain.Entities.Auditing;
using Souccar.Authorization.Users;
using Souccar.SaleManagement.Offers;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.Settings.Customers;
using Souccar.SaleManagement.SupplierOffers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Souccar.SaleManagement.PurchaseInvoices
{
    public class PurchaseInvoice : FullAuditedAggregateRoot<int, User>
    {
        public PurchaseInvoice()
        {
            InvoiseDetails = new List<PurchaseInvoiceItem>();
            //Receivings = new List<Receiving>();
        }
        public PurchaseInvoiceStatus Status { get; set; }
        public string PoNumber => Offer != null ? Offer.PorchaseOrderId : string.Empty;
        public Currency Currency { get; set; }
        public PurchaseInvoiceType InvoiceType { get; set; }

        #region Offer
        public int? OfferId { get; set; }

        [ForeignKey(nameof(OfferId))]
        public Offer Offer { get; set; }
        #endregion

        #region Supplier Offer
        public int? SupplierOfferId { get; set; }

        [ForeignKey(nameof(SupplierOfferId))]
        public SupplierOffer SupplierOffer { get; set; }
        #endregion
        /// <summary>
        /// المورد
        /// </summary>
        #region Supplier
        public int? SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Customer Supplier { get; set; }
        #endregion

        public IList<PurchaseInvoiceItem> InvoiseDetails { get; set; }
        //public IList<Receiving> Receivings { get; set; }

        #region Getters
        public double TotalQuantity => InvoiseDetails.Any() ? InvoiseDetails.Sum(x => x.Quantity) : 0;
        public double TotalPrice => InvoiseDetails.Any() ? InvoiseDetails.Sum(x => x.TotalMaterilPrice) : 0;
        public double TotalReceivedQuantity => InvoiseDetails.Any() ? InvoiseDetails.Sum(x => x.ReceivedQuantity) : 0;
        #endregion
    }
}
