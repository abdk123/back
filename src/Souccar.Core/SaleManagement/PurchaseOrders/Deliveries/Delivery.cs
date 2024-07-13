using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.Settings.Customers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries
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
        public string VehicleNumber { get; set; }
        public string DriverPhoneNumber { get; set; }
        public DeliveryStatus Status { get; set; }

        /// <summary>
        /// الكمية المنقولة
        /// </summary>
        public double TransportedQuantity { get; set; }

        #region Customer
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        #endregion

        public IList<DeliveryItem> DeliveryItems { get; set; }
    }
}
