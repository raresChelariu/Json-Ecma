using System;

namespace Json.Basics
{
    public class Choice : IPattern
    {
        private IPattern[] _patterns;

        public Choice(params IPattern[] initialPatterns)
        {
            _patterns = initialPatterns;
        }

        public void Add(params IPattern[] newPatterns)
        {
            if (newPatterns.Length == 0)
            {
                return;
            }

            var totalPatterns = _patterns.Length + newPatterns.Length;
            Array.Resize(ref _patterns, totalPatterns);

            for (var i = 0; i < newPatterns.Length; i++)
            {
                _patterns[_patterns.Length - newPatterns.Length + i] = newPatterns[i];
            }
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in _patterns)
            {
                var match = pattern.Match(text);

                if (match.Success())
                {
                    return match;
                }
            }

            return new Match(false, text);
        }
    }
}