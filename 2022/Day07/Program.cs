using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace Day07
{
    internal class Programm
    {
        [STAThread]
        // Part 1
        static void Main(string[] args)
        {
            var content = File.ReadAllLines("Input.txt");
            //var content = File.ReadAllLines("Sample.txt");

            DirectoryInfo myTree = null;
            DirectoryInfo currentPos = null;
            var count = 0;

            var regex = new Regex("\\d+");

            var listContent = false;

            foreach (var item in content)
            {
                if (item.StartsWith('$'))
                {
                    var command = item[1..].Trim().Split(' ');

                    if (command[0] == "cd")
                    {
                        listContent = false;

                        if (command[1] == "..")
                        {
                            currentPos = currentPos.Parent;
                        }
                        else if (command[1] == "/")
                        {
                            if (myTree == null)
                            {
                                myTree = new DirectoryInfo { Name = command[1] };
                                currentPos = myTree;
                            }
                            else
                            {
                                currentPos = myTree;
                            }
                        }
                        else
                        {
                            currentPos = currentPos.Content.OfType<DirectoryInfo>().Where(x => x.Name == command[1]).FirstOrDefault();
                        }
                    }
                    else if (command[0] == "ls")
                    {
                        listContent = true;
                        continue;
                    }
                }

                if (listContent)
                {
                    var parts = item.Split(' ');
                    if (parts[0] == "dir")
                    {
                        currentPos.Content.Add(new DirectoryInfo { Name = parts[1], Parent = currentPos });
                    }
                    else
                    {
                        currentPos.Content.Add(new FileInfo(parts[1], int.Parse(parts[0])));
                    }
                }
            }

            var bla = myTree.Content.OfType<DirectoryInfo>().SelectMany(x => x.FlattenItems()).Select(x => new { x.Name, x.Size }).ToList();

            count = bla.Where(x => x.Size <= 100000).Sum(x => x.Size);

            Console.WriteLine(count);
            Clipboard.SetText(count.ToString());

            Console.ReadKey();
        }
    }
}