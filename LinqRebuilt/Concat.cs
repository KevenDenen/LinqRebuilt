using System;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second) {
      if (first == null)
        throw new ArgumentNullException(nameof(first));
      if (second == null)
        throw new ArgumentNullException(nameof(second));

      return first.ConcatImplementation(second);
    }

    private static IEnumerable<TSource> ConcatImplementation<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second) {
      foreach (TSource item in first)
        yield return item;

      foreach (TSource item in second)
        yield return item;
    }
  }
}
