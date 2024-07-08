using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Souccar.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Souccar.Core.Services.Implements
{
    public class GetSouccarDomainService<TEntity, TPrimaryKey>: IGetSouccarDomainService<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;

        public GetSouccarDomainService(IRepository<TEntity, TPrimaryKey> repository)
        {
            _repository = repository;
        }

        public virtual TEntity Get(TPrimaryKey id)
        {
            return _repository.Get(id);
        }


        public virtual IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual Task<TEntity> GetAgreggateAsync(TPrimaryKey id)
        {

            var properties = typeof(TEntity).GetProperties()
                .Where(x =>
                    x.PropertyType.IsGenericType &&
                    x.PropertyType.GetGenericTypeDefinition() == typeof(IList<>));

            if (properties.Any())
            {
                var lambdaExp = new List<Expression<Func<TEntity, object>>>();
                foreach (var prop in properties)
                {
                    var paramName = prop.Name.Substring(0, 2).ToLower();
                    var parameter = Expression.Parameter(typeof(TEntity), paramName);
                    var member = Expression.Property(parameter, prop.Name);
                    var finalExpression = Expression.Lambda<Func<TEntity, object>>(member, parameter);
                    lambdaExp.Add(finalExpression);
                }
                var result = _repository.GetAllIncluding(lambdaExp.ToArray()).FirstOrDefault("Id == @0", id);
                return Task.FromResult<TEntity>(result);
            }
            return GetAsync(id);
        }

        public virtual IQueryable<TEntity> GetAllWithIncluding(string including)
        {
            
            if (!string.IsNullOrEmpty(including))
            {
                var array = including.Split(',').ToList();
                var listProperties = typeof(TEntity).GetProperties()
                .Where(x =>
                    x.PropertyType.IsGenericType &&
                    x.PropertyType.GetGenericTypeDefinition() == typeof(IList<>));

                var referenceProperties = typeof(TEntity).GetProperties()
                .Where(x =>
                    x.PropertyType.IsClass && !x.PropertyType.IsAbstract);

                if (referenceProperties.Any() || listProperties.Any())
                {
                    var lambdaExp = new List<Expression<Func<TEntity, object>>>();
                    foreach (var prop in referenceProperties)
                    {
                        if (array.Any(x=> x.Trim().ToLower() == prop.Name.ToLower()))
                        {
                            var paramName = prop.Name.Substring(0, 2).ToLower();
                            var parameter = Expression.Parameter(typeof(TEntity), paramName);
                            var member = Expression.Property(parameter, prop.Name);
                            var finalExpression = Expression.Lambda<Func<TEntity, object>>(member, parameter);
                            lambdaExp.Add(finalExpression);
                        }
                    }

                    foreach (var prop in listProperties)
                    {
                        if (array.Any(x => x.Trim().ToLower() == prop.Name.ToLower()))
                        {
                            var paramName = prop.Name.Substring(0, 2).ToLower();
                            var parameter = Expression.Parameter(typeof(TEntity), paramName);
                            var member = Expression.Property(parameter, prop.Name);
                            var finalExpression = Expression.Lambda<Func<TEntity, object>>(member, parameter);
                            lambdaExp.Add(finalExpression);
                        }
                    }
                    var result = _repository.GetAllIncluding(lambdaExp.ToArray());
                    return result;
                }
            }
            
            return GetAll();
        }

        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await _repository.GetAsync(id);
        }
    }
}
