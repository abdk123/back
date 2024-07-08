using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Souccar.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Souccar.Core.Services.Implements
{
    public class CreateSouccarDomainService<TEntity, TPrimaryKey> : GetSouccarDomainService<TEntity, TPrimaryKey>, ICreateSouccarDomainService<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;

        public CreateSouccarDomainService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
            _repository = repository;
        }
        public virtual TEntity Insert(TEntity input)
        {
            var id = _repository.InsertAndGetId(input);
            return Get(id);
        }

        public virtual async Task<TEntity> InsertAsync(TEntity input)
        {
            var id = await _repository.InsertAndGetIdAsync(input);
            return await GetAsync(id);
        }
    }
}
