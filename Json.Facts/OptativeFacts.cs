using Xunit;

namespace Json.Facts;

public class OptativeFacts
{
    [Fact]
    public void SingleCharacter()
    {
        var a = new OptionalPattern(new Character('a'));
        var match = a.Match("abc");
        Assert.True(match.Success());
        Assert.Equal("bc", match.RemainingText());
    }

    [Fact]
    public void RepeatedCharacter()
    {
        var a = new OptionalPattern(new Character('a'));
        var match = a.Match("aabc");
        Assert.True(match.Success());
        Assert.Equal("abc", match.RemainingText());
    }

    [Fact]
    public void NoMatch()
    {
        var a = new OptionalPattern(new Character('a'));
        var match = a.Match("bc");
        Assert.True(match.Success());
        Assert.Equal("bc", match.RemainingText());
    }

    [Fact]
    public void EmptyString()
    {
        var a = new OptionalPattern(new Character('a'));
        var match = a.Match("");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void NullString()
    {
        var a = new OptionalPattern(new Character('a'));
        var match = a.Match(null);
        Assert.True(match.Success());
        Assert.Null(match.RemainingText());
    }

    [Fact]
    public void OptativeSign_Positive()
    {
        var sign = new OptionalPattern(new Character('-'));
        var match = sign.Match("123");
        Assert.True(match.Success());
        Assert.Equal("123", match.RemainingText());
    }

    [Fact]
    public void OptativeSign_Negative()
    {
        var sign = new OptionalPattern(new Character('-'));
        var match = sign.Match("-123");
        Assert.True(match.Success());
        Assert.Equal("123", match.RemainingText());
    }
}