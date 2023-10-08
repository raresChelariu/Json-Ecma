﻿namespace Json.Basics
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] _patterns;

        public Sequence(params IPattern[] patterns)
        {
            _patterns = patterns;
        }

        public IMatch Match(string text)
        {
            var remainingText = text;
            foreach (var pattern in _patterns)
            {
                var matchResult = pattern.Match(remainingText);
                if (!matchResult.Success())
                {
                    return new Match(false, text);
                }

                remainingText = matchResult.RemainingText();
            }

            return new Match(true, remainingText);
        }
    }
}