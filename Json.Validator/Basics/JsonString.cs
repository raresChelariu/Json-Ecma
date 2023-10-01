namespace Json.Basics;

public static class JsonString
{
    public static bool IsJsonString(string input)
    {
        return CheckIfTextIsNullOrEmptyAndIfItStartsOrEndsWithQuotes(input)
               && CheckForControlCharacters(input)
               && IsValidEscape(input);
    }

    public static bool CheckIfTextIsNullOrEmptyAndIfItStartsOrEndsWithQuotes(string input)
    {
        return !string.IsNullOrEmpty(input) && input[0] == '"' && input[^1] == '"';
    }

    public static bool CheckForControlCharacters(string input)
    {
        foreach (var ch in input)
        {
            if (ch < '\x20')
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsValidEscape(string input)
    {
        for (var i = 0; i <= input.Length - 1; i++)
        {
            if (!IsValidHexSequence(input, ref i))
            {
                return false;
            }

            if (input[i] == '\\' && !IsValidEscapeCharacter(input, ref i))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsValidEscapeCharacter(string input, ref int i)
    {
        if (i + 1 >= input.Length - 1)
        {
            return false;
        }

        const string characters = "bfnrtu\\/\"";

        return characters.Contains(input[++i]);
    }

    private static bool IsValidHexSequence(string input, ref int startingIndexToSearch)
    {
        if (input[startingIndexToSearch] != '\\' || input[startingIndexToSearch + 1] != 'u')
        {
            return true;
        }

        const int HexNumberDigits = 4;
        if (startingIndexToSearch + HexNumberDigits + 1 >= input.Length)
        {
            return false;
        }

        for (var j = startingIndexToSearch + 2; j <= startingIndexToSearch + HexNumberDigits + 1; ++j)
        {
            if (!IsHexChar(input[j]))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsHexChar(char characterToCheck)
    {
        return IsInRange('0', '9', characterToCheck)
               || IsInRange('a', 'f', characterToCheck)
               || IsInRange('A', 'F', characterToCheck);
    }

    private static bool IsInRange(char beginning, char ending, char characterToCheck)
    {
        return beginning <= characterToCheck && characterToCheck <= ending;
    }
}