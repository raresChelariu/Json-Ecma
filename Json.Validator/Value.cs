namespace Json;

public class Value : IPattern
{
    private readonly IPattern pattern;

    public Value()
    {
        var stringPattern = new StringPattern();
        var number = new Number();

        var value = new Choice(
            stringPattern,
            number,
            new TextPattern("true"),
            new TextPattern("false"),
            new TextPattern("null"));

        var obj = GetObjectPattern(value);

        var array = GetArrayPattern(value);

        pattern = new Choice(obj, array);
    }

    private static Choice GetArrayPattern(Choice value)
    {
        return new Choice(
            new Character('['),
            new Many(value),
            new Character(']'));
    }

    private static Sequence GetObjectPattern(Choice value)
    {
        return new Sequence(
            new Character('{'),
            new Many(
                new Sequence(
                    new StringPattern(),
                    new Character(':'),
                    value)),
            new Character('}'));
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