using AutoMapper;
using Souccar.SaleManagement.Stocks.Dto;

namespace Souccar.SaleManagement.Stocks.Map
{
    public class StockHistoryMapProfile: Profile
    {
        public StockHistoryMapProfile()
        {
            CreateMap<StockHistory, StockHistoryDto>().ReverseMap();
            CreateMap<StockHistory, UpdateStockHistoryDto>().ReverseMap();
            CreateMap<StockHistory, CreateStockHistoryDto>().ReverseMap();
        }
    }
}
