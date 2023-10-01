namespace Json.Basics;

public class List : IPattern
{
    private readonly IPattern _pattern;

    public List(IPattern element, IPattern separator)
    {
        _pattern = new OptionalPattern(
            new Sequence(
                element,
                new Many(
                    new Sequence(
                        separator,
                        element))));
    }

    public IMatch Match(string text)
    {
        return _pattern.Match(text);
    }
}