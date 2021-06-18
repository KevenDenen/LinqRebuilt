
using System;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second) {
      return Except(first, second, EqualityComparer<TSource>.Default);
    }

    public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer) {
      if (first == null)
        throw new ArgumentNullException(nameof(first));
      if (second == null)
        throw new ArgumentNullException(nameof(second));

      return ExceptImplementation(first, second, comparer ?? EqualityComparer<TSource>.Default);
    }

    private static IEnumerable<TSource> ExceptImplementation<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer) {
      HashSet<TSource> elementsNotAllowed = new(second, comparer);
      foreach (TSource item in first) {
        if (elementsNotAllowed.Add(item))
          yield return item;
      }
    }
  }
}