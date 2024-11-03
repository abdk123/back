using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Souccar.Core.Services.Interfaces
{
    public interface IGetSouccarDomainService<TEntity, TPrimaryKey> : ISingletonDependency
        where TEntity : class, IEntity<TPrimaryKey>
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, string[] include = null);
        IQueryable<TEntity> GetAllWithIncluding(string including, bool multiLevel = false);
        TEntity GetWithIncluding(TPrimaryKey id, Expression<Func<TEntity, object>> [] includes);
        TEntity Get(TPrimaryKey id);
        Task<TEntity> GetAsync(TPrimaryKey id);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicat);
        Task<TEntity> GetAgreggateAsync(TPrimaryKey id);
    }
}
