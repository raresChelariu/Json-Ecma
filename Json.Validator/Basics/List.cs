﻿namespace Json.Basics;

public class List : IPattern
{
    private readonly IPattern pattern;

    public List(IPattern element, IPattern separator)
    {
        this.pattern = new OptionalPattern(
            new Sequence(
                element,
                new Many(
                    new Sequence(
                        separator,
                        element))));
    }

    public IMatch Match(string text)
    {
        return pattern.Match(text);
    }
}