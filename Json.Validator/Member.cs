using Json.Basics;

namespace Json;

public class Member : IPattern
{
    private readonly IPattern _pattern = GetMemberPattern();

    private static IPattern GetMemberPattern()
    {
        var ws = new Whitespace();
        var str = new StringPattern();
        var colon = new Character(':');
        var element = new Element();
        
        return new Sequence(ws, str, ws, colon, element);
    }

    public IMatch Match(string text)
    {
        var match = _pattern.Match(text);
        if (match.Success() && string.IsNullOrEmpty(match.RemainingText()))
        {
            return new Match(true, "");
        }

        return new Match(false, text);
    }
}