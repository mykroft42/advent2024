using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

public static class Program
{
    /// <summary>
    ///  Regular expression built for C# on: Tue, Dec 3, 2024, 12:14:33 AM
    ///  Using Expresso Version: 3.1.7917, http://www.ultrapico.com
    ///  
    ///  A description of the regular expression:
    ///  
    ///  mul\(\d{1,3},\d{1,3}\)
    ///      mul
    ///      Literal (
    ///      Any digit, between 1 and 3 repetitions
    ///      ,
    ///      Any digit, between 1 and 3 repetitions
    ///      Literal )
    ///  
    ///
    /// </summary>
    public static Regex regex = new Regex(
        "mul\\((\\d{1,3}),(\\d{1,3})\\)",
        RegexOptions.CultureInvariant
        | RegexOptions.Compiled
        );

    public static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");
        
        List<string> ins = new List<string>();
        string xyz = "";
        foreach (var x in input)
        {
            xyz += x;
        }

        var procs = xyz.Split("don't()").ToList();
        ins.Add(procs[0]);
        procs.RemoveAt(0);
        foreach (var i in procs)
        {
            var p2 = i.Split("do()").ToList();
            p2.RemoveAt(0);
            ins.AddRange(p2);
        }

        uint sum = 0;
        foreach (var x in ins)
        {
            MatchCollection ms = regex.Matches(x);
            for (int i = 0; i < ms.Count; i++)
            {
                var m = ms[i];
                Console.Write(m.Groups[0].Value);
                Console.WriteLine($"   mul({m.Groups[1].Value},{m.Groups[2].Value})");
                sum += uint.Parse(m.Groups[1].Value) * uint.Parse(m.Groups[2].Value);
            }
        }
        Console.WriteLine(sum);

    }
}