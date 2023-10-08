using Json.Basics;

namespace Json
{
    public class Members : IPattern
    {
        private readonly IPattern _pattern;

        public Members()
        {
            var member = new Member();
            _pattern = new List(member, new Character(','));
        }

        public IMatch Match(string text)
        {
            return _pattern.Match(text);
        }
    }
}