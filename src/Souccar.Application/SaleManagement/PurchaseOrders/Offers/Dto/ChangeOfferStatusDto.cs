using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Dto
{
    public class ChangeOfferStatusDto : EntityDto
    {
        public int Status { get; set; }
        public string PorchaseOrderId { get; set; }
        public string ApproveDate { get; set; }
        public int? SupplierId { get; set; }
        public bool GenerateInvoice { get; set; }
    }
}
