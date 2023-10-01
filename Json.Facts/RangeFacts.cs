using Json.Basics;
using Xunit;

namespace Json.Facts;

public class RangeFacts
{
    [Fact]
    public void TestRangeMatch_abc()
    {
        var range = new Range('a', 'f');
        var result = range.Match("abc");
        Assert.True(result.Success());
    }

    [Fact]
    public void TestRangeMatch_fab()
    {
        var range = new Range('a', 'f');
        var result = range.Match("fab");
        Assert.True(result.Success());
    }

    [Fact]
    public void TestRangeMatch_bcd()
    {
        var range = new Range('a', 'f');
        var result = range.Match("bcd");
        Assert.True(result.Success());
    }

    [Fact]
    public void TestRangeMatch_1ab()
    {
        var range = new Range('a', 'f');
        var result = range.Match("1ab");
        Assert.False(result.Success());
    }

    [Fact]
    public void TestRangeMatch_Empty()
    {
        var range = new Range('a', 'f');
        var result = range.Match("");
        Assert.False(result.Success());
    }

    [Fact]
    public void TestRangeMatch_Null()
    {
        var range = new Range('a', 'f');
        var result = range.Match(null);
        Assert.False(result.Success());
    }
}