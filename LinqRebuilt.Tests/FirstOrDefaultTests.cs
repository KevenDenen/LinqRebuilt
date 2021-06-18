using System;
using Xunit;

namespace LinqRebuilt.Tests
{
  public class FirstOrDefaultTests
  {
    [Fact]
    public void NullSourceWithoutPredicateThrowsArgumentNullException() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault());
    }

    [Fact]
    public void NullSourceWithPredicateThrowsArgumentNullException() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault(x => x > 2));
    }

    [Fact]
    public void NullPredicateThrowsArgumentNullException() {
      int[] source = { 1, 2, 3 };

      Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault(null));
    }

    [Fact]
    public void EmptySourceWithoutPredicateReturnsDefault() {
      int[] source = Array.Empty<int>();

      Assert.Equal(default, source.FirstOrDefault());
    }

    [Fact]
    public void EmptySourceWithPredicateReturnsDefault() {
      int[] source = Array.Empty<int>();

      Assert.Equal(default, source.FirstOrDefault(x => x > 2));
    }

    [Fact]
    public void ReturnsFirstItemNoPredicate() {
      int[] source = { 1, 2, 3 };

      Assert.Equal(1, source.FirstOrDefault());
    }

    [Fact]
    public void ReturnsFirstMatchItemWithPredicate() {
      int[] source = { 1, 2, 3 };

      Assert.Equal(3, source.FirstOrDefault(x => x > 2));
    }

    [Fact]
    public void ReturnsDefaultWhenNoMatchingPredicate() {
      int[] source = { 1, 2, 3 };

      Assert.Equal(default, source.FirstOrDefault(x => x > 5));
    }

    [Fact]
    public void EvaluationStopsOnFirstOrDefaultReturnedItemWithoutPredicate() {
      int[] source = { 1, 2, 3, 0 };
      var query = source.Select(x => 10 / x); // {10, 5, 3, Error}

      // Will never reach the divide by zero operation
      Assert.Equal(10, query.FirstOrDefault());
    }

    [Fact]
    public void EvaluationStopsOnFirstOrDefaultReturnedItemWithPredicate() {
      int[] source = { 1, 2, 3, 0 };
      var query = source.Select(x => 10 / x); // {10, 5, 3, Error}

      // Will never reach the divide by zero operation
      Assert.Equal(5, query.FirstOrDefault(x => x == 5));
    }
  }
}
