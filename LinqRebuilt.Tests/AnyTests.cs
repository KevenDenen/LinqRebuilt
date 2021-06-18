using System;
using System.Collections.Generic;
using Xunit;

namespace LinqRebuilt.Tests
{
  public class AnyTests
  {
    [Fact]
    public void NullSourceThrowsArgumentNullException() {
      IEnumerable<int> source = null;
      Assert.Throws<ArgumentNullException>(() => source.Any());
    }
    [Fact]
    public void NullSourceWithPredicateThrowsArgumentNullException() {
      IEnumerable<int> source = null;

      Assert.Throws<ArgumentNullException>(() => source.Any(x => x > 2));
    }

    [Fact]
    public void NullPredicateThrowsArgumentNullException() {
      int[] source = { 1, 2, 3 };

      Assert.Throws<ArgumentNullException>(() => source.Any(null));
    }

    [Fact]
    public void EmptySourceReturnsFalse() {
      int[] source = Array.Empty<int>();

      Assert.False(source.Any());
    }

    [Fact]
    public void EmptySourceWithPredicateReturnsFalse() {
      int[] source = Array.Empty<int>();

      Assert.False(source.Any(x => x > 2));
    }

    [Fact]
    public void NonEmptySourceWithoutPredicate() {
      int[] source = { 1, 5, 10, 2 };

      Assert.True(source.Any());
    }

    [Fact]
    public void NonEmptySourceWithPredicateMatches() {
      int[] source = { 1, 5, 10, 2 };
      Assert.True(source.Any(x => x > 5));
    }
    
    [Fact]
    public void NonEmptySourceWithPredicateDoesntMatch() {
      int[] source = { 1, 5, 10, 2 };
      Assert.False(source.Any(x => x > 10));
    }

    [Fact]
    public void EvaluationStopsAfterFirstMatch() {
      int[] source = { 1, 5, 10, 2, 0 };
      // As soon as it finds a match, it stops evaluating
      // The divide by zero never occurs
      Assert.True(source.Any(x => 10 / x == 1));
    }
  }
}
