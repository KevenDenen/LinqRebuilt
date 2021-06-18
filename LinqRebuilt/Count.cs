using System;
using System.Collections;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));
      if (predicate == null)
        throw new ArgumentNullException(nameof(predicate));

      checked {
        int count = 0;
        foreach (TSource item in source) {
          if (predicate(item))
            count++;
        }
        return count;
      }
    }

    public static int Count<TSource>(this IEnumerable<TSource> source) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      ICollection<TSource> genericCollection = source as ICollection<TSource>;
      if (genericCollection != null)
        return genericCollection.Count;

      ICollection nonGenericCollection = source as ICollection;
      if (nonGenericCollection != null)
        return nonGenericCollection.Count;

      checked {
        int count = 0;
        using (var iterator = source.GetEnumerator()) {
          while (iterator.MoveNext())
            count++;
        }
        return count;
      }
    }
  }
}