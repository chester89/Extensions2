using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Extensions2
{
    public static class StringExtensions
    {
        /// <summary>
        ///   Determines whether a string contains any characters from the <paramref name = "characters" /> array
        /// </summary>
        /// <returns>If string contains at least one character, returns true; otherwise, false</returns>
        public static bool ContainsAny(this string source, params char[] characters)
        {
            return characters.Select(character => source.IndexOf(character)).Any(result => result != -1);
        }

        /// <summary>
        ///   Determines whether a string contains any substrings from the <paramref name = "elements" /> array
        /// </summary>
        /// <returns>If string contains at least one substring, returns true; otherwise, false</returns>
        public static bool ContainsAny(this string source, params string[] elements)
        {
            return elements.Any(source.Contains);
        }

        /// <summary>
        /// Checks if <paramref name="source"/> starts with any string from <paramref name="elements"/> array
        /// </summary>
        /// <returns>True if <paramref name="source"/> starts with at least one element from <paramref name="elements"/>; otherwise, false</returns>
        public static bool StartsWithAny(this string source, params string[] elements)
        {
            return elements.Any(source.StartsWith);
        }

        /// <summary>
        /// Checks if <paramref name="source"/> ends with any string from <paramref name="elements"/> array
        /// </summary>
        /// <returns>True if <paramref name="source"/> ends with at least one element from <paramref name="elements"/>; otherwise, false</returns>
        public static bool EndsWithAny(this string source, params string[] elements)
        {
            return elements.Any(source.EndsWith);
        }

        /// <summary>
        /// Checks if <paramref name="elements"/> contains a <paramref name="source"/>
        /// </summary>
        /// <returns>True if <paramref name="elements"/> contains <paramref name="source"/>; otherwise, false</returns>
        public static bool IsAnyOf(this string source, params string[] elements)
        {
            return elements.Any(source.Equals);
        }

        public static bool IsNotAnyOf(this string source, params string[] elements)
        {
            return !IsAnyOf(source, elements);
        }

        /// <summary>
        /// Removes all occurences of all <paramref name="characters"/> elements from initial string
        /// </summary>
        public static string RemoveAll(this string source, params char[] characters)
        {
            foreach (var ch in characters)
            {
                var firstOccurrence = source.IndexOf(ch);
                while (firstOccurrence != -1)
                {
                    source = source.SubstringOnIndex(0, firstOccurrence - 1) + source.SubstringOnIndex(firstOccurrence + 1, source.Length - 1);
                    firstOccurrence = source.IndexOf(ch);
                }
            }
            return source;
        }

        /// <summary>
        /// Removes all occurences of all <paramref name="toRemove"/> elements from initial string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toRemove"></param>
        /// <returns></returns>
        public static string RemoveAll(this string source, params string[] toRemove)
        {
            foreach (var s in toRemove)
            {
                var firstOccurrence = source.IndexOf(s);
                while (firstOccurrence != -1)
                {
                    source = source.SubstringOnIndex(0, firstOccurrence - 1) + source.SubstringOnIndex(firstOccurrence + s.Length, source.Length - 1);
                    firstOccurrence = source.IndexOf(s);
                }
            }
            return source;
        }

        /// <summary>
        ///   Gets a substring from <paramref name = "startPosition" /> to <paramref name = "endPosition" />
        /// </summary>
        /// <param name = "startPosition">Zero-based starting position of a substring</param>
        /// <param name = "endPosition">Zero-based ending position of a substring</param>
        public static string SubstringOnIndex(this string source, int startPosition, int endPosition)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(source));
            Contract.Requires<ArgumentException>(startPosition >= 0);
            Contract.Requires<ArgumentException>(endPosition >= startPosition);
            Contract.Requires<ArgumentException>(endPosition < source.Length);
            return source.Substring(startPosition, endPosition - startPosition + 1);
        }

        /// <summary>
        ///   Gets a number of occurences of <paramref name = "substring" /> inside <paramref name = "source" />
        /// </summary>
        public static int SubstringCount(this string source, string substring)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            var result = 0;
            if (source.Contains(substring))
            {
                while (source.Contains(substring))
                {
                    result += 1;
                    var firstPosition = source.IndexOf(substring);
                    var head = string.Empty;
                    if (firstPosition > 1)
                    {
                        head = source.SubstringOnIndex(0, firstPosition - 1);
                    }
                    source = head + source.Substring(firstPosition + substring.Length);
                }
            }
            return result;
        }
    }
}
