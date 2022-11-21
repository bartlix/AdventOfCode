using System.Text.RegularExpressions;

var input = File.ReadAllText("Input.txt");

var regex = new Regex("-?[0-9]{1,}");

var matches = regex.Matches(input);

var sum = 0;

foreach (Match match in matches)
{
    sum += int.Parse(match.Value);
}

Console.WriteLine(sum.ToString());
Console.ReadKey();