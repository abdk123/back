using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.PurchaseOrders.Offers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Souccar.SaleManagement.PurchaseOrders.Invoises
{
    public class Invoice : FullAuditedAggregateRoot
    {
        public Invoice()
        {
            InvoiseDetails = new List<InvoiceItem>();
        }
        public InvoiceStatus Status { get; set; }

        #region Offer
        public int? OfferId { get; set; }

        [ForeignKey(nameof(OfferId))]
        public Offer Offer { get; set; }
        #endregion

        public IList<InvoiceItem> InvoiseDetails { get; set; }

        #region Getters
        public double TotalQuantity => InvoiseDetails.Any() ? InvoiseDetails.Sum(x => x.Quantity) : 0;
        public double TotalPrice => InvoiseDetails.Any() ? InvoiseDetails.Sum(x => x.TotalMaterilPrice) : 0;
        #endregion
    }
}
