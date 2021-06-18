using System;
using System.Collections.Generic;
using Xunit;
using RepeatClass = LinqRebuilt.Enumerable;

namespace LinqRebuilt.Tests
{
  public class RepeatTests
  {
    [Fact]
    public void SimpleRepeat() {
      string[] expected = { "repeat", "repeat", "repeat" };

      IEnumerable<string> result = RepeatClass.Repeat("repeat", 3);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void RepeatWithZeroCountShouldBeEmpty() {
      string[] expected = Array.Empty<string>();

      IEnumerable<string> result = RepeatClass.Repeat("repeat", 0);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void ElementCanBeNull() {
      string[] expected = { null, null, null };

      IEnumerable<string> result = RepeatClass.Repeat<string>(null, 3);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void CountCantBeNegative() {
      Assert.Throws<ArgumentOutOfRangeException>(() => RepeatClass.Repeat("repeat", -1));
    }
  }
}
