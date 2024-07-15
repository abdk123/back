using AutoMapper;
using Souccar.Core.Dto;
using Souccar.SaleManagement.Settings.Materials;
using Souccar.SaleManagement.Stocks.Dto;

namespace Souccar.SaleManagement.Stocks.Map
{
   public class StockMapProfile : Profile
    {
        public StockMapProfile()
        {
            CreateMap<Stock, StockDto>()
                .ForMember(x => x.Material, opt => opt.MapFrom((src, des, i, context) =>
                {
                    if(src.Material != null)
                        return src.Material.Name;
                    return string.Empty;
                }));
            CreateMap<Stock, ReadStockDto>();
            CreateMap<CreateStockDto, Stock>();
            CreateMap<Stock, CreateStockDto>();
            CreateMap<UpdateStockDto, Stock>();
            CreateMap<Stock, UpdateStockDto>();
            
        }
    }
}

