var content = File.ReadAllText("Input.txt");

var sum = content.Count(x => x == '(') - content.Count(x => x == ')');

Console.WriteLine(sum);
Console.ReadKey();