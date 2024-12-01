using System;
using System.IO;
using System.Linq;

public static class Program
{
    public static void Main(string[] ags)
    {
        var input = File.ReadAllLines("input.txt");

        var list1 = new List<int>();
        var list2 = new List<int>();
        foreach(var i in input)
        {
            var things = i.Split("   ");
            
            list1.Add(int.Parse(things[0]));
            list2.Add(int.Parse(things[1]));
        }
        list1.Sort();
        list2.Sort();
        int sum = 0;
        for (int i = 0; i < list1.Count; i++)
        {
            sum += Math.Abs(list1[i] - list2[i]);
        }

        Console.WriteLine(sum);

        int simil = 0;
        for (int i = 0; i < list1.Count; i++)
        {
            int item = list1[i];
            simil += item * list2.Where(x => x == item).Count();
        }

        Console.WriteLine(simil);
    }
}