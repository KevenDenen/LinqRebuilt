using System;
using System.Collections;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static TSource Last<TSource> (this IEnumerable<TSource> source) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      using var iterator = source.GetEnumerator();
      if (!iterator.MoveNext())
        throw new InvalidOperationException("Source was empty.");

      TSource last = iterator.Current;
      while (iterator.MoveNext()) {
        last = iterator.Current;
      }
      return last;
    }

    public static TSource Last<TSource> (this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));
      if (predicate == null)
        throw new ArgumentNullException(nameof(predicate));

      bool match = false;
      TSource last = default;

      foreach (TSource item in source) {
        if (predicate(item)) {
          match = true;
          last = item;
        }
      }

      if (match) {
        return last;
      }
      throw new InvalidOperationException("No items matched the predicate.");
    }
  }
}