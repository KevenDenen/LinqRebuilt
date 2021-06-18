using LinqRebuilt.Tests.Helpers;
using System;
using Xunit;

namespace LinqRebuilt.Tests
{
  public class ExceptTests
  {
    [Fact]
    public void NullFirstThrowsArgumentNullExceptionWithoutComparer() {
      int[] first = null;
      int[] second = { 1, 2, 3 };

      Assert.Throws<ArgumentNullException>(() => first.Except(second));
    }

    [Fact]
    public void NullSecondThrowsArgumentNullExceptionWithoutComparer() {
      int[] first = { 1, 2, 3 };
      int[] second = null;

      Assert.Throws<ArgumentNullException>(() => first.Except(second));
    }

    [Fact]
    public void NullFirstThrowsArgumentNullExceptionWithComparer() {
      string[] first = null;
      string[] second = { "a", "b", "c" };

      Assert.Throws<ArgumentNullException>(() => first.Except(second, StringComparer.Ordinal));
    }

    [Fact]
    public void NullSecondThrowsArgumentNullExceptionWithComparer() {
      string[] first = { "a", "b", "c" };
      string[] second = null;

      Assert.Throws<ArgumentNullException>(() => first.Except(second, StringComparer.Ordinal));
    }

    [Fact]
    public void SimpleExcept() {
      string[] first = { "a", "b", "c", "e" };
      string[] second = { "b", "c", "d" };
      string[] expected = { "a", "e" };

      var result = first.Except(second);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void SimpleExceptWithNullComparerUsesDefaultComparer() {
      string[] first = { "a", "b", "c", "e" };
      string[] second = { "b", "c", "d" };
      string[] expected = { "a", "e" };

      var result = first.Except(second, null);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void SimpleExceptWithNonDefaultComparer() {
      string[] first = { "a", "b", "c", "e" };
      string[] second = { "b", "C", "d" };
      string[] expected = { "a", "e" };

      var result = first.Except(second, StringComparer.OrdinalIgnoreCase);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void ExceptWithMultipleValuesOnlyContainsSingleCopy() {
      string[] first = { "a", "b", "c", "a", "c", "e" };
      string[] second = { "b", "c", "d", "b" };
      string[] expected = { "a", "e" };

      var result = first.Except(second);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void ExceptWithMultipleValuesOnlyContainsSingleCopyWithComparer() {
      string[] first = { "a", "b", "c", "B", "c", "B", "e" };
      string[] second = { "c", "d", "B", "B" };
      string[] expected = { "a", "e" };

      var result = first.Except(second, StringComparer.OrdinalIgnoreCase);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void SequencesArentReadUntilIterated() {
      var first = new ThrowingEnumerable();
      var second = new ThrowingEnumerable();

      var query = first.Except(second);

      using var iterator = query.GetEnumerator();
      Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
    }

    [Fact]
    public void SecondSequenceIsReadFullyOnFirstResult() {
      int[] first = { 1, 2, 3 };
      var secondQuery = new[] { 8, 2, 0 }.Select(x => 8 / x);

      var query = first.Except(secondQuery);
      using var iterator = query.GetEnumerator();

      Assert.Throws<DivideByZeroException>(() => iterator.MoveNext());
    }
  }
}
