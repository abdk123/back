using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Souccar.Core.Filter
{
    internal class NullFilterBuilder<TEntity, TPrimaryKey> : IFilterBuilder<TEntity, TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
    {
        public static NullFilterBuilder<TEntity, TPrimaryKey> Instance { get; } = new NullFilterBuilder<TEntity, TPrimaryKey>();

        public IQueryable<TEntity> Search(IQueryable<TEntity> queryable,Type typeDto ,string keyword)
        {
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var filterDto = new FilterDto() { Condition = "or" };
                var properties = typeof(TEntity).GetProperties().Where(x=>x.PropertyType == typeof(string) && x.CanWrite == true);
                var propertiesDto = typeDto.GetProperties().Where(x => x.PropertyType == typeof(string));
                foreach (var propertyInfo in propertiesDto)
                {
                    if(properties.Any(x=>x.Name == propertyInfo.Name))
                    {
                        filterDto.Rules.Add(new FilterRuleDto()
                        {
                            Field = propertyInfo.Name,
                            Operator = "Contains",
                            Value = keyword
                        });
                    }
                }

                queryable = Filter(queryable, filterDto);
            }

            return queryable;
        }

        public IQueryable<TEntity> Filter(IQueryable<TEntity> queryable, FilterDto input)
        {
            if (input != null && input.Rules.Any())
            {
                // Get all filter values as array (needed by the Where method of Dynamic Linq)
                var values = GetValues(input.Rules);

                // Create a predicate expression e.g. Field1 = @0 And Field2 > @1
                string predicate = GetExpression(input);

                // Use the Where method of Dynamic Linq to filter the data
                queryable = queryable.Where(predicate, values);
            }

            return queryable;
        }

        string GetExpression(FilterDto input)
        {
            string predicate = "";
            if (input.Rules.Any())
            {
                var index = -1;
                for (var i = 0; i < input.Rules.Count; i++)
                {
                    if (input.Rules[i].Operator != "in" && input.Rules[i].Operator != "not in")
                    {
                        string comparison = input.Rules[i].Operator;
                        string condition = i < (input.Rules.Count - 1) ? input.Condition : "";

                        if (comparison == "starts with" || comparison == "ends with" || comparison.ToLower() == "contains")
                        {
                            comparison = operators[comparison.ToLower()];
                            predicate += String.Format("{0}.{1}(@{2}) {3} ", input.Rules[i].Field, comparison, i, condition);
                        }
                        else
                        {
                            predicate += String.Format("{0} {1} @{2} {3} ", input.Rules[i].Field, comparison, i, condition);
                        }

                        index++;
                    }
                }

                var conplexRules = input.Rules.Where(x => x.Operator == "in" || x.Operator == "not in").ToList();
                if (conplexRules.Any())
                {
                    for (var y = 0; y < conplexRules.Count; y++)
                    {
                        predicate += " (";

                        var count = conplexRules[y].Value.ToString().Split(',').Count();
                        var comparison = conplexRules[y].Operator == "in" ? "=" : "!=";
                        for (var i = 1; i <= count; i++)
                        {
                            var subCondition = conplexRules[y].Operator == "in" ? "or" : "and";
                            if(i == count)
                            {
                                subCondition = "";
                            }
                            predicate += String.Format("{0} {1} @{2} {3} ", conplexRules[y].Field, comparison, i + index, subCondition);
                            
                        }

                        index = index + count;
                        if(y < (conplexRules.Count - 1))
                        {
                            predicate += String.Format(" ) {0} ", input.Condition);
                        }
                        else
                        {
                            predicate += ")";
                        }
                    }
                    
                }
                
            }

            return predicate;
        }

        private string GetExpressionForMultiValue(string comparison, FilterRuleDto rule)
        {
            string predicate = string.Empty;
            var count = rule.Value.ToString().Split(',').Count();
            var logic = comparison == "in" ? "=" : "!=";
            
            for(var i = 0; i < count; i++)
            {
                predicate += String.Format("{0} {1} (@{2}) {3} ", rule.Field, logic, i, "and");
            }

            return predicate;
        }
        object[] GetValues(IList<FilterRuleDto> rules)
        {
            var ruleValues = new List<object>();
            var simpleRules = rules.Where(x => x.Operator != "in" && x.Operator != "not in").ToList();
            var complexRules = rules.Where(x => x.Operator == "in" || x.Operator == "not in").ToList();

            ruleValues.AddRange(simpleRules.Select(x=>x.Value));

            foreach (var rule in complexRules)
            {
                var values2 = rule.Value.ToString();
                var values = rule.Value.ToString().Replace("[","").Replace("]", "").Split(',').Select(x => x.Trim());
                ruleValues.AddRange(values);
            }
            
            return ruleValues.ToArray();
        }

        IList<FilterInput> Initial(string filtering)
        {
            var filters = new List<FilterInput>();
            var inputs = filtering.Split(",");
            if (inputs.Any())
            {
                foreach (var input in inputs)
                {
                    var array = input.Split(":");
                    if (array.Any() && array.Length >= 3)
                    {
                        filters.Add(new FilterInput(array));
                    }
                }
            }
            return filters;
        }

        public IQueryable<TEntity> Filter(IQueryable<TEntity> queryable, string filtering)
        {
            var filters = Initial(filtering);
            if (filters.Any())
            {
                // Get all filter values as array (needed by the Where method of Dynamic Linq)
                var values = filters.Select(f => f.Value).ToArray();

                // Create a predicate expression e.g. Field1 = @0 And Field2 > @1
                string predicate = ToExpression(filters);

                // Use the Where method of Dynamic Linq to filter the data
                queryable = queryable.Where(predicate, values);
            }

            return queryable;
        }

        string ToExpression(IList<FilterInput> filters)
        {
            string predicate = "";
            if (filters != null && filters.Any())
            {
                for (var i = 0; i < filters.Count; i++)
                {
                    string comparison = operators[filters[i].Operator];

                    if (comparison == "StartsWith" || comparison == "EndsWith" || comparison == "Contains")
                    {

                        predicate += String.Format("{0}.{1}(@{2}) {3} ", filters[i].Field, comparison, i, filters[i].Logic);
                    }

                    //else if (comparison =="in" || comparison =="not in")
                    //{
                    //    predicate +=
                    //}
                    else
                    {
                        predicate += String.Format("{0} {1} @{2} {3} ", filters[i].Field, comparison, i, filters[i].Logic);
                    }
                }
            }

            return predicate;
        }

        
        private readonly IDictionary<string, string> operators = new Dictionary<string, string>
        {
            {"eq", "="},
            {"neq", "!="},
            {"lt", "<"},
            {"lte", "<="},
            {"gt", ">"},
            {"gte", ">="},
            {"starts with", "StartsWith"},
            {"ends with", "EndsWith"},
            {"contains", "Contains"},
            {"in", "in"},
            {"not in", "not in"},
        };
    }
}
