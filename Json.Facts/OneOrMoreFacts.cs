using Json.Basics;
using Xunit;

namespace Json.Facts
{
    public class OneOrMoreFacts
    {
        [Fact]
        public void OneOrMoreDigits()
        {
            var a = new OneOrMore(new Range('0', '9'));
            var match = a.Match("123");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void OneOrMoreDigits_ExtraCharacter()
        {
            var a = new OneOrMore(new Range('0', '9'));
            var match = a.Match("1a");
            Assert.True(match.Success());
            Assert.Equal("a", match.RemainingText());
        }

        [Fact]
        public void OneOrMore_NoMatch()
        {
            var a = new OneOrMore(new Range('0', '9'));
            var match = a.Match("bc");
            Assert.False(match.Success());
            Assert.Equal("bc", match.RemainingText());
        }

        [Fact]
        public void OneOrMore_EmptyString()
        {
            var a = new OneOrMore(new Range('0', '9'));
            var match = a.Match("");
            Assert.False(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void OneOrMore_NullString()
        {
            var a = new OneOrMore(new Range('0', '9'));
            var match = a.Match(null);
            Assert.False(match.Success());
            Assert.Null(match.RemainingText());
        }
    }
}