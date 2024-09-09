using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Currencies;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Dto
{
    public class PoOfferDto : EntityDto
    {
        public string PorchaseOrderId { get; set; }
        public Currency Currency { get; set; }

    }
}
