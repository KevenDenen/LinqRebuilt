using System.Collections.Generic;
using Xunit;
using RangeClass = LinqRebuilt.Enumerable;
using System;

namespace LinqRebuilt.Tests
{
  public class RangeTests
  {
    [Fact]
    public void SimpleRange() {
      int[] expected = { 1, 2, 3, 4, 5 };

      IEnumerable<int> result = RangeClass.Range(1, 5);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void StartValueCanBeNegative() {
      int[] expected = { -1, 0, 1 };

      IEnumerable<int> result = RangeClass.Range(-1, 3);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void CountOfZeroIsEmpty() {
      int[] expected = Array.Empty<int>();

      IEnumerable<int> result = RangeClass.Range(int.MinValue, 0);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void CountAtMaxValueReturnMaxValue() {
      int[] expected = { int.MaxValue };

      IEnumerable<int> result = RangeClass.Range(int.MaxValue, 1);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void CountCantBeNegative() {
      Assert.Throws<ArgumentOutOfRangeException>(() => RangeClass.Range(0, -1));
    }

    [Fact]
    public void CantExceedMaxValue() {
      Assert.Throws<ArgumentOutOfRangeException>(() => RangeClass.Range(int.MaxValue, 2));
      Assert.Throws<ArgumentOutOfRangeException>(() => RangeClass.Range(9, int.MaxValue));
      Assert.Throws<ArgumentOutOfRangeException>(() => RangeClass.Range(int.MaxValue / 2 + 10, int.MaxValue / 2 + 10));
    }
  }
}
