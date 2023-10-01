using Xunit;

namespace Json.Facts;

public class ListFacts
{
    [Fact]
    public void List_CommaSeparator()
    {
        var a = new List(new Range('0', '9'), new Character(','));
        var match = a.Match("1,2,3");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void List_ExtraSeparator()
    {
        var a = new List(new Range('0', '9'), new Character(','));
        var match = a.Match("1,2,3,");
        Assert.True(match.Success());
        Assert.Equal(",", match.RemainingText());
    }

    [Fact]
    public void List_ExtraCharacter()
    {
        var a = new List(new Range('0', '9'), new Character(','));
        var match = a.Match("1a");
        Assert.True(match.Success());
        Assert.Equal("a", match.RemainingText());
    }

    [Fact]
    public void List_NoMatch()
    {
        var a = new List(new Range('0', '9'), new Character(','));
        var match = a.Match("abc");
        Assert.True(match.Success());
        Assert.Equal("abc", match.RemainingText());
    }

    [Fact]
    public void List_EmptyString()
    {
        var a = new List(new Range('0', '9'), new Character(','));
        var match = a.Match("");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void List_NullString()
    {
        var a = new List(new Range('0', '9'), new Character(','));
        var match = a.Match(null);
        Assert.True(match.Success());
        Assert.Null(match.RemainingText());
    }

    [Fact]
    public void List_WhitespaceAndSemicolonSeparator()
    {
        var digits = new OneOrMore(new Range('0', '9'));
        var whitespace = new Many(new Any(" \r\n\t"));
        var separator = new Sequence(whitespace, new Character(';'), whitespace);
        var list = new List(digits, separator);

        var match = list.Match("1; 22  ;\n 333 \t; 22");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void List_WithExtraWhitespace()
    {
        var digits = new OneOrMore(new Range('0', '9'));
        var whitespace = new Many(new Any(" \r\n\t"));
        var separator = new Sequence(whitespace, new Character(';'), whitespace);
        var list = new List(digits, separator);

        var match = list.Match("1 \n;");
        Assert.True(match.Success());
        Assert.Equal(" \n;", match.RemainingText());
    }

    [Fact]
    public void List_NoMatchDigits()
    {
        var digits = new OneOrMore(new Range('0', '9'));
        var whitespace = new Many(new Any(" \r\n\t"));
        var separator = new Sequence(whitespace, new Character(';'), whitespace);
        var list = new List(digits, separator);

        var match = list.Match("abc");
        Assert.True(match.Success());
        Assert.Equal("abc", match.RemainingText());
    }

    [Fact]
    public void List_InvalidStartingWithSeparator()
    {
        var a = new List(new Range('0', '9'), new Character(','));
        var match = a.Match(",1,2,3");
        Assert.True(match.Success());
        Assert.Equal(",1,2,3", match.RemainingText());
    }
}