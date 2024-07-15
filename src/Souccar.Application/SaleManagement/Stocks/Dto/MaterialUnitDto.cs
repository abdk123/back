using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Stocks.Dto
{
    public class MaterialUnitDto: EntityDto
    {
        public MaterialUnitDto(int id,string name, bool isSmallUnit)
        {
            Id = id;
            Name = name;
            IsSmallUnit = isSmallUnit;
        }

        public string Name { get; set; }
        public bool IsSmallUnit { get; set; }
    }
}
