using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.PurchaseOrders.SupplierOffers;
using Souccar.SaleManagement.Settings.Customers.Dto;

namespace Souccar.SaleManagement.SupplierOffers.Dto
{
    public class SupplierOfferDto : EntityDto<int>, IHasCreationTime
    {
        public SupplierOfferDto()
        {
            SupplierOfferItems = new List<SupplierOfferItemDto>();
        }

        public int Status { get; set; }
        public DateTime? SupplierOfferEndDate { get; set; }
        public int Currency { get; set; }
        public int? SupplierId { get; set; }
        public double TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
        public CustomerDto Supplier { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ApproveDate { get; set; }
        public IList<SupplierOfferItemDto> SupplierOfferItems { get; set; }
    }
}

