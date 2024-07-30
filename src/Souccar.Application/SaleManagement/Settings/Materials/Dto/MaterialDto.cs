using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Categories.Dto;
using Souccar.SaleManagement.Stocks.Dto;

namespace Souccar.SaleManagement.Settings.Materials.Dto
{
    public class MaterialDto : EntityDto<int>
    {
        public MaterialDto()
        {
            Stocks = new List<StockDto>();
        }
        public string Name { get; set; }
        public string Specification { get; set; }
        public int? CategoryId { get; set; }
        public CategoryForDropdownDto Category { get; set; }
        public IList<StockDto> Stocks { get; set; }
    }
}

