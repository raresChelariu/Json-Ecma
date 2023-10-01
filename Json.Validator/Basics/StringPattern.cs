namespace Json.Basics;

public class StringPattern : IPattern
{
    private readonly IPattern _pattern;

    public StringPattern()
    {
        var hexDigit = new Choice(
            new Range('0', '9'),
            new Range('A', 'F'),
            new Range('a', 'f'));

        var hex = new Sequence(
            new Character('u'),
            hexDigit,
            hexDigit,
            hexDigit,
            hexDigit);

        var backslash = new Character('\\');

        var nonSpecialChar = GetNonSpecialChar();

        var escapeSequence = new Choice(
            new Character('"'),
            new Character('\\'),
            new Character('/'),
            new Character('b'),
            new Character('f'),
            new Character('n'),
            new Character('r'),
            new Character('t'),
            hex);

        var character = new Choice(
            nonSpecialChar,
            new Sequence(backslash, escapeSequence));

        var stringContent = new Many(
            new Choice(
                character,
                hex));

        _pattern = new Sequence(
            new Character('"'),
            stringContent,
            new Character('"'));
    }

    private static Choice GetNonSpecialChar()
    {
        // toate caracterele mai putin:
        // 1. 0 - 1F (caractere albe - spatiu, tab, ENTER, etc)
        // 2. 22 <=> "
        // 3. 5C <=> \
        
        return new Choice(
            new Range('\u0020', '\u0021'),
            new Range('\u0023', '\u005B'),
            new Range('\u005D', '\uFFFF'),
            new Sequence(
                new Range('\uD800', '\uDBFF'),
                new Range('\uDC00', '\uDFFF')));
    }

    public IMatch Match(string text)
    {
        return _pattern.Match(text);
    }
}