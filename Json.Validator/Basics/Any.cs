namespace Json.Basics;

public class Any : IPattern
{
    private readonly string _accepted;

    public Any(string accepted)
    {
        _accepted = accepted;
    }

    public IMatch Match(string text)
    {
        if (string.IsNullOrEmpty(text) || !_accepted.Contains(text[0]))
        {
            return new Match(false, text);
        }

        return new Match(true, text[1..]);
    }
}