using System;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));
      if (func == null)
        throw new ArgumentNullException(nameof(func));

      using var iterator = source.GetEnumerator();
      if (!iterator.MoveNext())
        throw new InvalidOperationException("Source was empty.");

      TSource result = iterator.Current;
      while (iterator.MoveNext()) {
        result = func(result, iterator.Current);
      }

      return result;
    }

    public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) {
      return source.Aggregate(seed, func, x => x);
    }

    public static TResult Aggregate<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));
      if (func == null)
        throw new ArgumentNullException(nameof(func));
      if (resultSelector == null)
        throw new ArgumentNullException(nameof(resultSelector));

      TAccumulate accumulate = seed;
      foreach (TSource item in source) {
        accumulate = func(accumulate, item);
      }
      return resultSelector(accumulate);
    }
  }
}