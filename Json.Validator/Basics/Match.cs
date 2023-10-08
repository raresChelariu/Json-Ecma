namespace Json.Basics
{
    public class Match : IMatch
    {
        private readonly bool _success;
        private readonly string _remainingText;

        public Match(bool success, string remainingText)
        {
            _success = success;
            _remainingText = remainingText;
        }

        public bool Success()
        {
            return _success;
        }

        public string RemainingText()
        {
            return _remainingText;
        }
    }
}