using Json.Basics;

namespace Json;

public class Whitespace : IPattern
{
    private readonly IPattern _pattern = new Many(new Any(" \t\n\r"));

    public IMatch Match(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return new Match(true, "");
        }
        
        var match = _pattern.Match(text);
        if (match.Success())
        {
            if (string.IsNullOrEmpty(match.RemainingText()))
            {
                return new Match(true, "");    
            }
            return new Match(true, match.RemainingText());
        }
        return new Match(false, text);
    }
}