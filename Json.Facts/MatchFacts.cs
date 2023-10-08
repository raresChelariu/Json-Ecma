using Json.Basics;
using Xunit;

namespace Json.Facts
{
    public class MatchFacts
    {
        [Fact]
        public void MatchSuccess()
        {
            var match = new Match(true, "remaining");
            Assert.True(match.Success());
        }

        [Fact]
        public void MatchFailure()
        {
            var match = new Match(false, "remaining");
            Assert.False(match.Success());
        }

        [Fact]
        public void MatchRemainingText()
        {
            var match = new Match(true, "remaining");
            Assert.Equal("remaining", match.RemainingText());
        }
    }
}