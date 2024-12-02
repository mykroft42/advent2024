using System;
using System.IO;
using System.Linq;

public static class Program
{
    public static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");

        int safe = 0;

        foreach (var i in input)
        {
            var items = i.Split(" ").Select(x => int.Parse(x)).ToList();

            bool isSafe = safeCheck(items);
            for (int x = 0; x < items.Count && !isSafe; x++)
            {
                var temp = items.ToList();
                temp.RemoveAt(x);
                isSafe = safeCheck(temp);
            }
            Console.WriteLine(isSafe);
            if (isSafe)
                safe++;
        }

        Console.WriteLine(safe);
    }

    public static bool safeCheck(List<int> items)
    {
        bool isIncreasing = items[0] < items[1];
        bool isSafe = true;
        bool dampener = false;
        int prev = 0;
        for (int x = 1; x < items.Count && isSafe; x++)
        {
            if (isIncreasing && items[prev] > items[x])
            {
                
                isSafe = false;
                continue;
            }
            else if (!isIncreasing && items[prev] < items[x])
            {
                isSafe = false;
                continue;
            }

            int diff = Math.Abs(items[prev] - items[x]);
            if (diff == 0 || diff > 3) 
            {
                isSafe = false;
                continue;
            }

            prev = x;
        }

        return isSafe;
    }
}