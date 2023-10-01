namespace Json.Basics;

public class Number : IPattern
{
    private readonly IPattern pattern;

    public Number()
    {
        var digits = new OneOrMore(new Range('0', '9'));
        var integer = new Choice(
            new Sequence(new OptionalPattern(new Character('-')), new Character('0')),
            new Sequence(new OptionalPattern(new Character('-')), new Sequence(new Range('1', '9'), new Many(digits))));
        var fraction = new Sequence(new Character('.'), digits, new OptionalPattern(new Many(digits)));
        var exponent = new Sequence(new Any("eE"), new OptionalPattern(new Any("+-")), digits);
        this.pattern = new Sequence(integer, new OptionalPattern(fraction), new OptionalPattern(exponent));
    }

    public IMatch Match(string text)
    {
        var match = pattern.Match(text);
        return match.Success() && string.IsNullOrEmpty(match.RemainingText())
            ? match
            : new Match(false, text);
    }
}