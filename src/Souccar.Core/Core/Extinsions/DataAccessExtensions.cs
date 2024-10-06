using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.Extinsions
{
    public static class DataAccessExtensions
    {
        internal static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query,
            params string[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }
    }
}
