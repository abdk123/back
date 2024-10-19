using System.Linq;

namespace Souccar.Core.Extinsions
{
    public static class QuerableExtension
    {
        public static IQueryable<TEntity> SortList<TEntity>(this IQueryable<TEntity> query, string value)
        {
            if(string.IsNullOrEmpty(value))
                return query;

            var propName = value;
            var sortType = "asc";
            if(value.Contains(' '))
            {
                var array = value.Split(' ');
                if(array.Length != 2)
                    return query;

                propName = array[0];
                sortType = array[1];
            }
            sortType = sortType.ToLower() == "desc" ? sortType : "asc";

            var propInfo = typeof(TEntity).GetProperty(propName);
            return sortType.ToLower() == "desc" ?
                query.OrderByDescending(n => propInfo.GetValue(n)) :
                query.OrderBy(n => propInfo.GetValue(n));
        }
    }
}
