using Json.Basics;

namespace Json
{
    public class Value : IPattern
    {
        private static IPattern GetValuePattern()
        {
            var stringPattern = GetStringPattern();
            var number = GetNumberPattern();
            var obj = new ObjectPattern();
            var arr = new ArrayPattern();

            var value = new Choice(
                new TextPattern("true"),
                new TextPattern("false"),
                new TextPattern("null"),
                number,
                stringPattern,
                obj,
                arr
            );
            var ws = new Whitespace();
            return new Sequence(ws,value, ws);
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
}