using Json.Basics;

namespace Json;

public class Arr : IPattern
{
    private readonly IPattern _pattern = GetArrayPattern();

    private static Choice GetArrayPattern()
    {
        var ws = new Whitespace();
        
        var emptyArr = new Sequence
        (
            new Character('['),
            ws,
            new Character(']')
        );
        
        var nonEmptyArr = new Sequence
        (
            new Character('['),
            new Elements(),
            new Character(']')
        );
        
        return new Choice(emptyArr, nonEmptyArr);
    }

    public IMatch Match(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return new Match(false, text);
        }

        return _pattern.Match(text);
    }
}