using Xunit;
using System;
using System.Collections.Generic;
using LinqRebuilt.Tests.Helpers;

namespace LinqRebuilt.Tests
{
  public class ConcatTests
  {
    [Fact]
    public void NullFirstThrowsArgumentNullException() {
      int[] first = null;
      int[] second = { 4, 5, 6 };

      Assert.Throws<ArgumentNullException>(() => first.Concat(second));
    }

    [Fact]
    public void NullSecondThrowsArgumentNullException() {
      int[] first = { 1, 2, 3 };
      int[] second = null;

      Assert.Throws<ArgumentNullException>(() => first.Concat(second));
    }

    [Fact]
    public void DeferredFirstSequence() {
      IEnumerable<int> first = new ThrowingEnumerable();
      IEnumerable<int> second = new int[] { 10 };

      // Execution is deferred, shouldn't throw here
      var query = first.Concat(second);
      // Getting the enumerator is fine
      using var iterator = query.GetEnumerator();
      // Should fail when trying to actually step through the collection
      Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
    }

    [Fact]
    public void DeferredSecondSequence() {
      IEnumerable<int> first = new int[] { 10 };
      IEnumerable<int> second = new ThrowingEnumerable();

      // Execution is deferred, shouldn't throw here
      var query = first.Concat(second);
      // Getting the enumerator is fine
      using (var iterator = query.GetEnumerator()) {
        // Stepping through the first sequence is fine
        Assert.True(iterator.MoveNext());
        Assert.Equal(10, iterator.Current);

        // Stepping into the second sequence should throw
        Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
      }
    }
  }
}
