using Json.Basics;

namespace Json;

public class Value : IPattern
{
    private readonly IPattern pattern;

    public Value()
    {
        var obj = GetObjectPattern();

        var array = GetArrayPattern();

        pattern = new Choice(obj, array);
    }

    private static Choice GetArrayPattern()
    {
        var value = GetValuePattern();
        
        return new Choice(
            new Character('['),
            new Many(value),
            new Character(']'));
    }

    private static Sequence GetObjectPattern()
    {
        var value = GetValuePattern();
        return new Sequence(
            new Character('{'),
            new Many(
                new Sequence(
                    new StringPattern(),
                    new Character(':'),
                    value)),
            new Character('}'));
    }

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

        return pattern.Match(text);
    }
}