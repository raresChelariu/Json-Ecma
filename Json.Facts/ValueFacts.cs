using Xunit;

namespace Json.Facts;

public class ValueFacts
{
    [Fact]
    public void Match_ValidJsonString_ReturnsSuccess()
    {
        var value = new Value();
        var json = "\"Hello, World!\"";

        var match = value.Match(json);

        Assert.True(match.Success());
    }

    [Fact]
    public void Match_ValidJsonNumber_ReturnsSuccess()
    {
        var value = new Value();
        var json = "42";

        var match = value.Match(json);

        Assert.True(match.Success());
    }

    [Fact]
    public void Match_ValidJsonBoolean_ReturnsSuccess()
    {
        var value = new Value();
        var json = "true";

        var match = value.Match(json);

        Assert.True(match.Success());
    }

    [Fact]
    public void Match_JsonWithLeadingSpaces_ReturnsSuccess()
    {
        var value = new Value();
        var json = "   42";

        var match = value.Match(json);

        Assert.True(match.Success());
    }

    [Fact]
    public void Match_EmptyJsonString_ReturnsFailure()
    {
        var value = new Value();
        var json = "";

        var match = value.Match(json);

        Assert.False(match.Success());
    }

    [Fact]
    public void Match_NullJson_ReturnsFailure()
    {
        var value = new Value();
        string json = null;

        var match = value.Match(json);

        Assert.False(match.Success());
    }

    [Fact]
    public void Match_JsonObject_ReturnsSuccess()
    {
        var value = new Value();
        var json = "{\"name\":\"John\",\"age\":30}";

        var match = value.Match(json);

        Assert.True(match.Success());
    }

    [Fact]
    public void Match_JsonArray_ReturnsSuccess()
    {
        var value = new Value();
        var json = "[1, 2, 3]";

        var match = value.Match(json);

        Assert.True(match.Success());
    }

}