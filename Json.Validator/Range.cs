﻿namespace Json;

public class Range : IPattern
{
    readonly char start;
    readonly char end;

    public Range(char start, char end)
    {
        this.start = start;
        this.end = end;
    }

    public IMatch Match(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return new Match(false, text);
        }

        if (text[0] >= start && text[0] <= end)
        {
            return new Match(true, text[1..]);
        }

        return new Match(false, text);
    }
}