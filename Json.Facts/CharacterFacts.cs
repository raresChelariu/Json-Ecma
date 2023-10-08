using Json.Basics;
using Xunit;

namespace Json.Facts
{
    public class CharacterFacts
    {
        [Fact]
        public void TestCharacterMatch_Lowercasexenia()
        {
            var character = new Character('x');
            var result = character.Match("xenia");
            Assert.True(result.Success());
        }

        [Fact]
        public void TestCharacterMatch_Xenia()
        {
            var character = new Character('x');
            var result = character.Match("Xenia");
            Assert.False(result.Success());
        }

        [Fact]
        public void TestCharacterMatch_Alice()
        {
            var character = new Character('A');
            var result = character.Match("Alice");
            Assert.True(result.Success());
        }

        [Fact]
        public void TestCharacterMatch_LowercaseAlice()
        {
            var character = new Character('A');
            var result = character.Match("alice");
            Assert.False(result.Success());
        }

        [Fact]
        public void TestCharacterMatch_Empty()
        {
            var character = new Character('A');
            var result = character.Match("");
            Assert.False(result.Success());
        }

        [Fact]
        public void TestCharacterMatch_Null()
        {
            var character = new Character('A');
            var result = character.Match(null);
            Assert.False(result.Success());
        }
    }
}