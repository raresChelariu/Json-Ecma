namespace Json.Basics
{
    public interface IPattern
    {
        IMatch Match(string text);
    }
}