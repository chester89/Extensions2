using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions2
{
    public static class CommonExtensions
    {
        /// <summary>
        /// indicates whether given value lays in given bounds
        /// </summary>
        /// <param name="lower">lower bound</param>
        /// <param name="upper">upper bound</param>
        /// <returns>true if value is between boundaries; otherwise false</returns>
        public static Boolean Between<T>(this T actual, T lower, T upper)
            where T : IComparable<T>
        {
            return (actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) < 0);
        }

        /// <summary>
        /// indicates whether given value is included in list
        /// </summary>
        /// <returns>true if value is within list; otherwise false</returns>
        public static Boolean In<T>(this T source, params T[] list) where T: class
        {
            if (source == null)
                throw new ArgumentNullException("source");
            return list.Contains(source);
        }

        public static Boolean IsNullOrDefault<T>(this T source) where T:class 
        {
            return (source == null || source.Equals(default(T)));
        }
    }
}
