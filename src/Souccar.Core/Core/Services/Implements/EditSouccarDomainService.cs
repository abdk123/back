using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Souccar.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Souccar.Core.Services.Implements
{
    public class EditSouccarDomainService<TEntity, TPrimaryKey> : CreateSouccarDomainService<TEntity, TPrimaryKey>, IEditSouccarDomainService<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;

        public EditSouccarDomainService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
            _repository = repository;
        }

        public virtual TEntity Update(TEntity input)
        {
            return _repository.Update(input);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity input)
        {
            return await _repository.UpdateAsync(input);
        }
    }
}
