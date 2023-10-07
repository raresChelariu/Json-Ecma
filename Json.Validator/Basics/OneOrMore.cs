namespace Json.Basics;

public class OneOrMore : IPattern
{
    private readonly IPattern _pattern;

    public OneOrMore(IPattern pattern)
    {
        _pattern = new Sequence(pattern, new Many(pattern));
    }

    public IMatch Match(string text)
    {
        return _pattern.Match(text);
    }
}