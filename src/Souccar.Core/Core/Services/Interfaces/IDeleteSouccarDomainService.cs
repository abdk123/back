using Abp.Domain.Entities;
using System.Threading.Tasks;

namespace Souccar.Core.Services.Interfaces
{
    public interface IDeleteSouccarDomainService<TEntity, TPrimaryKey> : IEditSouccarDomainService<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        void Delete(TPrimaryKey id);
        Task DeleteAsync(TPrimaryKey id);
    }
}
