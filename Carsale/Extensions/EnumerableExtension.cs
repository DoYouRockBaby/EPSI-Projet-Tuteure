using System.Collections.Generic;

namespace Carsale.Extensions
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> AddFirst<T>(this IEnumerable<T> source, T item)
        {
            yield return item;
            foreach (var x in source)
                yield return x;
        }
    }
}