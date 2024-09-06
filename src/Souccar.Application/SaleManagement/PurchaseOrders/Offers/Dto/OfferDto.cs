using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.Settings.Customers.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Dto
{
    public class OfferDto : EntityDto<int>, IHasCreationTime
    {
        public OfferDto()
        {
            OfferItems = new List<OfferItemDto>();
        }

        public string PorchaseOrderId { get; set; }
        public int Status { get; set; }
        public DateTime? OfferEndDate { get; set; }
        public int Currency { get; set; }
        public int? CustomerId { get; set; }
        public double TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
        public CustomerDto Customer { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ApproveDate { get; set; }
        public IList<OfferItemDto> OfferItems { get; set; }
    }
}

