using Json.Basics;
using Xunit;

namespace Json.Facts;

public class NumberFacts
{
    [Fact]
    public void CanBeZero()
    {
        var number = new Number();
        var match = number.Match("0");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void DoesNotContainLetters()
    {
        var number = new Number();
        var match = number.Match("a");
        Assert.False(match.Success());
        Assert.Equal("a", match.RemainingText());
    }

    [Fact]
    public void CanHaveASingleDigit()
    {
        var number = new Number();
        var match = number.Match("7");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void CanHaveMultipleDigits()
    {
        var number = new Number();
        var match = number.Match("70");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void IsNotNull()
    {
        var number = new Number();
        var match = number.Match(null);
        Assert.False(match.Success());
        Assert.Equal(null, match.RemainingText());
    }

    [Fact]
    public void IsNotAnEmptyString()
    {
        var number = new Number();
        var match = number.Match(string.Empty);
        Assert.False(match.Success());
        Assert.Equal(string.Empty, match.RemainingText());
    }

    [Fact]
    public void DoesNotStartWithZero()
    {
        var number = new Number();
        var match = number.Match("07");
        Assert.False(match.Success());
        Assert.Equal("07", match.RemainingText());
    }

    [Fact]
    public void CanBeNegative()
    {
        var number = new Number();
        var match = number.Match("-26");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void CanBeMinusZero()
    {
        var number = new Number();
        var match = number.Match("-0");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void CanBeFractional()
    {
        var number = new Number();
        var match = number.Match("12.34");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void TheFractionCanHaveLeadingZeros()
    {
        var number = new Number();
        var match1 = number.Match("0.00000001");
        Assert.True(match1.Success());
        Assert.Equal("", match1.RemainingText());

        var match2 = number.Match("10.00000001");
        Assert.True(match2.Success());
        Assert.Equal("", match2.RemainingText());
    }

    [Fact]
    public void DoesNotEndWithADot()
    {
        var number = new Number();
        var match = number.Match("12.");
        Assert.False(match.Success());
        Assert.Equal("12.", match.RemainingText());
    }

    [Fact]
    public void DoesNotHaveTwoFractionParts()
    {
        var number = new Number();
        var match = number.Match("12.34.56");
        Assert.False(match.Success());
        Assert.Equal("12.34.56", match.RemainingText());
    }

    [Fact]
    public void TheDecimalPartDoesNotAllowLetters()
    {
        var number = new Number();
        var match = number.Match("12.3x");
        Assert.False(match.Success());
        Assert.Equal("12.3x", match.RemainingText());
    }

    [Fact]
    public void CanHaveAnExponent()
    {
        var number = new Number();
        var match = number.Match("12e3");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void TheExponentCanStartWithCapitalE()
    {
        var number = new Number();
        var match = number.Match("12E3");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void TheExponentCanHavePositive()
    {
        var number = new Number();
        var match = number.Match("12e+3");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void TheExponentCanBeNegative()
    {
        var number = new Number();
        var match = number.Match("61e-9");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void CanHaveFractionAndExponent()
    {
        var number = new Number();
        var match = number.Match("12.34E3");
        Assert.True(match.Success());
        Assert.Equal("", match.RemainingText());
    }

    [Fact]
    public void TheExponentDoesNotAllowLetters()
    {
        var number = new Number();
        var match = number.Match("22e3x3");
        Assert.False(match.Success());
        Assert.Equal("22e3x3", match.RemainingText());
    }

    [Fact]
    public void DoesNotHaveTwoExponents()
    {
        var number = new Number();
        var match = number.Match("22e323e33");
        Assert.False(match.Success());
        Assert.Equal("22e323e33", match.RemainingText());
    }

    [Fact]
    public void TheExponentIsAlwaysComplete()
    {
        var number = new Number();
        var match1 = number.Match("22e");
        var match2 = number.Match("22e+");
        var match3 = number.Match("23E-");
        Assert.False(match1.Success());
        Assert.Equal("22e", match1.RemainingText());
        Assert.False(match2.Success());
        Assert.Equal("22e+", match2.RemainingText());
        Assert.False(match3.Success());
        Assert.Equal("23E-", match3.RemainingText());
    }

    [Fact]
    public void TheExponentIsAfterTheFraction()
    {
        var number = new Number();
        var match = number.Match("22e3.3");
        Assert.False(match.Success());
        Assert.Equal("22e3.3", match.RemainingText());
    }

}