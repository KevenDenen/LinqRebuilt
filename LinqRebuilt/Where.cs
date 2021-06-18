using System;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      if (predicate == null)
        throw new ArgumentNullException(nameof(predicate));

      return source.WhereImplementation(predicate);
    }

    private static IEnumerable<TSource> WhereImplementation<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
      foreach (TSource item in source)
        if (predicate(item))
          yield return item;
    }

    public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      if (predicate == null)
        throw new ArgumentNullException(nameof(predicate));

      return source.WhereImplementation(predicate);
    }

    private static IEnumerable<TSource> WhereImplementation<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate) {
      int index = 0;
      foreach (TSource item in source) {
        if (predicate(item, index)) {
          yield return item;
        }
        index++;
      }
    }
  }
}