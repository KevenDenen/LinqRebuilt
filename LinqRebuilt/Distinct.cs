using System;
using System.Collections;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source) {
      return source.Distinct(EqualityComparer<TSource>.Default);
    }

    public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      return DistinctImplementation(source, comparer);
    }

    private static IEnumerable<TSource> DistinctImplementation<TSource>(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer) {
      HashSet<TSource> uniqueItems = new(comparer);

      foreach (TSource item in source) {
        if (uniqueItems.Add(item))
          yield return item;
      }
    }
  }
}