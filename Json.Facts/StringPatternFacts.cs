using Json.Basics;
using Xunit;

namespace Json.Facts
{
    public class StringPatternFacts
    {
        [Fact]
        public void IsWrappedInDoubleQuotes()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted("abc"));
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void AlwaysStartsWithQuotes()
        {
            var pattern = new StringPattern();
            var match = pattern.Match("abc\"");
            Assert.False(match.Success());
            Assert.Equal("abc\"", match.RemainingText());
        }

        [Fact]
        public void AlwaysEndsWithQuotes()
        {
            var pattern = new StringPattern();
            var match = pattern.Match("\"abc");
            Assert.False(match.Success());
            Assert.Equal("\"abc", match.RemainingText());
        }

        [Fact]
        public void IsNotNull()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(null);
            Assert.False(match.Success());
            Assert.Null(match.RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var pattern = new StringPattern();
            var match = pattern.Match("");
            Assert.False(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void IsAnEmptyDoubleQuotedString()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(""));
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void DoesNotContainControlCharacters()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted("a\nb\rc"));
            Assert.False(match.Success());
            Assert.Equal(Quoted("a\nb\rc"), match.RemainingText());
        }

        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted("⛅⚾"));
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanContainEscapedQuotationMark()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"\""a\"" b"));
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"a \\ b"));
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanContainEscapedSolidus()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"a \/ b"));
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"a \b b"));
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanContainEscapedFormFeed()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"a \f b"));
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanContainEscapedLineFeed()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"a \n b"));
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanContainEscapedCarrigeReturn()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"a \r b"));
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanContainEscapedHorizontalTab()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"a \t b"));
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"a \u26Be b"));
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanContainAnyMultipleEscapeSequences()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"\\\u1212\n\t\r\\\b"));
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void DoesNotContainUnrecognizedEscapeCharacters()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"a\x"));
            Assert.False(match.Success());
            Assert.Equal(Quoted(@"a\x"), match.RemainingText());
        }

        [Fact]
        public void DoesNotEndWithReverseSolidus()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"a\"));
            Assert.False(match.Success());
            Assert.Equal(Quoted(@"a\"), match.RemainingText());
        }

        [Fact]
        public void DoesNotEndWithAnUnfinishedHexNumber()
        {
            var pattern = new StringPattern();
            var match1 = pattern.Match(Quoted(@"a\u"));
            Assert.False(match1.Success());
            Assert.Equal(Quoted(@"a\u"), match1.RemainingText());

            var match2 = pattern.Match(Quoted(@"a\u123"));
            Assert.False(match2.Success());
            Assert.Equal(Quoted(@"a\u123"), match2.RemainingText());
        }

        [Fact]
        public void DoesNotContainAnyUnfinishedHexNumber()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"a\u123 a\u1234"));
            Assert.False(match.Success());
            Assert.Equal(Quoted(@"a\u123 a\u1234"), match.RemainingText());
        }

        [Fact]
        public void DoesNotContainImproperHexNumber()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"a\u123k a\u1234z"));
            Assert.False(match.Success());
            Assert.Equal(Quoted(@"a\u123k a\u1234z"), match.RemainingText());
        }

        [Fact]
        public void DoesNotEndWithAnImproperHexNumber()
        {
            var pattern = new StringPattern();
            var match = pattern.Match(Quoted(@"a\u123k"));
            Assert.False(match.Success());
            Assert.Equal(Quoted(@"a\u123k"), match.RemainingText());
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}