using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows;
using Day18;

namespace Day18
{
    class Programm
    {
        private static List<(string key, string value)> _transParts = new List<(string key, string value)>();
        private static string _findingResult = "";

        [STAThread]
        //Part 1
        //static void Main(string[] args)
        //{
        //    var input = File.ReadAllLines("Input.txt");
        //    //var input = File.ReadAllLines("Sample.txt");

        //    var transParts = new List<(string key, string value)>();

        //    var action = false;

        //    string baseTxt = "";

        //    foreach (var line in input)
        //    {
        //        if (line == "")
        //        {
        //            action = true;
        //            continue;
        //        }

        //        if (action)
        //        {
        //            baseTxt = line;
        //            break;
        //        }

        //        var part = line.Split("=>");

        //        transParts.Add((part[0].Trim(), part[1].Trim()));
        //    }

        //    var result = new List<string>();

        //    StringBuilder sb = new StringBuilder();

        //    foreach (var part in transParts)
        //    {
        //        var regex = new Regex(Regex.Escape(part.key));
        //        var matches = regex.Matches(baseTxt);                

        //        foreach (Match m in matches)
        //        {
        //            sb.Append(baseTxt.Substring(0, m.Index));
        //            sb.Append(part.value);
        //            sb.Append(baseTxt.Substring(m.Index + m.Length));

        //            result.Add(sb.ToString());
        //            sb.Clear();
        //        }
        //    }

        //    var count = result.Distinct().Count();

        //    Console.WriteLine(count);
        //    Clipboard.SetText(count.ToString());
        //    Console.ReadKey();
        //}

        // Part 2
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("Input.txt");
            var input = File.ReadAllLines("Sample.txt");

            var action = false;

            string baseTxt = "e";

            foreach (var line in input)
            {
                if (line == "")
                {
                    action = true;
                    continue;
                }

                if (action)
                {
                    _findingResult = line;
                    break;
                }

                var part = line.Split("=>");

                _transParts.Add((part[0].Trim(), part[1].Trim()));
            }

            TryNext(baseTxt);

            //foreach (var beginn in startParts)
            //{
            //    baseTxt = baseTxt.Replace(beginn.key,beginn.value);
            //    try
            //    {
            //        for (var i = 0; i < transParts.Count; i++)
            //        {
            //            var part = transParts[i];

            //            var regex = new Regex(Regex.Escape(part.key));
            //            var matches = regex.Matches(baseTxt);

            //            foreach (Match m in matches)
            //            {
            //                sb.Append(baseTxt.Substring(0, m.Index));
            //                sb.Append(part.value);
            //                sb.Append(baseTxt.Substring(m.Index + m.Length));

            //                count++;

            //                if (sb.ToString() == findingResult)
            //                {
            //                    break;
            //                }
            //                else
            //                {
            //                    baseTxt = sb.ToString();
            //                    sb.Clear();

            //                    if (baseTxt.Length > findingResult.Length)
            //                    {
            //                        throw new NotFiniteNumberException();
            //                    }                                
            //                }

            //                sb.Clear();
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        count = 1;
            //        baseTxt = "e";
            //        continue;
            //    }
            //}

            Console.WriteLine(_count);
            Clipboard.SetText(_count.ToString());
            Console.ReadKey();
        }

        private static int _count = 0;

        private static void TryNext(string baseTxt)
        {
            var tryTxt = new List<string>();

            foreach (var p in _transParts)
            {
                var regex = new Regex(Regex.Escape(p.key));
                var matches = regex.Matches(baseTxt);
                var sb = new StringBuilder();

                foreach (Match m in matches)
                {
                    sb.Append(baseTxt.Substring(0, m.Index));
                    sb.Append(p.value);
                    sb.Append(baseTxt.Substring(m.Index + m.Length));

                    tryTxt.Add(sb.ToString());
                    sb.Clear();
                }
            }

            if (tryTxt.Contains(_findingResult))
            {
                return;
            }
            else
            {
                if(tryTxt.All(x => x.Length > _findingResult.Length))
                {
                    return;
                }

                foreach(var t in tryTxt)
                {
                    TryNext(t);
                }
            }

            return;

            //for (var i = 0; i < _transParts.Count; i++)
            //{
            //    var part = _transParts[i];

            //    var regex = new Regex(Regex.Escape(part.key));
            //    var matches = regex.Matches(baseTxt);

            //    foreach (Match m in matches)
            //    {
            //        sb.Append(baseTxt.Substring(0, m.Index));
            //        sb.Append(part.value);
            //        sb.Append(baseTxt.Substring(m.Index + m.Length));

            //        if (sb.ToString() == _findingResult)
            //        {
            //            return sb.ToString();
            //        }
            //        else
            //        {
            //            return TryNext(sb.ToString());
            //        }
            //    }
            //}

            //return "";
        }
    }
}