namespace Json.Basics;

public class Range : IPattern
{
    private readonly char _start;
    private readonly char _end;

    public Range(char start, char end)
    {
        _start = start;
        _end = end;
    }

    public IMatch Match(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return new Match(false, text);
        }

        if (text[0] >= _start && text[0] <= _end)
        {
            return new Match(true, text[1..]);
        }

        return new Match(false, text);
    }
}