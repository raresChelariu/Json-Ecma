namespace Json.Basics
{
    public class Number : IPattern
    {
        private readonly IPattern _pattern;

        public Number()
        {
            var maybeMinus = new OptionalPattern(new Character('-'));
            var zero = new Character('0');
            var digits = new OneOrMore(new Range('0', '9'));
            var nonZeroDigit = new Range('1', '9');
            var dot = new Character('.');
            var eSign = new Any("eE");
            var sign = new Any("+-");
        
            var integer = new Choice(
                new Sequence(maybeMinus, zero),
                new Sequence(maybeMinus, new Sequence(nonZeroDigit, new Many(digits))));
        
            var fraction = new Sequence(dot, digits, new OptionalPattern(new Many(digits)));
        
            var exponent = new Sequence(eSign, new OptionalPattern(sign), digits);
        
            _pattern = new Sequence(integer, new OptionalPattern(fraction), new OptionalPattern(exponent));
        }

        public IMatch Match(string text)
        {
            var match = _pattern.Match(text);
        
            return match;
        }
    }
}