using System;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      using var iterator = source.GetEnumerator();
      return iterator.MoveNext() ? iterator.Current : default;
    }

    public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));
      if (predicate == null)
        throw new ArgumentNullException(nameof(predicate));

      foreach (TSource item in source) {
        if (predicate(item))
          return item;
      }
      return default;
    }
  }

}