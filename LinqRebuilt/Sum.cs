using System;
using System.Collections.Generic;

namespace LinqRebuilt
{
    public static partial class Enumerable
    {
        #region int

        public static int Sum(this IEnumerable<int> source)
        {
            return Sum(source, x => x);
        }

        public static int? Sum(this IEnumerable<int?> source)
        {
            return Sum(source, x => x);
        }

        public static int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }
            checked
            {
                int result = 0;
                foreach (TSource item in source)
                {
                    result += selector(item);
                }
                return result;
            }
        }

        public static int? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }
            checked
            {
                int result = 0;
                foreach (TSource item in source)
                {
                    result += selector(item).GetValueOrDefault();
                }
                return result;
            }
        }

        #endregion

        #region double

        public static double Sum(this IEnumerable<double> source)
        {
            return Sum(source, x => x);
        }

        public static double? Sum(this IEnumerable<double?> source)
        {
            return Sum(source, x => x);
        }

        public static double Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            double result = 0;
            foreach (TSource item in source)
            {
                result += selector(item);
            }
            return result;
        }

        public static double? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            double result = 0;
            foreach (TSource item in source)
            {
                result += selector(item).GetValueOrDefault();
            }
            return result;
        }

        #endregion

        #region float

        public static float Sum(this IEnumerable<float> source)
        {
            return Sum(source, x => x);
        }

        public static float? Sum(this IEnumerable<float?> source)
        {
            return Sum(source, x => x);
        }

        public static float Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            float result = 0;
            foreach (TSource item in source)
            {
                result += selector(item);
            }
            return result;
        }

        public static float? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            float result = 0;
            foreach (TSource item in source)
            {
                result += selector(item).GetValueOrDefault();
            }
            return result;
        }

        #endregion
    }
}