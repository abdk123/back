using System;
using System.Collections.Generic;

namespace Souccar.SaleManagement.Deliveries.Dto
{
    public class RejectDeliveryDto
    {
        public int DeliveryId { get; set; }
        public int DeliveryItemId { get; set; }
        public DateTime? RejectionDate { get; set; }
        public IList<RejectedMaterialDto> RejectedMaterials { get; set; }

        public RejectDeliveryDto()
        {
            RejectedMaterials = new List<RejectedMaterialDto>();
        }
    }
}
