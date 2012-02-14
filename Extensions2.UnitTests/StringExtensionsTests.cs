﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Extensions2.UnitTests
{
    public class StringExtensionsFacts
    {
        public class SubstringOnIndexTests
        {
            private const string SomeArbitraryString = "someArbitraryString";

            [Fact]
            public void Throws_WhenStartPositionIsNegative()
            {
                int startPosition = -10;
                int endPosition = 5;
                Assert.Throws<ArgumentException>(
                    () => SomeArbitraryString.SubstringOnIndex(startPosition, endPosition));
            }

            [Fact]
            public void Throws_WhenEndPositionIsLessThanStartPosition()
            {
                int startPosition = 20;
                int endPosition = 10;
                Assert.Throws<ArgumentException>(
                    () => SomeArbitraryString.SubstringOnIndex(startPosition, endPosition));
            }

            [Fact]
            public void Throws_WhenEndPositionIsBiggerThenStringLength()
            {
                int startPosition = 5;
                int endPosition = 100;
                Assert.Throws<ArgumentException>(
                    () => SomeArbitraryString.SubstringOnIndex(startPosition, endPosition));
            }

            [Fact]
            public void Throws_WhenStringIsNull()
            {
                Assert.Throws<ArgumentException>(() => (null as string).SubstringOnIndex(0, 10));
            }

            [Fact]
            public void Throws_WhenParameterStringIsEmpty()
            {
                Assert.Throws<ArgumentException>(() => string.Empty.SubstringOnIndex(10, 15).Length);
            }

            [Fact]
            public void ReturnsCorrectResult_WhenSourceContainsSubstring()
            {
                Assert.True("Hello world".SubstringOnIndex(0, 4).Equals("Hello"));
            }

            [Fact]
            public void ReturnsCorrectResult_WhenSourceDoesntContainSubstring()
            {
                Assert.False(SomeArbitraryString.SubstringOnIndex(2, 6).Equals("Hello"));
            }
        }

        public class SubstringCountTests
        {
            [Fact]
            public void ReturnsZero_WhenNoSubstringsFound()
            {
                Assert.True("SomeString".SubstringCount("Hello") == 0);
            }

            [Fact]
            public void Throws_IfSourceIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => (null as string).SubstringCount("hello"));
            }
        }
    }
}
