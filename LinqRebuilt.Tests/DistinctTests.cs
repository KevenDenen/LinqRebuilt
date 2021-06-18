using System;
using Xunit;

namespace LinqRebuilt.Tests
{
  public class DistinctTests
  {
    [Fact]
    public void NullSourceShouldThrowArgumentNullExceptionNoComparer() {
      string[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.Distinct());
    }

    [Fact]
    public void NullSourceShouldThrowArgumentNullExceptionWithComparer() {
      string[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.Distinct(StringComparer.Ordinal));
    }

    [Fact]
    public void NoComparerUsesDefault() {
      string[] source = { "abc", "ABC", "def" };
      string[] expected = { "abc", "ABC", "def" };
      
      Assert.Equal(expected, source.Distinct());
    }

    [Fact]
    public void NullComparerUsedDefault() {
      string[] source = { "abc", "ABC", "def" };
      string[] expected = { "abc", "ABC", "def" };
      
      Assert.Equal(expected, source.Distinct(null));
    }

    [Fact]
    public void NormalComparisonWithComparer() {
      string[] source = { "abc", "ABC", "def" };
      string[] expected = { "abc", "def" };

      Assert.Equal(expected, source.Distinct(StringComparer.OrdinalIgnoreCase));
    }

    [Fact]
    public void SequenceContainsNullsNoComparer() {
      string[] source = { "abc", null, "ABC", null, "def" };
      string[] expected = { "abc", null, "ABC", "def" };

      Assert.Equal(expected, source.Distinct());
    }

    [Fact]
    public void SequenceContainsNullsWithComparer() {
      string[] source = { "abc", null, "ABC", null, "def" };
      string[] expected = { "abc", null, "def" };

      Assert.Equal(expected, source.Distinct(StringComparer.OrdinalIgnoreCase));
    }
  }
}
