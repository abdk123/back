using Abp.Domain.Entities;
using Abp.Domain.Services;
using System.Threading.Tasks;

namespace Souccar.Core.Services.Interfaces
{
    public interface ISouccarDomainService<TEntity, TPrimaryKey> : IDeleteSouccarDomainService<TEntity, TPrimaryKey>, IDomainService
        where TEntity : class, IEntity<TPrimaryKey>
    {
        
    }
}
