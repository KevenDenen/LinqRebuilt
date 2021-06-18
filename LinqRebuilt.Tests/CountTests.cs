using Xunit;
using System.Collections.Generic;
using System;

namespace LinqRebuilt.Tests
{
  public class CountTests
  {
    [Fact]
    public void CountOfEnumerableNotACollection() {
      Assert.Equal(5, Enumerable.Range(1, 5).Count());
    }

    [Fact]
    public void CountOfGenericCollection() {
      Assert.Equal(5, new List<int>(Enumerable.Range(1, 5)).Count());
    }

    [Fact]
    public void NullSourceThrowsArgumentNullException() {
      IEnumerable<int> source = null;
      Assert.Throws<ArgumentNullException>(() => source.Count());
    }

    [Fact]
    public void PredicateNullSourceThrowsArgumentNullException() {
      IEnumerable<int> source = null;
      Assert.Throws<ArgumentNullException>(() => source.Count(x => x > 1));
    }

    [Fact]
    public void PredicateNullPredicateThrowsArgumentNullException() {
      Assert.Throws<ArgumentNullException>(() => Array.Empty<int>().Count(null));
    }

    [Fact]
    public void PredicateCount() {
      Assert.Equal(3, Enumerable.Range(1, 6).Count(x => x % 2 == 0));
    }
  }
}
