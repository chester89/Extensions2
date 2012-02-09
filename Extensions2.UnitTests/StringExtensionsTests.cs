using System;
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
            private string someArbitraryString = "someArbitraryString";

            [Fact]
            public void Throws_WhenStartPositionIsNegative()
            {
                int startPosition = -10;
                int endPosition = 5;
                Assert.Throws<ArgumentException>(
                    () => someArbitraryString.SubstringOnIndex(startPosition, endPosition));
            }

            [Fact]
            public void Throws_WhenEndPositionIsNegative()
            {
                int startPosition = 7;
                int endPosition = -3;
                Assert.Throws<ArgumentException>(
                    () => someArbitraryString.SubstringOnIndex(startPosition, endPosition));
            }

            [Fact]
            public void Throws_WhenEndPositionIsLessThanStartPosition()
            {
                int startPosition = 20;
                int endPosition = 10;
                Assert.Throws<ArgumentException>(
                    () => someArbitraryString.SubstringOnIndex(startPosition, endPosition));
            }

            [Fact]
            public void Throws_WhenEndPositionIsBiggerThenStringLength()
            {
                int startPosition = 5;
                int endPosition = 100;
                Assert.Throws<ArgumentException>(
                    () => someArbitraryString.SubstringOnIndex(startPosition, endPosition));
            }

            [Fact]
            public void Throws_WhenStringIsNull()
            {
                Assert.Throws<ArgumentException>(() => (null as string).SubstringOnIndex(0, 10));
            }

            [Fact]
            public void ReturnsEmptyString_WhenParameterStringIsEmpty()
            {
                Assert.Equal(0, string.Empty.SubstringOnIndex(10, 15).Length);
            }

            [Fact]
            public void ReturnsCorrectResult()
            {
                Assert.True("Hello world".SubstringOnIndex(0, 4).Equals("Hello"));
            }
        }

    }
}
