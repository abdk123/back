using System;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.SaleManagement.Stocks.Dto
{
    public class MaterialBalanceDto
    {
        public MaterialBalanceDto()
        {
            Stocks = new List<StockBalanceDto>();
        }
        public double TotalQuantity => Stocks.Any() ? Stocks.Sum(x => x.Quantity) : 0;
        public int MaterialId { get; set; }
        public string UnitName { get; set; }
        public string Name { get; set; }
        public double Price => Stocks.Any() ? Math.Round(Stocks.Average(x => x.Price)) : 0;
        public string StockInfo 
        { 
            get 
            {
                if (!Stocks.Any())
                    return string.Empty;

                var info = "";
                foreach (var stock in Stocks)
                {
                    info += $"({stock.Quantity} {stock.SizeName}) ";
                }

                return info.Substring(0, Stocks.Count - 1);
            } 
        }
        public IList<StockBalanceDto> Stocks { get; set; }

    }
}
