using Abp.Application.Services.Dto;
using System;

namespace Souccar.SaleManagement.Deliveries.Dto
{
    public class RejectedMaterialDto : EntityDto
    {
        public DateTime? RejectionDate { get; set; }
        public int MaterialSource { get; set; }
        public double RejectedQuantity { get; set; }
        public int? DeliveryItemId { get; set; }
        public int? SupplierId { get; set; }
    }
}
