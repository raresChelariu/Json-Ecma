namespace Json;

public class OptionalPattern : IPattern
{
    readonly IPattern pattern;

    public OptionalPattern(IPattern pattern)
    {
        this.pattern = pattern;
    }

    public IMatch Match(string text)
    {
        var match = pattern.Match(text);

        return new Match(true, match.RemainingText());
    }
}