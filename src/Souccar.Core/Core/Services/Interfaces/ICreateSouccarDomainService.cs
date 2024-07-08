using Abp.Domain.Entities;
using System.Threading.Tasks;

namespace Souccar.Core.Services.Interfaces
{
    public interface ICreateSouccarDomainService<TEntity, TPrimaryKey> : IGetSouccarDomainService<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        TEntity Insert(TEntity input);
        Task<TEntity> InsertAsync(TEntity input);
    }
}
