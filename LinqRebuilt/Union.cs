using System;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second) {
      return first.Union(second, EqualityComparer<TSource>.Default);
    }

    public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer) {
      if (first == null)
        throw new ArgumentNullException(nameof(first));
      if (second == null)
        throw new ArgumentNullException(nameof(second));

      return UnionImplementation(first, second, comparer ?? EqualityComparer<TSource>.Default);
    }

    private static IEnumerable<TSource> UnionImplementation<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer) {
      HashSet<TSource> uniqueItems = new(comparer);
      foreach (TSource item in first) {
        if (uniqueItems.Add(item))
          yield return item;
      }
      foreach (TSource item in second) {
        if (uniqueItems.Add(item))
          yield return item;
      }
    }
  }
}
