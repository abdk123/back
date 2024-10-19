using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace Souccar.SaleManagement.Offers.Dto
{
    public class ChangeOfferStatusDto : EntityDto
    {
        public int Status { get; set; }
        public string PorchaseOrderId { get; set; }
        public string ApproveDate { get; set; }
        public bool GenerateInvoice { get; set; }
        public string MaterialName { get; set; }
        public string UnitName { get; set; }
    }
}
