using Json.Basics;

namespace Json;

public class Value : IPattern
{
    private readonly IPattern _pattern = GetValuePattern();

    private static Choice GetValuePattern()
    {
        var stringPattern = GetStringPattern();
        var number = GetNumberPattern();
        
        var value = new Choice(
            stringPattern,
            number,
            new TextPattern("true"),
            new TextPattern("false"),
            new TextPattern("null"));

        return value;
    }

    private static IPattern GetNumberPattern()
    {
        return new Number();
    }

    private static IPattern GetStringPattern()
    {
        return new StringPattern();
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