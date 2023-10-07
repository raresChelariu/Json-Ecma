using Json.Basics;

namespace Json;

public class Value : IPattern
{
    private static Choice GetValuePattern()
    {
        var stringPattern = GetStringPattern();
        var number = GetNumberPattern();
        var obj = new Object();
        var arr = new Arr();

        var value = new Choice(
            new TextPattern("true"),
            new TextPattern("false"),
            new TextPattern("null"),
            stringPattern,
            number,
            obj,
            arr
        );

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

        var pattern = GetValuePattern();
        return pattern.Match(text);
    }
}