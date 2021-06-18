using System;
using System.Collections.Generic;
using Xunit;

namespace LinqRebuilt.Tests
{
  public class WhereTests {
    [Fact]
    public void SimpleFiltering() {
      int[] source = { 1, 3, 4, 2, 9, 1 };
      int[] expected = { 1, 3, 2, 1 };

      var result = source.Where(x => x < 4);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void NullSourceThrowsArgumentNullException() {
      IEnumerable<int> source = null;
      Assert.Throws<ArgumentNullException>(() => source.Where(x => x > 5));
    }

    [Fact]
    public void NullPredicateThrowsArgumentNullException() {
      int[] source = { 1, 3, 8, 9, 11 };
      Func<int, bool> predicate = null;

      Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
    }

    [Fact]
    public void IndexFiltering() {
      int[] source = { 0, 30, 20, 15, 90, 85, 40, 75 };
      int[] expected = { 0, 20, 15, 40 };

      var result = source.Where((number, index) => number <= index * 10);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void WithIndexNullSourceThrowsArgumentNullException() {
      IEnumerable<int> source = null;

      Assert.Throws<ArgumentNullException>(() => source.Where((x, index) => x > 5));
    }

    [Fact]
    public void WithIndexNullPredicateThrowsArgumentNullException() {
      int[] source = { 1, 3, 8, 9, 11 };
      Func<int, int, bool> predicate = null;

      Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
    }

    [Fact]
    public void FilteringWithLongForm() {
      int[] source = { 1, 3, 8, 9, 2 };
      int[] expected = { 1, 3, 2 };

      var result = from x in source
                   where x < 4
                   select x;

      Assert.Equal(expected, result);
    }
  }
}
