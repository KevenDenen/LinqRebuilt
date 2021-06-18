using System;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));
      if (selector == null)
        throw new ArgumentNullException(nameof(selector));

      return source.SelectImplementation(selector);
    }

    private static IEnumerable<TResult> SelectImplementation<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) {
      foreach (TSource item in source) {
        yield return selector(item);
      }
    }

    public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));
      if (selector == null)
        throw new ArgumentNullException(nameof(selector));

      return source.SelectImplementation(selector);
    }

    private static IEnumerable<TResult> SelectImplementation<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector) {
      int index = 0;
      foreach (TSource item in source) {
        yield return selector(item, index);
        index++;
      }
    }
  }
}
