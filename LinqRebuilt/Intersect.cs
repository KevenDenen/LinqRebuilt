
using System;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second) {
      return Intersect(first, second, EqualityComparer<TSource>.Default);
    }

    public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer) {
      if (first == null)
        throw new ArgumentNullException(nameof(first));
      if (second == null)
        throw new ArgumentNullException(nameof(second));

      return IntersectImplementation(first, second, comparer ?? EqualityComparer<TSource>.Default);
    }

    private static IEnumerable<TSource> IntersectImplementation<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer) {
      HashSet<TSource> potentialElements = new(second, comparer);
      foreach (TSource item in first) {
        if (potentialElements.Remove(item))
          yield return item;
      }
    }
  }
}