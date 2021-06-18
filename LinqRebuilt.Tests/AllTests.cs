using Xunit;
using System;

namespace LinqRebuilt.Tests
{
  public class AllTests
  {
    [Fact]
    public void NullSourceThrowsArgumentNullException() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.All(x => x > 2));
    }

    [Fact]
    public void NullPredicateThrowsArgumentNullException() {
      int[] source = { 1, 2, 3 };

      Assert.Throws<ArgumentNullException>(() => source.All(null));
    }

    [Fact]
    public void EmptySourceReturnsTrue() {
      int[] source = Array.Empty<int>();

      Assert.True(source.All(x => x > 2));
    }

    [Fact]
    public void MatchesAllElements() {
      int[] source = { 1, 2, 3 };

      Assert.True(source.All(x => x > 0));
    }

    [Fact]
    public void MatchesSomeElements() {
      int[] source = { 1, 2, 3 };

      Assert.False(source.All(x => x > 2));
    }

    [Fact]
    public void MatchesZeroElements() {
      int[] source = { 1, 2, 3 };

      Assert.False(source.All(x => x > 5));
    }

    [Fact]
    public void EvaluationStopsAfterFirstNonMatch() {
      int[] source = { 1, 2, 3, 0 };
      // As soon as it finds a non-match, it stops evaluating
      // The divide by zero never occurs
      Assert.False(source.All(x => 2 / x == 0));
    }
  }
}
