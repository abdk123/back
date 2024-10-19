using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Interfaces;
using Souccar.Extinsions;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Souccar.Core.Extinsions;

namespace Souccar.Core.Services.Implements
{
    public class CoreDomainService<TEntity> : DomainService, ICoreDomainService<TEntity> where TEntity : class, IEntity<int>
    {
        private readonly IRepository<TEntity,int> _repository;

        public CoreDomainService(IRepository<TEntity,int> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> CreateAsync(TEntity entity, string[] includes = null)
        {
            var id = await _repository.InsertAndGetIdAsync(entity);
            return await GetByIdAsync(id, includes);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            return _repository.GetAll().IncludeMultiple(includes)
                .FirstOrDefault<TEntity>(expression);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            return _repository.GetAll().IncludeMultiple(includes)
                .FirstOrDefaultAsync<TEntity>(expression);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            return _repository.GetAll()
                    .WhereIf(expression != null, expression)
                    .IncludeMultiple(includes);
        }
        public IQueryable<TEntity> GetAll(string[] includes = null)
        {
            return _repository.GetAll()
                    .IncludeMultiple(includes);
        }

        public async Task<TEntity> GetByIdAsync(int id, string[] includes = null)
        {
            if(includes is not null)
            {
                return await FirstOrDefaultAsync(x=>x.Id == id, includes);
            }
            return await _repository.GetAsync(id);
        }

        public Results.PagedResult<TEntity> GetPage(Expression<Func<TEntity, bool>> expression = null,int skip = 0, int take = 10, string[] includes = null, string sort = "")
        {
            var query = _repository.GetAll()
                    .WhereIf(expression != null, expression)
                    .IncludeMultiple(includes)
                    .SortList(sort);

            var totalCount = query.Count();
            query = query.Skip(skip).Take(take);
            return new Results.PagedResult<TEntity>(query.ToList(), totalCount);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, string[] includes = null)
        {
            var updatedEntity = await _repository.UpdateAsync(entity);
            return await GetByIdAsync(entity.Id, includes);
        }

    }
}
