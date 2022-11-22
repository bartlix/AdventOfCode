using System.Collections;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace Day12
{
    class Programm
    {
        [STAThread]
        //Part 1
        //static void Main(string[] args)
        //{
        //    var input = File.ReadAllText("Input.txt");

        //    var regex = new Regex("-?[0-9]{1,}");

        //    var matches = regex.Matches(input);

        //    var sum = 0;

        //    foreach (Match match in matches)
        //    {
        //        sum += int.Parse(match.Value);
        //    }

        //    Console.WriteLine(sum.ToString());
        //    Clipboard.SetText(input);
        //    Console.ReadKey();
        //}

        //Part 2
        static void Main(string[] args)
        {
            var input = File.ReadAllText("Input.txt");

            var jsonObject = JsonSerializer.Deserialize<JsonNode>(input);

            var result = AnalyzeJsonObject(jsonObject);

            Console.WriteLine(result);
            Clipboard.SetText(result.ToString());
            Console.ReadKey();
        }

        private static int AnalyzeJsonObject(JsonNode jsonObject)
        {
            int result = 0;

            if (jsonObject is IEnumerable<KeyValuePair<string, JsonNode>> e)
            {
                var test = e.Select(x => x.Value.ToString()).ToArray();

                if (test.Contains("red"))
                {
                    return 0;
                }

                foreach (var item in e)
                {
                    if (int.TryParse(item.Value.ToString(), out var intValue))
                    {
                        result += intValue;
                        continue;
                    }

                    if (item.Value is JsonNode)
                    {
                        result += AnalyzeJsonObject(item.Value);
                    }
                }
            }

            if (jsonObject is JsonArray a)
            {
                foreach (var item in a)
                {
                    if (int.TryParse(item.ToString(), out var intValue))
                    {
                        result += intValue;
                        continue;
                    }

                    if (item is JsonNode)
                    {
                        result += AnalyzeJsonObject(item);
                    }
                }
            }

            return result;
        }
    }
}