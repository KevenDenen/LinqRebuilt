using System;
using System.Collections.Generic;

namespace LinqRebuilt
{
  public static partial class Enumerable
  {
    public static IEnumerable<int> Range(int start, int count) {
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof(count));
      if ((long)start + (long)count - 1L > int.MaxValue)
        throw new ArgumentOutOfRangeException(nameof(count));

      return RangeImplementation(start, count);
    }

    private static IEnumerable<int> RangeImplementation(int start, int count) {
      for (int i = 0; i < count; i++) {
        yield return start + i;
      }
    }
  }
}