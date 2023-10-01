namespace Json;

public class Many : IPattern
{
    readonly IPattern pattern;

    public Many(IPattern pattern)
    {
        this.pattern = pattern;
    }

    public IMatch Match(string text)
    {
        var match = pattern.Match(text);
        while (match.Success())
        {
            match = pattern.Match(match.RemainingText());
        }

        return new Match(true, match.RemainingText());
    }
}