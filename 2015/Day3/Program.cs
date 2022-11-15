using System.IO;
using System.Windows;
namespace Day2
{
    class Programm
    {
        [STAThread]
        static void Main(string[] args)
        {
            var content = File.ReadAllText("Input.txt");

            Dictionary<KeyValuePair<int, int>, int> presents = new Dictionary<KeyValuePair<int, int>, int>();

            int x = 0;
            int y = 0;

            presents.Add(new KeyValuePair<int, int>(x, y), 1);

            foreach (var item in content)
            {
                if (item == '^')
                {
                    y++;
                }

                if (item == 'v')
                {
                    y--;
                }

                if (item == '>')
                {
                    x++;
                }

                if (item == '<')
                {
                    x--;
                }

                var pos = new KeyValuePair<int, int>(x, y);

                if (presents.ContainsKey(pos))
                {
                    presents[pos]++;
                }
                else
                {
                    presents.Add(new KeyValuePair<int, int>(x, y), 1);
                }
            }

            Console.WriteLine(presents.Count);
            Clipboard.SetText(presents.Count.ToString());

            Console.ReadKey();
        }
    }
}