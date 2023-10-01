using Json.Basics;

namespace Json;

public class Elements : IPattern
{
    private readonly IPattern _pattern;

    public Elements()
    {
        var member = new Element();
        _pattern = new List(member, new Character(','));
    }

    public IMatch Match(string text)
    {
        return _pattern.Match(text);
    }
}