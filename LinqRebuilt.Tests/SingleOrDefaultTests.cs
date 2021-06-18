using Xunit;
using System;

namespace LinqRebuilt.Tests
{
  public class SingleOrDefaultTests
  {
    [Fact]
    public void NullSourceShouldThrowArgumentNullExceptionNoPredicate() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault());
    }

    [Fact]
    public void NullSourceShouldThrowArgumentNullExceptionWithPredicate() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault(x => x > 1));
    }

    [Fact]
    public void NullPredicateShouldThrowArgumentNullException() {
      int[] source = { 1, 2, 3 };

      Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault(null));
    }

    [Fact]
    public void EmptySourceShouldReturnDefault() {
      int[] source = Array.Empty<int>();

      Assert.Equal(default, source.SingleOrDefault());
    }

    [Fact]
    public void EmptySourceShouldReturnDefaultWithPredicate() {
      int[] source = Array.Empty<int>();

      Assert.Equal(default, source.SingleOrDefault(x => x > 2));
    }

    [Fact]
    public void MultipleItemsInSourceShouldThrowInvalidOperationExceptionNoPredicate() {
      int[] source = { 1, 2, 3 };

      Assert.Throws<InvalidOperationException>(() => source.SingleOrDefault());
    }

    [Fact]
    public void MultipleMatchingItemsShouldThrowInvalidOperationExceptionWithPredicate() {
      int[] source = { 1, 2, 3, 1 };

      Assert.Throws<InvalidOperationException>(() => source.SingleOrDefault(x => x == 1));
    }

    [Fact]
    public void SourceWithOneItemShouldReturnNoPredicate() {
      int[] source = { 4 };

      Assert.Equal(4, source.SingleOrDefault());
    }

    [Fact] 
    public void SourceWithOneMatchingItemShouldReturnPredicate() {
      int[] source = { 1, 2, 3, 2, 1 };

      Assert.Equal(3, source.SingleOrDefault(x => x == 3));
    }
  }
}
