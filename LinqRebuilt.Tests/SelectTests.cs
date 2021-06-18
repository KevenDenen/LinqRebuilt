using Xunit;
using System.Collections.Generic;
using System;

namespace LinqRebuilt.Tests
{
  public class SelectTests
  {
    [Fact]
    public void ProjectionToDifferentType() {
      int[] source = { 1, 5, 2 };
      string[] expected = { "1", "5", "2" };

      var result = source.Select(x => x.ToString());

      Assert.Equal(expected, result);
    }

    [Fact]
    public void WithIndexProjectionToDifferentType() {
      int[] source = { 1, 5, 2 };
      string[] expected = { "0: 1", "1: 5", "2: 2" };

      var result = source.Select((number, index) => $"{index}: {number}");

      Assert.Equal(expected, result);
    }

    [Fact]
    public void SideEffectsInProjection() {
      int[] source = new int[3];

      int count = 0;
      var query = source.Select(x => count++);
      int[] expected = { 0, 1, 2 };

      Assert.Equal(expected, query);
      int[] newExpected = { 3, 4, 5 };
      Assert.Equal(newExpected, query);

      count = 10;
      int[] expectedStartingAtTen = { 10, 11, 12 };
      Assert.Equal(expectedStartingAtTen, query);
    }

    [Fact]
    public void WhereAndSelect() {
      int[] source = { 1, 3, 4, 2, 8, 1 };
      int[] expected = { 2, 6, 4, 2 };
      
      var result = from x in source
                   where x < 4
                   select x * 2;

      Assert.Equal(expected, result);
    }

    [Fact]
    public void NullSourceThrowsArgumentNullException() {
      IEnumerable<int> source = null;
      Assert.Throws<ArgumentNullException>(() => source.Select(x => x.ToString()));
    }

    [Fact]
    public void NullPredicateThrowsArgumentNullException() {
      int[] source = { 1, 3, 8, 9, 11 };
      Func<int, bool> predicate = null;

      Assert.Throws<ArgumentNullException>(() => source.Select(predicate));
    }

    [Fact]
    public void WithIndexNullSourceThrowsArgumentNullException() {
      IEnumerable<int> source = null;
      Assert.Throws<ArgumentNullException>(() => source.Select((number, index) => $"{index}: {number}"));
    }

    [Fact]
    public void WithIndexNullPredicateThrowsArgumentNullException() {
      int[] source = { 1, 3, 8, 9, 11 };
      Func<int, int, bool> predicate = null;

      Assert.Throws<ArgumentNullException>(() => source.Select(predicate));
    }

  }
}
