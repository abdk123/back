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
            CreateMap<Stock, StockDto>();
            CreateMap<Stock, ReadStockDto>();
            CreateMap<CreateStockDto, Stock>();
            CreateMap<Stock, CreateStockDto>();
            CreateMap<UpdateStockDto, Stock>();
            CreateMap<Stock, UpdateStockDto>();
            
        }
    }
}

