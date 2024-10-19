using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.Settings.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Souccar.SaleManagement.Deliveries
{
    public class Delivery : FullAuditedAggregateRoot
    {
        public Delivery()
        {
            DeliveryItems = new List<DeliveryItem>();
        }
        public double TransportCost { get; set; }
        public Currency TransportCostCurrency { get; set; }
        public string DriverName { get; set; }
        public string GrNumber { get; set; }
        public DateTime? ApproveDate { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverPhoneNumber { get; set; }
        public DeliveryStatus Status { get; set; }

        /// <summary>
        /// الكمية المنقولة
        /// </summary>
        public double TotalApprovedQuantity => DeliveryItems.Any() ? DeliveryItems.Sum(x => x.ApprovedQuantity) : 0;
        public double TotalRejectedQuantity => DeliveryItems.Any() ? DeliveryItems.Sum(x => x.RejectedQuantity) : 0;
        public double TotalPrice => DeliveryItems.Any() ? DeliveryItems.Sum(x => x.TotalPrice) : 0;

        #region Customer
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        #endregion

        public IList<DeliveryItem> DeliveryItems { get; set; }
    }
}
