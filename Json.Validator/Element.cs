using Json.Basics;

namespace Json;

public class Element : IPattern
{
    private readonly IPattern _pattern = 
        new Sequence(new Whitespace(), new Value(), new Whitespace());

    public IMatch Match(string text)
    {
        return _pattern.Match(text);
    }
}