using Json.Basics;

namespace Json;

public class Object : IPattern
{
    private readonly IPattern _pattern = GetObjectPattern();

    private static IPattern GetObjectPattern()
    {
        var ws = new Whitespace();
        var left = new Character('{');
        var right = new Character('}');
        var members = new Members();
        
        var emptyObj = new Sequence(left, ws, right);
        var nonEmptyObj = new Sequence(left, members, right);
        
        return new Choice(emptyObj, nonEmptyObj);
    }

    public IMatch Match(string text)
    {
        return _pattern.Match(text);
    }
}