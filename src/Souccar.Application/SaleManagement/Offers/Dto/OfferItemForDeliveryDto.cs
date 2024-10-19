using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Offers.Dto
{
    public class OfferItemForDeliveryDto
    {
        public int? OfferId { get; set; }
        public int? OfferItemId { get; set; }
        public string MaterialName { get; set; }
        public double Quantity { get; set; }
        public double TotalPrice { get; set; }
        public double DeliveredQuantity { get; set; }
        public double NumberInSmallUnit { get; set; }
        public bool AddedBySmallUnit { get; set; }
        public string Unit { get; set; }
        public string SmallUnit { get; set; }
        public string PoNumber { get; set; }
    }
}
