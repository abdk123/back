using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Souccar.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Souccar.Core.Services.Implements
{
    public class DeleteSouccarDomainService<TEntity, TPrimaryKey> : EditSouccarDomainService<TEntity, TPrimaryKey>, IDeleteSouccarDomainService<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;

        public DeleteSouccarDomainService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
            _repository = repository;
        }
        public virtual void Delete(TPrimaryKey id)
        {
            _repository.Delete(id);
        }

        public virtual async Task DeleteAsync(TPrimaryKey id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
