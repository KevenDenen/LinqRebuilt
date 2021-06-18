using LinqRebuilt.Tests.Helpers;
using System;
using Xunit;

namespace LinqRebuilt.Tests
{
  public class IntersectTests
  {
    [Fact]
    public void NullFirstThrowsArgumentNullExceptionWithoutComparer() {
      int[] first = null;
      int[] second = { 1, 2, 3 };

      Assert.Throws<ArgumentNullException>(() => first.Intersect(second));
    }

    [Fact]
    public void NullSecondThrowsArgumentNullExceptionWithoutComparer() {
      int[] first = { 1, 2, 3 };
      int[] second = null;

      Assert.Throws<ArgumentNullException>(() => first.Intersect(second));
    }

    [Fact]
    public void NullFirstThrowsArgumentNullExceptionWithComparer() {
      string[] first = null;
      string[] second = { "a", "b", "c" };

      Assert.Throws<ArgumentNullException>(() => first.Intersect(second, StringComparer.Ordinal));
    }

    [Fact]
    public void NullSecondThrowsArgumentNullExceptionWithComparer() {
      string[] first = { "a", "b", "c" };
      string[] second = null;

      Assert.Throws<ArgumentNullException>(() => first.Intersect(second, StringComparer.Ordinal));
    }

    [Fact]
    public void SimpleIntersect() {
      string[] first = { "a", "b", "c" };
      string[] second = { "b", "c", "d" };
      string[] expected = { "b", "c" };

      var result = first.Intersect(second);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void SimpleIntersectWithNullComparerUsesDefaultComparer() {
      string[] first = { "a", "b", "c" };
      string[] second = { "b", "c", "d" };
      string[] expected = { "b", "c" };

      var result = first.Intersect(second, null);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void SimpleIntersectWithNonDefaultComparer() {
      string[] first = { "a", "b", "c" };
      string[] second = { "b", "C", "d" };
      string[] expected = { "b", "c" };

      var result = first.Intersect(second, StringComparer.OrdinalIgnoreCase);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void IntersectWithMultipleValuesOnlyContainsSingleCopy() {
      string[] first = { "a", "b", "c", "b", "c" };
      string[] second = { "b", "c", "d", "b" };
      string[] expected = { "b", "c" };

      var result = first.Intersect(second);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void IntersectWithMultipleValuesOnlyContainsSingleCopyWithComparer() {
      string[] first = { "a", "b", "c", "B", "c", "B" };
      string[] second = { "b", "c", "d", "B", "B" };
      string[] expected = { "b", "c" };

      var result = first.Intersect(second, StringComparer.OrdinalIgnoreCase);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void SequencesArentReadUntilIterated() {
      var first = new ThrowingEnumerable();
      var second = new ThrowingEnumerable();

      var query = first.Intersect(second);

      using var iterator = query.GetEnumerator();
      Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
    }

    [Fact]
    public void SecondSequenceIsReadFullyOnFirstResult() {
      int[] first = { 1, 2, 3 };
      var secondQuery = new[] { 8, 2, 0 }.Select(x => 8 / x);

      var query = first.Intersect(secondQuery);
      using var iterator = query.GetEnumerator();

      Assert.Throws<DivideByZeroException>(() => iterator.MoveNext());
    }
  }
}
