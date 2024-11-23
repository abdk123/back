using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Stocks.Dto
{
    public class MaterialUnitDto: EntityDto
    {
        public MaterialUnitDto(int id,string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
    }
}
