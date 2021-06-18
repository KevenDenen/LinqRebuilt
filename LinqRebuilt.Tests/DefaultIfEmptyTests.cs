using System;
using Xunit;

namespace LinqRebuilt.Tests
{
  public class DefaultIfEmptyTests
  {
    [Fact]
    public void NullSourceThrowsArgumentNullExceptionNoParameter() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.DefaultIfEmpty());
    }


    [Fact]
    public void NullSourceThrowsArgumentNullExceptionWithParameter() {
      int[] source = null;

      Assert.Throws<ArgumentNullException>(() => source.DefaultIfEmpty(2));
    }

    [Fact]
    public void EmptySourceReturnsDefaultNoParameter() {
      int[] source = Array.Empty<int>();

      Assert.Equal(new int[] { default }, source.DefaultIfEmpty());
    }

    [Fact]
    public void EmptySourceReturnsParameterValue() {
      int[] source = Array.Empty<int>();

      Assert.Equal(new int[] { 5 }, source.DefaultIfEmpty(5));
    }

    [Fact]
    public void NonEmptySourceReturnsSourceNoParameter() {
      int[] source = { 1, 2, 3 };

      Assert.Equal(source, source.DefaultIfEmpty());
    }

    [Fact]
    public void NonEmptySourceReturnsSourceWithParameter() {
      int[] source = { 1, 2, 3 };

      Assert.Equal(source, source.DefaultIfEmpty(5));
    }
  }
}
