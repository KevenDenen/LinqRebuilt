﻿using System;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static TSource Single<TSource> (this IEnumerable<TSource> source) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      using var iterator = source.GetEnumerator();
      if (!iterator.MoveNext())
        throw new InvalidOperationException("Source was empty.");
      TSource result = iterator.Current;
      if (iterator.MoveNext())
        throw new InvalidOperationException("Source contained more than one item.");
      return result;
    }

    public static TSource Single<TSource> (this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));
      if (predicate == null)
        throw new ArgumentNullException(nameof(predicate));

      bool match = false;
      TSource result = default;
      foreach (TSource item in source) {
        if (predicate(item)) {
          if (match)
            throw new InvalidOperationException("Source contained more than one match for the predicate.");
          match = true;
          result = item;
        }
      }

      if (!match)
        throw new InvalidOperationException("Source didn't contain any items matching the predicate.");
      return result;
    }
  }
}
