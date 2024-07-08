using Abp.Domain.Entities;
using System.Threading.Tasks;

namespace Souccar.Core.Services.Interfaces
{
    public interface IEditSouccarDomainService<TEntity, TPrimaryKey> : ICreateSouccarDomainService<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        TEntity Update(TEntity input);

        Task<TEntity> UpdateAsync(TEntity input);
    }
}
