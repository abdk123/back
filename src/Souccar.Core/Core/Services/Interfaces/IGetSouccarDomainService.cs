using Abp.Domain.Entities;
using Abp.Domain.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Core.Services.Interfaces
{
    public interface IGetSouccarDomainService<TEntity, TPrimaryKey> : IDomainService
        where TEntity : class, IEntity<TPrimaryKey>
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllWithIncluding(string including);
        TEntity Get(TPrimaryKey id);
        Task<TEntity> GetAsync(TPrimaryKey id);
        Task<TEntity> GetAgreggateAsync(TPrimaryKey id);
    }
}
