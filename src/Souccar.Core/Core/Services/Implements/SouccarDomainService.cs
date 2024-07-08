using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Souccar.Core.Services.Interfaces;

namespace Souccar.Core.Services.Implements
{
    public class SouccarDomainService<TEntity, TPrimaryKey> : DeleteSouccarDomainService<TEntity, TPrimaryKey>, ISouccarDomainService<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public SouccarDomainService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }
    }
}
