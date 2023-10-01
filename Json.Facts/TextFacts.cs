using Json.Basics;
using Xunit;

namespace Json.Facts;

public class TextFacts
{
    [Fact]
    public void ExactText_True()
    {
        var text = new TextPattern("true");
        var match = text.Match("true");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void SameTextWithExtraCharacters_True()
    {
        var text = new TextPattern("true");
        var match = text.Match("trueX");
        Assert.True(match.Success());
        Assert.Equal("X", match.RemainingText());
    }

    [Fact]
    public void DifferentText_False()
    {
        var text = new TextPattern("true");
        var match = text.Match("false");
        Assert.False(match.Success());
        Assert.Equal("false", match.RemainingText());
    }

    [Fact]
    public void MatchEmptyText_False()
    {
        var text = new TextPattern("true");
        var match = text.Match("");
        Assert.False(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void MatchNullText_False()
    {
        var text = new TextPattern("true");
        var match = text.Match(null);
        Assert.False(match.Success());
        Assert.Null(match.RemainingText());
    }

    [Fact]
    public void EmptyPrefix_False()
    {
        var text = new TextPattern("");
        var match = text.Match("true");
        Assert.True(match.Success());
        Assert.Equal("true", match.RemainingText());
    }

    [Fact]
    public void EmptyPrefixAndNullText_False()
    {
        var text = new TextPattern("");
        var match = text.Match(null);
        Assert.False(match.Success());
        Assert.Null(match.RemainingText());
    }
}