using Json.Basics;
using Xunit;

namespace Json.Facts
{
    public class ManyFacts
    {
        [Fact]
        public void SingleCharacterMatch()
        {
            var a = new Many(new Character('a'));
            var match = a.Match("abc");
            Assert.True(match.Success());
            Assert.Equal("bc", match.RemainingText());
        }

        [Fact]
        public void MultipleCharacterMatch()
        {
            var a = new Many(new Character('a'));
            var match = a.Match("aaaabc");
            Assert.True(match.Success());
            Assert.Equal("bc", match.RemainingText());
        }

        [Fact]
        public void NoMatch()
        {
            var a = new Many(new Character('a'));
            var match = a.Match("bc");
            Assert.True(match.Success());
            Assert.Equal("bc", match.RemainingText());
        }

        [Fact]
        public void EmptyText()
        {
            var a = new Many(new Character('a'));
            var match = a.Match("");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void NullText()
        {
            var a = new Many(new Character('a'));
            var match = a.Match(null);
            Assert.True(match.Success());
            Assert.Null(match.RemainingText());
        }

        [Fact]
        public void DigitsMatch()
        {
            var digits = new Many(new Range('0', '9'));
            var match = digits.Match("12345ab123");
            Assert.True(match.Success());
            Assert.Equal("ab123", match.RemainingText());
        }

        [Fact]
        public void NoDigitsMatch()
        {
            var digits = new Many(new Range('0', '9'));
            var match = digits.Match("ab");
            Assert.True(match.Success());
            Assert.Equal("ab", match.RemainingText());
        }
    }
}