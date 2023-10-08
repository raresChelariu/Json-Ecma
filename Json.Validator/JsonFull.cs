using Json.Basics;

namespace Json;

public class JsonFull : IPattern
{
    private readonly IPattern _pattern;

    public JsonFull()
    {
        var obj = new Object();

        var array = new Arr();

        _pattern = new Choice(obj, array);
    }
    
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