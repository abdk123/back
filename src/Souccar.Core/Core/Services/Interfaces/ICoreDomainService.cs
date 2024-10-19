using Abp.Domain.Entities;
using Abp.Domain.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Souccar.Core.Services.Interfaces
{
    public interface ICoreDomainService<TEntity> : IDomainService where TEntity : class, IEntity<int>
    {
        Task<TEntity> CreateAsync(TEntity entity, string[] includes = null);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression, string[] includes = null);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, string[] includes = null);
        IQueryable<TEntity> GetAll(string[] includes = null);
        Task<TEntity> GetByIdAsync(int id, string[] includes = null);
        Results.PagedResult<TEntity> GetPage(Expression<Func<TEntity, bool>> expression = null, int skip = 0, int take = 10, string[] includes = null, string sort = "");
        Task<TEntity> UpdateAsync(TEntity entity, string[] includes = null);
        Task DeleteAsync(int id);
    }
}
