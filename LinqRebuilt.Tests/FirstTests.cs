using System;
using Xunit;

namespace LinqRebuilt.Tests
{
  public class FirstTests
  {
    [Fact]
    public void NullSourceWithoutPredicateThrowsArgumentNullException() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.First());
    }

    [Fact]
    public void NullSourceWithPredicateThrowsArgumentNullException() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.First(x => x > 2));
    }

    [Fact]
    public void NullPredicateThrowsArgumentNullException() {
      int[] source = { 1, 2, 3 };

      Assert.Throws<ArgumentNullException>(() => source.First(null));
    }

    [Fact]
    public void EmptySourceWithoutPredicateThrowsInvalidOperationException() {
      int[] source = Array.Empty<int>();

      Assert.Throws<InvalidOperationException>(() => source.First());
    }

    [Fact]
    public void EmptySourceWithPredicateThrowsInvalidOperationException() {
      int[] source = Array.Empty<int>();

      Assert.Throws<InvalidOperationException>(() => source.First(x => x > 2));
    }

    [Fact]
    public void ReturnsFirstItemNoPredicate() {
      int[] source = { 1, 2, 3 };

      Assert.Equal(1, source.First());
    }

    [Fact]
    public void ReturnsFirstMatchItemWithPredicate() {
      int[] source = { 1, 2, 3 };

      Assert.Equal(3, source.First(x => x > 2));
    }

    [Fact]
    public void ThrowsInvalidOperationExceptionWhenNoMatchingPredicate() {
      int[] source = { 1, 2, 3 };

      Assert.Throws<InvalidOperationException>(() => source.First(x => x > 5));
    }

    [Fact]
    public void EvaluationStopsOnFirstReturnedItemWithoutPredicate() {
      int[] source = { 1, 2, 3, 0 };
      var query = source.Select(x => 10 / x); // {10, 5, 3, Error}

      // Will never reach the divide by zero operation
      Assert.Equal(10, query.First());
    }

    [Fact]
    public void EvaluationStopsOnFirstReturnedItemWithPredicate() {
      int[] source = { 1, 2, 3, 0 };
      var query = source.Select(x => 10 / x); // {10, 5, 3, Error}

      // Will never reach the divide by zero operation
      Assert.Equal(5, query.First(x => x == 5));
    }
  }
}
