using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.Collections.Generic;

namespace Souccar.Core.Results
{
    public class PagedResult<TEntity> : IPagedResult<TEntity> where TEntity : class, IEntity<int>
    {
        public PagedResult(IReadOnlyList<TEntity> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }

        public IReadOnlyList<TEntity> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
