using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Extensions;
using Xunit.Sdk;

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
                Assert.Throws<TraceAssertException>(() => SomeArbitraryString.SubstringOnIndex(startPosition, endPosition));
            }

            [Fact]
            public void Throws_WhenEndPositionIsLessThanStartPosition()
            {
                int startPosition = 20;
                int endPosition = 10;
                Assert.Throws<TraceAssertException>(() => SomeArbitraryString.SubstringOnIndex(startPosition, endPosition));
            }

            [Fact]
            public void Throws_WhenEndPositionIsBiggerThenStringLength()
            {
                int startPosition = 5;
                int endPosition = 100;
                Assert.Throws<TraceAssertException>(() => SomeArbitraryString.SubstringOnIndex(startPosition, endPosition));
            }

            [Fact]
            public void Throws_WhenStringIsNull()
            {
                Assert.Throws<TraceAssertException>(() => (null as string).SubstringOnIndex(0, 10));
            }

            [Fact]
            public void Throws_WhenParameterStringIsEmpty()
            {
                Assert.Throws<TraceAssertException>(() => string.Empty.SubstringOnIndex(10, 15).Length);
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
            [Theory]
            [InlineData("Hello world", "Nope", 0)]
            [InlineData("Hello world", "Hell", 1)]
            [InlineData("Something wrong in the winter", "th", 2)]
            public void ReturnsProperResult(string source, string substring, int expectedCount)
            {
                Assert.True(source.SubstringCount(substring) == expectedCount);
            }          

            [Fact]
            public void Throws_IfSourceIsNull()
            {
                Assert.Throws<TraceAssertException>(() => (null as string).SubstringCount("hello"));
            }
        }

        public class ContainsAnyCharactersTests
        {
            [Theory]
            [InlineData("hello world", new [] { 'l' })]
            [InlineData("this was one hell of a ride", new [] { 'e' })]
            [InlineData("We're very convinced we can Stop this", new [] { 'c', 'r' })]
            public void Returns_True_When_Characters_Has_Multiple_Occurences(string input, Char[] chars)
            {
                Assert.True(input.ContainsAny(chars));
            }

            [Theory]
            [InlineData("Doug missed his flyght today", new [] { 'f' })]
            [InlineData("This can't be done on time, I'm afraid", new [] { 'I' })]
            public void Returns_True_When_Characters_HasOneOccurence(string input, Char[] chars)
            {
                Assert.True(input.ContainsAny(chars));
            }

            [Theory]
            [InlineData("We're running out of time", new [] { 'h', 'q', 'p' })]
            [InlineData("This would be much easier if we stop them", new [] { 'k', 'q' })]
            public void Returns_False_When_Character_HasNoOcurrences(String input, Char[] chars)
            {
                Assert.False(input.ContainsAny(chars));
            }

            [Theory]
            [InlineData("That shouldn't happened if you did a better job", new [] { 'S' })]
            [InlineData("You made tremendous effort", new [] { 'F' })]
            public void Returns_False_When_Character_Present_But_Casing_Doesnt_Match(string input, Char[] chars)
            {
                Assert.False(input.ContainsAny(chars));
            }
        }

        public class SubstringPositionsTests
        {
            [Theory]
            [InlineData("How did you get in here?", "times")]
            [InlineData("It was not part of the plan", "parts")]
            public void Should_Return_EmptySequence_When_There_Are_NoSubstringOccurrences(string input, string sub)
            {
                Assert.False(input.SubstringPositions(sub).Any());
            }

            [Theory]
            [InlineData("Where are you? Are you at home or at work?", "you", new [] { 10, 19 })]
            [InlineData("Where are you? Are you at home or at work?", "at", new [] { 23, 34 })]
            [InlineData("Because of several major failures, we are unable to do this right now, and of course we are sincerely sorry", "we", new [] { 35, 85 })]
            public void Should_Return_Right_Sequence_Where_There_Are_Occurences(string input, string sub, int[] positions)
            {
                Assert.Equal(input.SubstringPositions(sub), positions);
            }
        }
    }
}
