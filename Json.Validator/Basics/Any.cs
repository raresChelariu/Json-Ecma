﻿namespace Json.Basics;

public class Any : IPattern
{
    readonly string accepted;

    public Any(string accepted)
    {
        this.accepted = accepted;
    }

    public IMatch Match(string text)
    {
        if (string.IsNullOrEmpty(text) || !accepted.Contains(text[0]))
        {
            return new Match(false, text);
        }

        return new Match(true, text[1..]);
    }
}