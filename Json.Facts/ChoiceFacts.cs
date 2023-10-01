using Xunit;

namespace Json.Facts;

public class ChoiceFacts
{
    [Fact]
    public void DigitMatch_012()
    {
        var digit = new Choice(new Character('0'), new Range('1', '9'));
        Assert.True(digit.Match("012").Success());
    }

    [Fact]
    public void DigitMatch_12()
    {
        var digit = new Choice(new Character('0'), new Range('1', '9'));
        Assert.True(digit.Match("12").Success());
    }

    [Fact]
    public void DigitMatch_92()
    {
        var digit = new Choice(new Character('0'), new Range('1', '9'));
        Assert.True(digit.Match("92").Success());
    }

    [Fact]
    public void DigitMatch_a9()
    {
        var digit = new Choice(new Character('0'), new Range('1', '9'));
        Assert.False(digit.Match("a9").Success());
    }

    [Fact]
    public void DigitMatch_Empty()
    {
        var digit = new Choice(new Character('0'), new Range('1', '9'));
        Assert.False(digit.Match("").Success());
    }

    [Fact]
    public void DigitMatch_Null()
    {
        var digit = new Choice(new Character('0'), new Range('1', '9'));
        Assert.False(digit.Match(null).Success());
    }

    [Fact]
    public void HexMatch_012()
    {
        var hex = CreateHexChoice();
        Assert.True(hex.Match("012").Success());
    }

    [Fact]
    public void HexMatch_12()
    {
        var hex = CreateHexChoice();
        Assert.True(hex.Match("12").Success());
    }

    [Fact]
    public void HexMatch_92()
    {
        var hex = CreateHexChoice();
        Assert.True(hex.Match("92").Success());
    }

    [Fact]
    public void HexMatch_a9()
    {
        var hex = CreateHexChoice();
        Assert.True(hex.Match("a9").Success());
    }

    [Fact]
    public void HexMatch_f8()
    {
        var hex = CreateHexChoice();
        Assert.True(hex.Match("f8").Success());
    }

    [Fact]
    public void HexMatch_A9()
    {
        var hex = CreateHexChoice();
        Assert.True(hex.Match("A9").Success());
    }

    [Fact]
    public void HexMatch_F8()
    {
        var hex = CreateHexChoice();
        Assert.True(hex.Match("F8").Success());
    }

    [Fact]
    public void HexMatch_g8()
    {
        var hex = CreateHexChoice();
        Assert.False(hex.Match("g8").Success());
    }

    [Fact]
    public void HexMatch_G8()
    {
        var hex = CreateHexChoice();
        Assert.False(hex.Match("G8").Success());
    }

    [Fact]
    public void HexMatch_Empty()
    {
        var hex = CreateHexChoice();
        Assert.False(hex.Match("").Success());
    }

    [Fact]
    public void HexMatch_Null()
    {
        var hex = CreateHexChoice();
        Assert.False(hex.Match(null).Success());
    }

    private static Choice CreateHexChoice()
    {
        var digit = new Choice(new Character('0'), new Range('1', '9'));
        return new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
    }

    [Fact]
    public void Add_SinglePattern_ReturnsSuccess()
    {
        var value = new Choice(new StringPattern());
        var newPattern = new Number();

        value.Add(newPattern);

        Assert.True(value.Match("42").Success());
    }

    [Fact]
    public void Add_MultiplePatterns_ReturnsSuccess()
    {
        var value = new Choice(new StringPattern());
        var newPattern1 = new Number();
        var newPattern2 = new TextPattern("true");

        value.Add(newPattern1, newPattern2);

        Assert.True(value.Match("true").Success());
    }
}