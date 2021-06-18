using System;
using System.Collections.Generic;
using Xunit;

namespace LinqRebuilt.Tests
{
  public class UnionTests
  {
    [Fact]
    public void NullFirstThrowsArgumentNullExceptionNoComparer() {
      string[] first = null;
      string[] second = { "abc", "def", "ghi" };

      Assert.Throws<ArgumentNullException>(() => first.Union(second));
    }

    [Fact]
    public void NullSecondThrowsArgumentNullExceptionNoComparer() {
      string[] first = { "abc", "def", "ghi" };
      string[] second = null;

      Assert.Throws<ArgumentNullException>(() => first.Union(second));
    }

    [Fact]
    public void NullFirstThrowsArgumentNullExceptionWithComparer() {
      string[] first = null;
      string[] second = { "abc", "def", "ghi" };

      Assert.Throws<ArgumentNullException>(() => first.Union(second, StringComparer.Ordinal));
    }

    [Fact]
    public void NullSecondThrowsArgumentNullExceptionWithComparer() {
      string[] first = { "abc", "def", "ghi" };
      string[] second = null;

      Assert.Throws<ArgumentNullException>(() => first.Union(second, StringComparer.Ordinal));
    }

    [Fact]
    public void NormalWithoutComparer() {
      string[] first = { "a", "b", "c", "C", "b" };
      string[] second = { "e", "A", "a", "b" };
      string[] expected = { "a", "b", "c", "C", "e", "A" };

      Assert.Equal(expected, first.Union(second));
    }

    [Fact]
    public void NormalWithNullComparer() {
      string[] first = { "a", "b", "c", "C", "b" };
      string[] second = { "e", "A", "a", "b" };
      string[] expected = { "a", "b", "c", "C", "e", "A" };

      Assert.Equal(expected, first.Union(second, null));
    }

    [Fact]
    public void NormalWithComparer() {
      string[] first = { "a", "b", "c", "C", "b" };
      string[] second = { "e", "A", "a", "b" };
      string[] expected = { "a", "b", "c", "e" };

      Assert.Equal(expected, first.Union(second, StringComparer.OrdinalIgnoreCase));
    }

    [Fact]
    public void EmptyFirstSequence() {
      string[] first = Array.Empty<string>();
      string[] second = { "abc", "def", "abc" };
      string[] expected = { "abc", "def" };

      Assert.Equal(expected, first.Union(second));
    }

    [Fact]
    public void EmptySecondSequence() {
      string[] first = { "abc", "def", "abc" };
      string[] second = Array.Empty<string>();
      string[] expected = { "abc", "def" };

      Assert.Equal(expected, first.Union(second));
    }

    [Fact]
    public void EmptyBothSequences() {
      string[] first = Array.Empty<string>();
      string[] second = Array.Empty<string>();
      string[] expected = Array.Empty<string>();

      Assert.Equal(expected, first.Union(second));
    }

    [Fact]
    public void FirstSequenceIsntEvaluatedUntilIterationOccurs() {
      IEnumerable<int> first = new Helpers.ThrowingEnumerable();
      int[] second = { 1, 2, 1 };

      var query = first.Union(second);
      using var iterator = query.GetEnumerator();

      Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
    }

    [Fact]
    public void SecondSequenceIsntEvaluatedUntilFirstSequenceIsComplete() {
      int[] first = { 1 };
      IEnumerable<int> second = new Helpers.ThrowingEnumerable();

      var query = first.Union(second);
      using var iterator = query.GetEnumerator();
      iterator.MoveNext();

      Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
    }
  }
}
