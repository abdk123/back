using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Offers.Dto
{
    public class ReadOfferDto : EntityDto<int>
    {
        public string porchaseOrderId { get; set; }
        public string orderNumber { get; set; }
        public int status { get; set; }
        public DateTime? offerEndDate { get; set; }
        public int currency { get; set; }
        public int? customerId { get; set; }
        public int? supplierId { get; set; }
        public double totalQuantity { get; set; }
        public double totalPrice { get; set; }
    }
}

