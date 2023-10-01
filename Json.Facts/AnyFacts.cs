using Xunit;

namespace Json.Facts;

public class AnyFacts
{
    [Fact]
    public void MatchesCharacterAcceptedSet()
    {
        var any = new Any("eE");

        var match = any.Match("ea");
        Assert.True(match.Success());
        Assert.Equal("a", match.RemainingText());

        match = any.Match("Ea");
        Assert.True(match.Success());
        Assert.Equal("a", match.RemainingText());
    }

    [Fact]
    public void FailsWhenCharacterIsNotInAcceptedSet()
    {
        var any = new Any("eE");

        var match = any.Match("a");
        Assert.False(match.Success());
        Assert.Equal("a", match.RemainingText());
    }

    [Fact]
    public void DoesNotMatchEmptyString()
    {
        var any = new Any("eE");

        var match = any.Match("");
        Assert.False(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void DoesNotMatchNull()
    {
        var any = new Any("eE");

        var match = any.Match(null);
        Assert.False(match.Success());
        Assert.Null(match.RemainingText());
    }

    [Fact]
    public void WorksCorrectlyWithMultipleAcceptedCharacters()
    {
        var sign = new Any("-+");

        var match = sign.Match("+3");
        Assert.True(match.Success());
        Assert.Equal("3", match.RemainingText());

        match = sign.Match("-2");
        Assert.True(match.Success());
        Assert.Equal("2", match.RemainingText());

        match = sign.Match("2");
        Assert.False(match.Success());
        Assert.Equal("2", match.RemainingText());
    }
}