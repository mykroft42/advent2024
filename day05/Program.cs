using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Day05
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            List<PageTest> tests = new List<PageTest>();
            bool flip = false;
            List<List<int>> reports = new List<List<int>>();
            foreach (var line in input)
            {
                if (!string.IsNullOrWhiteSpace(line) && !flip)
                {
                    var l = line.Split('|');
                    tests.Add(new PageTest(int.Parse(l[0]), int.Parse(l[1])));
                    continue;
                }

                if (string.IsNullOrWhiteSpace(line))
                {
                    flip = true;
                    continue;
                }

                if (flip)
                {
                    reports.Add(line.Split(',').Select(x => int.Parse(x)).ToList());
                }
            }

            int res = 0;
            int res2 = 0;
            foreach (var report in reports)
            {
                if (tests.All(t => t.RunTest(report)))
                {
                    res += report[report.Count / 2];
                }
                else
                {
                    while(!tests.All(t => t.RunTest(report)))
                    {
                        tests.ForEach(t => { if (!t.RunTest(report)) t.Fix(report); });
                    }
                    res2 += report[report.Count / 2];
                }
            }

            Console.WriteLine(res);
            Console.WriteLine(res2);
        }
    }
}