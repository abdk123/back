using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.Settings.Customers.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Dto
{
    public class OfferDto : EntityDto<int>, IHasCreationTime
    {
        public string PorchaseOrderId { get; set; }
        public int Status { get; set; }
        public DateTime? OfferEndDate { get; set; }
        public int Currency { get; set; }
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public double TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
        public CustomerDto Customer { get; set; }
        public DateTime CreationTime { get; set; }
    }
}

