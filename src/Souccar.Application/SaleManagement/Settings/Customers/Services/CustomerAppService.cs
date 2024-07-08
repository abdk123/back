using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Souccar.SaleManagement.Settings.Customers.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using System.Collections;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Extensions;
using Abp.Linq.Extensions;

namespace Souccar.SaleManagement.Settings.Customers.Services
{
    public class CustomerAppService : SouccarAppServiceBase, ICustomerAppService
    {
        private readonly ICustomerDomainService _customerDomainService;
        public CustomerAppService(ICustomerDomainService customerDomainService)
        {
            _customerDomainService = customerDomainService;
        }
        public PagedResultDto<CustomerDto> Read(PagedCustomerResultRequestDto input)
        {
            var query = _customerDomainService.Filter(input.Keyword);
            var totalCount = query.Count();
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);
            var data = ObjectMapper.Map<List<CustomerDto>>(query);
            return new PagedResultDto<CustomerDto>(
                totalCount,
                 data
            );
        }
        public IList<CustomerDto> GetAll()
        {
            var list = _customerDomainService.GetAll();
            return ObjectMapper.Map<IList<CustomerDto>>(list);
        }
        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await _customerDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<CustomerDto>(customer);
        }
        public async Task<UpdateCustomerDto> GetForEditAsync(int id)
        {
            var customer = await _customerDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateCustomerDto>(customer);
        }
        public async Task<CreateCustomerDto> CreateAsync(CreateCustomerDto customerDto)
        {
            var customer = ObjectMapper.Map<Customer>(customerDto);
            var createdCustomer = await _customerDomainService.CreateAsync(customer);
            return ObjectMapper.Map<CreateCustomerDto>(createdCustomer);
        }
        public async Task<UpdateCustomerDto> UpdateAsync(UpdateCustomerDto customerDto)
        {
            var customer = ObjectMapper.Map<Customer>(customerDto);
            var updatedCustomer = await _customerDomainService.UpdateAsync(customer);
            return ObjectMapper.Map<UpdateCustomerDto>(updatedCustomer);
        }
        public async Task DeleteAsync(int id)
        {
            await _customerDomainService.DeleteAsync(id);
        }
       protected virtual IQueryable<Customer> ApplyPaging(IQueryable<Customer> query, PagedCustomerResultRequestDto input)
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
       protected virtual IQueryable<Customer> ApplySorting(IQueryable<Customer> query, PagedCustomerResultRequestDto input)
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

