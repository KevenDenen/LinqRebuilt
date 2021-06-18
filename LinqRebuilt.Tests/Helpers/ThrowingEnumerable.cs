using System;
using System.Collections;
using System.Collections.Generic;

namespace LinqRebuilt.Tests.Helpers
{
  public sealed class ThrowingEnumerable : IEnumerable<int>
  {
    public IEnumerator<int> GetEnumerator() {
      throw new InvalidOperationException();
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return GetEnumerator();
    }
  }
}
