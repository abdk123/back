using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Logs.Dto
{
    public class OrderLogAttributeDto : EntityDto
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
