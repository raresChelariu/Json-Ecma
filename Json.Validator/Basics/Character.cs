namespace Json.Basics
{
    public class Character : IPattern
    {
        private readonly char _pattern;

        public Character(char pattern)
        {
            _pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text) || text[0] != _pattern)
            {
                return new Match(false, text);
            }

            return new Match(true, text[1..]);
        }
    }
}