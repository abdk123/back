using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Deliveries.Dto
{
    public class UpdateDeliveryItemDto : EntityDto
    {
        public string BatchNumber { get; set; }
        public int? OfferItemId { get; set; }
        public double DeliveredQuantity { get; set; }
        public int DeliveryItemStatus { get; set; }
    }
}
