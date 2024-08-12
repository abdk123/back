using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace Souccar.SaleManagement.Logs.Dto
{
    public class OrderLogDto: CreationAuditedEntityDto
    {
        public OrderLogDto()
        {
            Attributes = new List<OrderLogAttributeDto>();
        }
        public OrderLogType Type { get; set; }
        public int ActionId { get; set; }
        public int OfferId { get; set; }
        public string FullName { get; set; }
        public IList<OrderLogAttributeDto> Attributes { get; set; }
    }
}
