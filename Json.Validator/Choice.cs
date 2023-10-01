using System;

namespace Json;

public class Choice : IPattern
{
    private IPattern[] patterns;

    public Choice(params IPattern[] initialPatterns)
    {
        patterns = initialPatterns;
    }

    public void Add(params IPattern[] newPatterns)
    {
        if (newPatterns.Length == 0)
        {
            return;
        }

        var totalPatterns = patterns.Length + newPatterns.Length;
        Array.Resize(ref patterns, totalPatterns);

        for (var i = 0; i < newPatterns.Length; i++)
        {
            patterns[patterns.Length - newPatterns.Length + i] = newPatterns[i];
        }
    }

    public IMatch Match(string text)
    {
        foreach (var pattern in patterns)
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