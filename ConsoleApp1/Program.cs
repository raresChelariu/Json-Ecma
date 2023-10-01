using Json;


var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
var text = File.ReadAllText(path);

var value = new Value();
var match = value.Match(text);
if (match.Success())
{
    Console.WriteLine("Great");
}
else
{
    Console.WriteLine(":(");
}