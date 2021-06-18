using System;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source) {
      return source.DefaultIfEmpty(default);
    }

    public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, TSource defaultValue) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      return DefaultIfEmptyImplementation(source, defaultValue);
    }

    private static IEnumerable<TSource> DefaultIfEmptyImplementation<TSource>(IEnumerable<TSource> source, TSource defaultValue) {
      bool found = false;
      foreach (TSource item in source) {
        found = true;
        yield return item;
      }

      if (!found)
        yield return defaultValue;
    }
  }
}