namespace Json;

public class Sequence : IPattern
{
    readonly IPattern[] patterns;

    public Sequence(params IPattern[] patterns)
    {
        this.patterns = patterns;
    }

    public IMatch Match(string text)
    {
        var remainingText = text;
        foreach (var pattern in patterns)
        {
            var matchResult = pattern.Match(remainingText);
            if (!matchResult.Success())
            {
                return new Match(false, text);
            }

            remainingText = matchResult.RemainingText();
        }

        return new Match(true, remainingText);
    }
}