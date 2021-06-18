using Xunit;
using System;

namespace LinqRebuilt.Tests
{
  public class SingleTests
  {
    [Fact]
    public void NullSourceShouldThrowArgumentNullExceptionNoPredicate() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.Single());
    }

    [Fact]
    public void NullSourceShouldThrowArgumentNullExceptionWithPredicate() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.Single(x => x > 1));
    }

    [Fact]
    public void NullPredicateShouldThrowArgumentNullException() {
      int[] source = { 1, 2, 3 };

      Assert.Throws<ArgumentNullException>(() => source.Single(null));
    }

    [Fact]
    public void EmptySourceShouldThrowInvalidOperationExceptionNoPredicate() {
      int[] source = Array.Empty<int>();

      Assert.Throws<InvalidOperationException>(() => source.Single());
    }

    [Fact]
    public void EmptySourceShouldThrowInvalidOperationExceptionWithPredicate() {
      int[] source = Array.Empty<int>();

      Assert.Throws<InvalidOperationException>(() => source.Single(x => x > 2));
    }

    [Fact]
    public void MultipleItemsInSourceShouldThrowInvalidOperationExceptionNoPredicate() {
      int[] source = { 1, 2, 3 };

      Assert.Throws<InvalidOperationException>(() => source.Single());
    }

    [Fact]
    public void MultipleMatchingItemsShouldThrowInvalidOperationExceptionWithPredicate() {
      int[] source = { 1, 2, 3, 1 };

      Assert.Throws<InvalidOperationException>(() => source.Single(x => x == 1));
    }

    [Fact]
    public void SourceWithOneItemShouldReturnNoPredicate() {
      int[] source = { 4 };

      Assert.Equal(4, source.Single());
    }

    [Fact] 
    public void SourceWithOneMatchingItemShouldReturnPredicate() {
      int[] source = { 1, 2, 3, 2, 1 };

      Assert.Equal(3, source.Single(x => x == 3));
    }
  }
}
