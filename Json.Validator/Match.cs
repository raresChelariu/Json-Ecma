namespace Json;

public class Match : IMatch
{
    readonly bool success;
    readonly string remainingText;

    public Match(bool success, string remainingText)
    {
        this.success = success;
        this.remainingText = remainingText;
    }

    public bool Success()
    {
        return success;
    }

    public string RemainingText()
    {
        return remainingText;
    }
}