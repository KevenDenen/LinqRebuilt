using System;
using System.Collections.Generic;
using Xunit;

namespace LinqRebuilt.Tests
{
  public class SumTests
  {
    [Fact]
    public void IntNullSourceThrowsArgumentNullException() {
      int[] source = null;
      Assert.Throws<ArgumentNullException>(() => source.Sum());
    }

    [Fact]
    public void IntNullSourceNullableThrowsArgumentNullException() {
      int?[] source = null;
      Assert.Throws<ArgumentNullException>(() => source.Sum());
    }

    [Fact]
    public void IntNullSourceWithSelectorThrowsArgumentNullException() {
      string[] source = null;
      Assert.Throws<ArgumentNullException>(() => source.Sum( s => s.Length));
    }

    [Fact]
    public void IntNullSourceNullableWithSelectorThrowsArgumentNullException() {
      string?[] source = null;
      Assert.Throws<ArgumentNullException>(() => source.Sum( s => s.Length));
    }

    [Fact]
    public void IntNullSelectorThrowsArgumentNullException() {
      int[] source = { 1, 2, 3 };
      Assert.Throws<ArgumentNullException>(() => source.Sum(null));
    }

    [Fact]
    public void IntNullableNullSelectorThrowsArgumentNullException() {
      int?[] source = { 1, 2, 3 };
      Assert.Throws<ArgumentNullException>(() => source.Sum(null));
    }

    [Fact]
    public void IntSimpleSequenceResultsInExpectedValue() {
      int[] source = { 1, 2, 3 };
      var expected = 6;
      Assert.Equal(expected, source.Sum());
    }

    [Fact]
    public void IntEmptySequenceResultsInZero() {
      int[] source = Array.Empty<int>();
      var expected = 0;
      Assert.Equal(expected, source.Sum());
    }

    [Fact]
    public void IntNullableSimpleSequenceResultsInValue() {
      int?[] source = { 1, null, 2, null, 3 };
      var expected = 6;
      int? result = source.Sum();
      Assert.Equal(expected, result);
    }

    [Fact]
    public void IntNullableSequenceOfNullsResultsInZero() {
      int?[] source = { null, null, null };
      var expected = 0;
      int? result = source.Sum();
      Assert.Equal(expected, result);
    }

    [Fact]
    public void IntSimpleSequenceWithSelectorResultsInExpectedValue() {
      string[] source = { "keven", "nancy", "mark", "jim" };
      var expected = 17;
      int result = source.Sum(s=>s.Length);
      Assert.Equal(expected,result);
    }

    [Fact]
    public void IntNullableSimpleSequenceResultsInValueWithSelector() {
      string[] source = { "keven", "carrot", "nancy", "carrot", "mark", "jim" };
      var expected = 17;
      int? result = source.Sum(s => s == "carrot" ? null : s.Length);
      Assert.Equal(expected, result);
    }

    [Fact]
    public void IntNegativeOverflow() {
      int[] source = { int.MinValue, int.MinValue };
      Assert.Throws<OverflowException>(() => source.Sum());
    }

    [Fact]
    public void IntOverflow() {
      int[] source = { int.MaxValue, int.MaxValue };
      Assert.Throws<OverflowException>(() => source.Sum());
    }

    [Fact]
    public void IntNegativeOverFlowWithSelector() {
      string[] source = { "a", "b" };
      Assert.Throws<OverflowException>(() => source.Sum(x => int.MinValue));
    }

    [Fact]
    public void IntOverflowWithSelector() { 
      string[] source = { "a", "b" };
      Assert.Throws<OverflowException>(() => source.Sum(x => int.MaxValue));
    }
  }
}
