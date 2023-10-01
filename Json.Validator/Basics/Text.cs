namespace Json.Basics;

public class TextPattern : IPattern
{
    readonly string prefix;

    public TextPattern(string prefix)
    {
        this.prefix = prefix;
    }

    public IMatch Match(string text)
    {
        if (string.IsNullOrEmpty(text) || !text.StartsWith(prefix))
        {
            return new Match(false, text);
        }

        return new Match(true, text[prefix.Length..]);
    }
}