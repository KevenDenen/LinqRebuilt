using System;
using Xunit;
using System.Linq;

namespace LinqRebuilt.Tests
{
  public class LastOrDefaultTests
  {
    [Fact]
    public void NullSourceWithoutPredicateThrowsArgumentNullException() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.LastOrDefault());
    }

    [Fact]
    public void NullSourceWithPredicateThrowsArgumentNullException() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.LastOrDefault(x => x > 2));
    }

    [Fact]
    public void NullPredicateThrowsArgumentNullException() {
      int[] source = { 1, 2, 3 };

      Assert.Throws<ArgumentNullException>(() => source.LastOrDefault(null));
    }

    [Fact]
    public void EmptySourceWithoutPredicateReturnsDefault() {
      int[] source = Array.Empty<int>();

      Assert.Equal(default, source.LastOrDefault());
    }

    [Fact]
    public void EmptySourceWithPredicateReturnsDefault() {
      int[] source = Array.Empty<int>();

      Assert.Equal(default, source.LastOrDefault(x => x > 2));
    }

    [Fact]
    public void ReturnsLastItemNoPredicate() {
      int[] source = { 1, 2, 3 };

      Assert.Equal(3, source.LastOrDefault());
    }

    [Fact]
    public void ReturnsLastMatchItemWithPredicate() {
      int[] source = { 1, 2, 3, 5, 1 };

      Assert.Equal(5, source.LastOrDefault(x => x > 2));
    }

    [Fact]
    public void NoMatchReturnsDefault() {
      int[] source = { 1, 2, 3 };

      Assert.Equal(default, source.LastOrDefault(x => x > 5));
    }
  }
}
