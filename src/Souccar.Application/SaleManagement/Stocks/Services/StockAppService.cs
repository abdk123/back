using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Souccar.SaleManagement.Stocks.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using System.Collections;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Extensions;
using Abp.Linq.Extensions;

namespace Souccar.SaleManagement.Stocks.Services
{
    public class StockAppService : SouccarAppServiceBase, IStockAppService
    {
        private readonly IStockDomainService _stockDomainService;
        public StockAppService(IStockDomainService stockDomainService)
        {
            _stockDomainService = stockDomainService;
        }
        public PagedResultDto<StockDto> Read(PagedStockResultRequestDto input)
        {
            var query = _stockDomainService.Filter(input.Keyword);
            var totalCount = query.Count();
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);
            var data = ObjectMapper.Map<List<StockDto>>(query);
            return new PagedResultDto<StockDto>(
                totalCount,
                 data
            );
        }
        public IList<StockDto> GetAll()
        {
            var list = _stockDomainService.GetAll();
            return ObjectMapper.Map<IList<StockDto>>(list);
        }
        public async Task<StockDto> GetByIdAsync(int id)
        {
            var stock = await _stockDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<StockDto>(stock);
        }
        public async Task<UpdateStockDto> GetForEditAsync(int id)
        {
            var stock = await _stockDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateStockDto>(stock);
        }
        public async Task<CreateStockDto> CreateAsync(CreateStockDto stockDto)
        {
            var stock = ObjectMapper.Map<Stock>(stockDto);
            var createdStock = await _stockDomainService.CreateAsync(stock);
            return ObjectMapper.Map<CreateStockDto>(createdStock);
        }
        public async Task<UpdateStockDto> UpdateAsync(UpdateStockDto stockDto)
        {
            var stock = ObjectMapper.Map<Stock>(stockDto);
            var updatedStock = await _stockDomainService.UpdateAsync(stock);
            return ObjectMapper.Map<UpdateStockDto>(updatedStock);
        }
        public async Task DeleteAsync(int id)
        {
            await _stockDomainService.DeleteAsync(id);
        }
       protected virtual IQueryable<Stock> ApplyPaging(IQueryable<Stock> query, PagedStockResultRequestDto input)
       {
            var pagedInput = input as IPagedResultRequest;
            if (pagedInput != null)
             {
                return query.PageBy(pagedInput);
             }

            var limitedInput = input as ILimitedResultRequest;
            if (limitedInput != null)
             {
                return query.Take(limitedInput.MaxResultCount);
             }
            return query;
       }
       protected virtual IQueryable<Stock> ApplySorting(IQueryable<Stock> query, PagedStockResultRequestDto input)
       {
            var sortInput = input as ISortedResultRequest;
            if (sortInput != null)
             {
                if (!sortInput.Sorting.IsNullOrWhiteSpace())
                {
                    return query.OrderBy(sortInput.Sorting);
                }
             }

            if (input is ILimitedResultRequest)
             {
                return query.OrderByDescending(e => e.Id);
             }
            return query;
       }
    }
}

