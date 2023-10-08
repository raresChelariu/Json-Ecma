namespace Json.Basics
{
    public class OptionalPattern : IPattern
    {
        private readonly IPattern _pattern;

        public OptionalPattern(IPattern pattern)
        {
            _pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = _pattern.Match(text);

            return new Match(true, match.RemainingText());
        }
    }
}