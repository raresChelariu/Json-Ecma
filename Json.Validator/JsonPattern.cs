using Json.Basics;

namespace Json;

public class JsonPattern : IPattern
{
    private readonly IPattern _pattern = new Value();

    public IMatch Match(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return new Match(false, text);
        }

        var match = _pattern.Match(text);
        if (!string.IsNullOrEmpty(match.RemainingText()))
        {
            return new Match(false, text);
        }
        return match;
    }
}