using System;
using Xunit;

namespace LinqRebuilt.Tests
{
  public class LastTests
  {
    [Fact]
    public void NullSourceWithoutPredicateThrowsArgumentNullException() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.Last());
    }

    [Fact]
    public void NullSourceWithPredicateThrowsArgumentNullException() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.Last(x => x > 2));
    }

    [Fact]
    public void NullPredicateThrowsArgumentNullException() {
      int[] source = { 1, 2, 3 };

      Assert.Throws<ArgumentNullException>(() => source.Last(null));
    }

    [Fact]
    public void EmptySourceWithoutPredicateThrowsInvalidOperationException() {
      int[] source = Array.Empty<int>();

      Assert.Throws<InvalidOperationException>(() => source.Last());
    }

    [Fact]
    public void EmptySourceWithPredicateThrowsInvalidOperationException() {
      int[] source = Array.Empty<int>();

      Assert.Throws<InvalidOperationException>(() => source.Last(x => x > 2));
    }

    [Fact]
    public void ReturnsLastItemNoPredicate() {
      int[] source = { 1, 2, 3 };

      Assert.Equal(3, source.Last());
    }

    [Fact]
    public void ReturnsLastMatchItemWithPredicate() {
      int[] source = { 1, 2, 3, 5, 1 };

      Assert.Equal(5, source.Last(x => x > 2));
    }

    [Fact]
    public void NoMatchThrowsInvalidOperationException() {
      int[] source = { 1, 2, 3 };

      Assert.Throws<InvalidOperationException>(() => source.Last(x => x > 5));
    }
  }
}
