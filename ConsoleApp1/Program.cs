var path = Path.Combine(Directory.GetCurrentDirectory(), "input.json");
var text = File.ReadAllText(path);

var pattern = new Json.Object();
var match = pattern.Match(text);
if (match.Success())
{
    Console.WriteLine("Great");
}
else
{
    Console.WriteLine(":(");
}
Console.WriteLine("@" + match.RemainingText() + "@");