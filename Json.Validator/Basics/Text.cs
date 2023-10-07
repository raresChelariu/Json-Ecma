namespace Json.Basics;

public class TextPattern : IPattern
{
    private readonly string _prefix;

    public TextPattern(string prefix)
    {
        _prefix = prefix;
    }

    public IMatch Match(string text)
    {
        if (string.IsNullOrEmpty(text) || !text.StartsWith(_prefix))
        {
            return new Match(false, text);
        }

        return new Match(true, text[_prefix.Length..]);
    }
}