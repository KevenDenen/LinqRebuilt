using System;
using System.Collections;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      TSource last = default;
      foreach (TSource item in source) {
        last = item;
      }
      return last;
    }

    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));
      if (predicate == null)
        throw new ArgumentNullException(nameof(predicate));

      TSource last = default;
      foreach (TSource item in source) {
        if (predicate(item))
          last = item;
      }
      return last;
    }
  }
}