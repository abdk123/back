using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Deliveries.Dto
{
    public class ChangeItemStatusInputDto : EntityDto
    {
        public int Status { get; set; }
    }
}
