using System;
using Xunit;

namespace LinqRebuilt.Tests
{
  public class SumTests
  {
        #region Int

        [Fact]
        public void IntNullSourceThrowsArgumentNullException()
        {
            int[] source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Fact]
        public void IntNullSourceNullableThrowsArgumentNullException()
        {
            int?[] source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Fact]
        public void IntNullSourceWithSelectorThrowsArgumentNullException()
        {
            string[] source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(s => s.Length));
        }

        [Fact]
        public void IntNullSourceNullableWithSelectorThrowsArgumentNullException()
        {
            string?[] source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(s => s.Length));
        }

        [Fact]
        public void IntNullSelectorThrowsArgumentNullException()
        {
            int[] source = { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => source.Sum(null));
        }

        [Fact]
        public void IntNullableNullSelectorThrowsArgumentNullException()
        {
            int?[] source = { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => source.Sum(null));
        }

        [Fact]
        public void IntSimpleSequenceResultsInExpectedValue()
        {
            int[] source = { 1, 2, 3 };
            var expected = 6;
            Assert.Equal(expected, source.Sum());
        }

        [Fact]
        public void IntEmptySequenceResultsInZero()
        {
            int[] source = Array.Empty<int>();
            var expected = 0;
            Assert.Equal(expected, source.Sum());
        }

        [Fact]
        public void IntNullableSimpleSequenceResultsInValue()
        {
            int?[] source = { 1, null, 2, null, 3 };
            var expected = 6;
            int? result = source.Sum();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IntNullableSequenceOfNullsResultsInZero()
        {
            int?[] source = { null, null, null };
            var expected = 0;
            int? result = source.Sum();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IntSimpleSequenceWithSelectorResultsInExpectedValue()
        {
            string[] source = { "keven", "nancy", "mark", "jim" };
            var expected = 17;
            int result = source.Sum(s => s.Length);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IntNullableSimpleSequenceResultsInValueWithSelector()
        {
            string[] source = { "keven", "carrot", "nancy", "carrot", "mark", "jim" };
            var expected = 17;
            int? result = source.Sum(s => s == "carrot" ? null : s.Length);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IntNegativeOverflow()
        {
            int[] source = { int.MinValue, int.MinValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Fact]
        public void IntOverflow()
        {
            int[] source = { int.MaxValue, int.MaxValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Fact]
        public void IntNegativeOverFlowWithSelector()
        {
            string[] source = { "a", "b" };
            Assert.Throws<OverflowException>(() => source.Sum(x => int.MinValue));
        }

        [Fact]
        public void IntOverflowWithSelector()
        {
            string[] source = { "a", "b" };
            Assert.Throws<OverflowException>(() => source.Sum(x => int.MaxValue));
        }

        #endregion

        #region double
        [Fact]
        public void DoubleNullSelectorThrowsArgumentNullException()
        {
            double[] source = { 1.3, 2.2, 3.5 };
            Assert.Throws<ArgumentNullException>(() => source.Sum(null));
        }

        [Fact]
        public void DoubleNullableNullSelectorThrowsArgumentNullException()
        {
            double?[] source = { 1.3, 2.2, 3.5 };
            Assert.Throws<ArgumentNullException>(() => source.Sum(null));
        }

        [Fact]
        public void DoubleSimpleSequenceResultsInExpectedValue()
        {
            double[] source = { 1.3, 2.2, 3.4 };
            var expected = 6.9;
            Assert.Equal(expected, source.Sum());
        }

        [Fact]
        public void DoubleEmptySequenceResultsInZero()
        {
            double[] source = Array.Empty<double>();
            var expected = 0.0;
            Assert.Equal(expected, source.Sum());
        }

        [Fact]
        public void DoubleNullableSimpleSequenceResultsInValue()
        {
            double?[] source = { 1.3, null, 2.2, null, 3.4 };
            var expected = 6.9;
            double? result = source.Sum();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DoubleNullableSequenceOfNullsResultsInZero()
        {
            double?[] source = { null, null, null };
            var expected = 0.0;
            double? result = source.Sum();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DoubleNegativeOverflow()
        {
            double[] source = { double.MinValue, double.MinValue };
            double result = source.Sum();
            Assert.True(double.IsInfinity(result));
        }

        [Fact]
        public void DoubleOverflow()
        {
            double[] source = { double.MaxValue, double.MaxValue };
            double result = source.Sum();
            Assert.True(double.IsInfinity(result));
        }

        [Fact]
        public void DoubleSimpleSequenceWithSelectorResultsInExpectedValue()
        {
            string[] source = { "keven", "nancy", "mark", "jim" };
            var expected = 17;
            double result = source.Sum(s => (double) s.Length);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DoubleNullableSimpleSequenceResultsInValueWithSelector()
        {
            string[] source = { "keven", "carrot", "nancy", "carrot", "mark", "jim" };
            var expected = 17;
            double? result = source.Sum(s => s == "carrot" ? null : (double) s.Length);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DoubleNegativeOverFlowWithSelector()
        {
            string[] source = { "a", "b" };
            double result = source.Sum(x => double.MinValue);
            Assert.True(double.IsNegativeInfinity(result));
        }

        [Fact]
        public void DoubleOverflowWithSelector()
        {
            string[] source = { "a", "b" };
            double result = source.Sum(x => double.MaxValue);
            Assert.True(double.IsPositiveInfinity(result));
        }

        #endregion

        #region float
        [Fact]
        public void FloatNullSelectorThrowsArgumentNullException()
        {
            float[] source = { 1.3f, 2.2f, 3.5f };
            Assert.Throws<ArgumentNullException>(() => source.Sum(null));
        }

        [Fact]
        public void FloatNullableNullSelectorThrowsArgumentNullException()
        {
            float?[] source = { 1.3f, 2.2f, 3.5f };
            Assert.Throws<ArgumentNullException>(() => source.Sum(null));
        }

        [Fact]
        public void FloatSimpleSequenceResultsInExpectedValue()
        {
            float[] source = { 1.3f, 2.2f, 3.4f };
            var expected = 6.9f;
            Assert.Equal(expected, source.Sum());
        }

        [Fact]
        public void FloatEmptySequenceResultsInZero()
        {
            float[] source = Array.Empty<float>();
            var expected = 0.0f;
            Assert.Equal(expected, source.Sum());
        }

        [Fact]
        public void FloatNullableSimpleSequenceResultsInValue()
        {
            float?[] source = { 1.3f, null, 2.2f, null, 3.4f };
            var expected = 6.9f;
            float? result = source.Sum();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FloatNullableSequenceOfNullsResultsInZero()
        {
            float?[] source = { null, null, null };
            var expected = 0.0f;
            float? result = source.Sum();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FloatNegativeOverflow()
        {
            float[] source = { float.MinValue, float.MinValue };
            float result = source.Sum();
            Assert.True(float.IsInfinity(result));
        }

        [Fact]
        public void FloatOverflow()
        {
            float[] source = { float.MaxValue, float.MaxValue };
            float result = source.Sum();
            Assert.True(float.IsInfinity(result));
        }

        [Fact]
        public void FloatSimpleSequenceWithSelectorResultsInExpectedValue()
        {
            string[] source = { "keven", "nancy", "mark", "jim" };
            var expected = 17;
            float result = source.Sum(s => (float)s.Length);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FloatNullableSimpleSequenceResultsInValueWithSelector()
        {
            string[] source = { "keven", "carrot", "nancy", "carrot", "mark", "jim" };
            var expected = 17;
            float? result = source.Sum(s => s == "carrot" ? null : (float)s.Length);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FloatNegativeOverFlowWithSelector()
        {
            string[] source = { "a", "b" };
            float result = source.Sum(x => float.MinValue);
            Assert.True(float.IsNegativeInfinity(result));
        }

        [Fact]
        public void FloatOverflowWithSelector()
        {
            string[] source = { "a", "b" };
            float result = source.Sum(x => float.MaxValue);
            Assert.True(float.IsPositiveInfinity(result));
        }

        #endregion
        
        #region decimal
        [Fact]
        public void DecimalNullSelectorThrowsArgumentNullException()
        {
            decimal[] source = { 1.3m, 2.2m, 3.5m };
            Assert.Throws<ArgumentNullException>(() => source.Sum(null));
        }

        [Fact]
        public void DecimalNullableNullSelectorThrowsArgumentNullException()
        {
            decimal?[] source = { 1.3m, 2.2m, 3.5m };
            Assert.Throws<ArgumentNullException>(() => source.Sum(null));
        }

        [Fact]
        public void DecimalSimpleSequenceResultsInExpectedValue()
        {
            decimal[] source = { 1.3m, 2.2m, 3.4m };
            const decimal expected = 6.9m;
            Assert.Equal(expected, source.Sum());
        }

        [Fact]
        public void DecimalEmptySequenceResultsInZero()
        {
            decimal[] source = Array.Empty<decimal>();
            const decimal expected = 0.0m;
            Assert.Equal(expected, source.Sum());
        }

        [Fact]
        public void DecimalNullableSimpleSequenceResultsInValue()
        {
            decimal?[] source = { 1.3m, null, 2.2m, null, 3.4m };
            const decimal expected = 6.9m;
            decimal? result = source.Sum();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DecimalNullableSequenceOfNullsResultsInZero()
        {
            decimal?[] source = { null, null, null };
            const decimal expected = 0.0m;
            decimal? result = source.Sum();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DecimalSimpleSequenceWithSelectorResultsInExpectedValue()
        {
            string[] source = { "keven", "nancy", "mark", "jim" };
            const decimal expected = 17m;
            decimal result = source.Sum(s => s.Length);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DecimalNullableSimpleSequenceResultsInValueWithSelector()
        {
            string[] source = { "keven", "carrot", "nancy", "carrot", "mark", "jim" };
            const decimal expected = 17m;
            decimal? result = source.Sum(s => s == "carrot" ? null : s.Length);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DecimalNegativeOverflow()
        {
            decimal[] source = { decimal.MinValue, decimal.MinValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Fact]
        public void DecimalOverflow()
        {
            decimal[] source = { decimal.MaxValue, decimal.MaxValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Fact]
        public void DecimalNegativeOverFlowWithSelector()
        {
            string[] source = { "a", "b" };
            Assert.Throws<OverflowException>(() => source.Sum(x => decimal.MinValue));
        }

        [Fact]
        public void DecimalOverflowWithSelector()
        {
            string[] source = { "a", "b" };
            Assert.Throws<OverflowException>(() => source.Sum(x => decimal.MaxValue));
        }

        #endregion

        #region Long

        [Fact]
        public void LongNullSourceThrowsArgumentNullException()
        {
            long[] source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Fact]
        public void LongNullSourceNullableThrowsArgumentNullException()
        {
            long?[] source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Fact]
        public void LongNullSourceWithSelectorThrowsArgumentNullException()
        {
            string[] source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(s => s.Length));
        }

        [Fact]
        public void LongNullSourceNullableWithSelectorThrowsArgumentNullException()
        {
            string?[] source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(s => s.Length));
        }

        [Fact]
        public void LongNullSelectorThrowsArgumentNullException()
        {
            long[] source = { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => source.Sum(null));
        }

        [Fact]
        public void LongNullableNullSelectorThrowsArgumentNullException()
        {
            long?[] source = { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => source.Sum(null));
        }

        [Fact]
        public void LongSimpleSequenceResultsInExpectedValue()
        {
            long[] source = { 1, 2, 3 };
            var expected = 6;
            Assert.Equal(expected, source.Sum());
        }

        [Fact]
        public void LongEmptySequenceResultsInZero()
        {
            long[] source = Array.Empty<long>();
            var expected = 0;
            Assert.Equal(expected, source.Sum());
        }

        [Fact]
        public void LongNullableSimpleSequenceResultsInValue()
        {
            long?[] source = { 1, null, 2, null, 3 };
            var expected = 6;
            long? result = source.Sum();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void LongNullableSequenceOfNullsResultsInZero()
        {
            long?[] source = { null, null, null };
            var expected = 0;
            long? result = source.Sum();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void LongSimpleSequenceWithSelectorResultsInExpectedValue()
        {
            string[] source = { "keven", "nancy", "mark", "jim" };
            var expected = 17;
            long result = source.Sum(s => s.Length);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void LongNullableSimpleSequenceResultsInValueWithSelector()
        {
            string[] source = { "keven", "carrot", "nancy", "carrot", "mark", "jim" };
            var expected = 17;
            long? result = source.Sum(s => s == "carrot" ? null : s.Length);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void LongNegativeOverflow()
        {
            long[] source = { long.MinValue, long.MinValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Fact]
        public void LongOverflow()
        {
            long[] source = { long.MaxValue, long.MaxValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Fact]
        public void LongNegativeOverFlowWithSelector()
        {
            string[] source = { "a", "b" };
            Assert.Throws<OverflowException>(() => source.Sum(x => long.MinValue));
        }

        [Fact]
        public void LongOverflowWithSelector()
        {
            string[] source = { "a", "b" };
            Assert.Throws<OverflowException>(() => source.Sum(x => long.MaxValue));
        }

        #endregion

    }
}
