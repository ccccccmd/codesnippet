    public static class MyOrder
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, List<string> propertyNames, bool desc)
        {
            if (!propertyNames.Any())
            {
                throw new ArgumentException("propertyNames²ÎÊý");
            }
            var param = Expression.Parameter(typeof(T));
            var body = Expression.Property(param, propertyNames[0]);

            dynamic keySelector = Expression.Lambda(body, param);
            var temp = desc ? Queryable.OrderByDescending(queryable, keySelector) : Queryable.OrderBy(queryable, keySelector);
            if (propertyNames.Count > 1)
            {
                foreach (var name in propertyNames)
                {
                    var k = Expression.Property(param, name);
                    dynamic m = Expression.Lambda(k, param);
                    temp = desc ? Queryable.ThenByDescending(temp, m) : Queryable.ThenBy(temp, m);
                }
            }
            return temp;

        }
    }