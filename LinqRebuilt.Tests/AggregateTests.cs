using System;
using System.Collections.Generic;
using Xunit;

namespace LinqRebuilt.Tests
{
  public class AggregateTests
  {
    [Fact]
    public void NullSourceThrowsArgumentNullExceptionNoSeed() {
      int[] source = null;

      static int func(int current, int value) => current + value;

      Assert.Throws<ArgumentNullException>(() => source.Aggregate(func));
    }

    [Fact]
    public void NullSourceThrowsArgumentNullExceptionWithSeed() {
      int[] source = null;

      static int func(int current, int value) => current + value;

      Assert.Throws<ArgumentNullException>(() => source.Aggregate(10, func));
    }

    [Fact]
    public void NullSourceThrowsArgumentNullExceptionWithSeedAndResultSelector() {
      int[] source = null;

      static int func(int current, int value) => current + value;

      Assert.Throws<ArgumentNullException>(() => source.Aggregate(10, func, x => x.ToString()));
    }

    [Fact]
    public void NullFuncThrowsArgumentNullExceptionNoSeed() {
      int[] source = { 1, 2, 3 };
      Func<int, int, int> func = null;

      Assert.Throws<ArgumentNullException>(() => source.Aggregate(func));
    }

    [Fact]
    public void NullFuncThrowsArgumentNullExceptionWithSeed() {
      int[] source = { 1, 2, 3 };
      Func<int, int, int> func = null;

      Assert.Throws<ArgumentNullException>(() => source.Aggregate(10, func));
    }

    [Fact]
    public void NullFuncThrowsArgumentNullExceptionWithSeedAndResultSelector() {
      int[] source = { 1, 2, 3 };
      Func<int, int, int> func = null;

      Assert.Throws<ArgumentNullException>(() => source.Aggregate(10, func, x => x.ToString()));
    }

    [Fact]
    public void NullResultSelectorThrowsArgumentNullException() {
      int[] source = { 1, 2, 3 };
      static int func(int current, int value) => current + value;
      Func<int, string> resultSelector = null;

      Assert.Throws<ArgumentNullException>(() => source.Aggregate(10, func, resultSelector));
    }

    [Fact]
    public void EmptySourceThrowsInvalidOperationExceptionWithNoSeed() {
      int[] source = Array.Empty<int>();

      static int func(int current, int value) => current + value;

      Assert.Throws<InvalidOperationException>(() => source.Aggregate(func));
    }

    [Fact]
    public void EmptySourceSeededReturnsSeed() {
      int[] source = Array.Empty<int>();
      static int func(int current, int value) => current + value;

      Assert.Equal(5, source.Aggregate(5, func));
    }

    [Fact]
    public void NoSeedReturnsCorrectResult() {
      int[] source = { 1, 2, 5 };
      static int func(int current, int value) => current + value;

      Assert.Equal(8, source.Aggregate(func));
    }

    [Fact]
    public void WithSeedNoResultSelectorReturnsCorrectResult() {
      int[] source = { 1, 2, 5 };
      static int func(int current, int value) => current + value;

      Assert.Equal(18, source.Aggregate(10, func));
    }

    [Fact]
    public void WithSeedWithResultSelectorReturnsCorrectResult() {
      int[] source = { 1, 2, 5 };
      static int func(int current, int value) => current + value;

      Assert.Equal("18", source.Aggregate(10, func, x => x.ToString()));
    }

    [Fact]
    public void DifferentSourceAndAccumulatorTypes() {
      int bigValue = 1_000_000_000;
      IEnumerable<int> source = Enumerable.Repeat(bigValue, 4);
      static long func(long current, int value) => current + value;

      long sum = source.Aggregate(0L, func);
      Assert.Equal(4_000_000_000L, sum);
      Assert.True(sum > int.MaxValue);
    }

    [Fact]
    public void DifferentSourceAndAccumulatorTypesWithResultSelector() {
      int bigValue = 1_000_000_000;
      IEnumerable<int> source = Enumerable.Repeat(bigValue, 4);
      static long func(long current, int value) => current + value;

      string sum = source.Aggregate(0L, func, x => x.ToString());
      Assert.Equal("4000000000", sum);
    }

    [Fact]
    public void FirstElementIsUsedAsSeedIfNoSeed() {
      int[] source = { 1, 2, 3 };
      static int func(int current, int value) => current * value;

      // If it used default as seed this would fail as the default for int is 0 and 0 * anything = 0
      Assert.NotEqual(0, source.Aggregate(func));
      Assert.Equal(6, source.Aggregate(func)); 
    }
  }
}
