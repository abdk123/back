using Abp.Dependency;
using Abp.Domain.Entities;
using System;
using System.Linq;

namespace Souccar.Core.Filter
{
    public interface IFilterBuilder<TEntity, TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
    {
        IQueryable<TEntity> Filter(IQueryable<TEntity> queryable, string filtering);
        IQueryable<TEntity> Filter(IQueryable<TEntity> queryable, FilterDto input);
        IQueryable<TEntity> Search(IQueryable<TEntity> queryable,Type typeDto ,string input);
    }
}
