using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Souccar.SaleManagement.Stocks.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Stocks.Services
{
    public interface IStockAppService : IApplicationService
    {
        PagedResultDto<StockDto> Read(PagedStockResultRequestDto input);
        public IList<StockDto> GetAll();
        Task<StockDto> GetByIdAsync(int id);
        Task<UpdateStockDto> GetForEditAsync(int id);
        Task<CreateStockDto> CreateAsync(CreateStockDto stock);
        Task<UpdateStockDto> UpdateAsync(UpdateStockDto stock);
        Task DeleteAsync(int id);
    }
}

