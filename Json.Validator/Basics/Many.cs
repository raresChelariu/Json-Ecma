namespace Json.Basics
{
    public class Many : IPattern
    {
        private readonly IPattern _pattern;

        public Many(IPattern pattern)
        {
            _pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = _pattern.Match(text);
            while (match.Success())
            {
                match = _pattern.Match(match.RemainingText());
            }

            return new Match(true, match.RemainingText());
        }
    }
}