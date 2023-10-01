using Xunit;

namespace Json.Facts;

public class SequenceFacts
{
    [Fact]
    public void Sequence_ab()
    {
        var ab = new Sequence(
            new Character('a'),
            new Character('b')
        );

        Assert.True(ab.Match("abcd").Success());
        Assert.Equal("cd", ab.Match("abcd").RemainingText());

        Assert.False(ab.Match("ax").Success());
        Assert.Equal("ax", ab.Match("ax").RemainingText());

        Assert.False(ab.Match("def").Success());
        Assert.Equal("def", ab.Match("def").RemainingText());

        Assert.False(ab.Match("").Success());
        Assert.Equal("", ab.Match("").RemainingText());

        Assert.False(ab.Match(null).Success());
        Assert.Null(ab.Match(null).RemainingText());
    }

    [Fact]
    public void Sequence_abc()
    {
        var ab = new Sequence(
            new Character('a'),
            new Character('b')
        );

        var abc = new Sequence(
            ab,
            new Character('c')
        );

        Assert.True(abc.Match("abcd").Success());
        Assert.Equal("d", abc.Match("abcd").RemainingText());

        Assert.False(abc.Match("def").Success());
        Assert.Equal("def", abc.Match("def").RemainingText());

        Assert.False(abc.Match("abx").Success());
        Assert.Equal("abx", abc.Match("abx").RemainingText());

        Assert.False(abc.Match("").Success());
        Assert.Equal("", abc.Match("").RemainingText());

        Assert.False(abc.Match(null).Success());
        Assert.Null(abc.Match(null).RemainingText());
    }

    [Fact]
    public void HexSequence()
    {
        var hex = new Choice(
            new Range('0', '9'),
            new Range('a', 'f'),
            new Range('A', 'F')
        );

        var hexSeq = new Sequence(
            new Character('u'),
            new Sequence(
                hex,
                hex,
                hex,
                hex
            )
        );

        Assert.True(hexSeq.Match("u1234").Success());
        Assert.Equal("", hexSeq.Match("u1234").RemainingText());

        Assert.True(hexSeq.Match("uabcdef").Success());
        Assert.Equal("ef", hexSeq.Match("uabcdef").RemainingText());

        Assert.True(hexSeq.Match("uB005 ab").Success());
        Assert.Equal(" ab", hexSeq.Match("uB005 ab").RemainingText());

        Assert.False(hexSeq.Match("abc").Success());
        Assert.Equal("abc", hexSeq.Match("abc").RemainingText());

        Assert.False(hexSeq.Match(null).Success());
        Assert.Null(hexSeq.Match(null).RemainingText());
    }
}