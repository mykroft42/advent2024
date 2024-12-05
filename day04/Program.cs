using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public static class Program
{
    public static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt").ToList();

        int cnt = 0;
        for (int j = 0; j < input.Count(); j++)
        {
            for (int i = 0; i < input[0].Length; i++)
            {
                if (input[j][i] == 'X')
                {
                    var strs = GetStrings(i, j, input);
                    //strs.ForEach(x => Console.WriteLine(x));
                    //Console.WriteLine("=====");
                    cnt += strs.Where(x => x == "XMAS").ToList().Count;
                }
            }
        }

        Console.WriteLine(cnt);

        cnt = 0;
        for (int j = 0; j < input.Count(); j++)
        {
            for (int i = 0; i < input[0].Length; i++)
            {
                if (input[j][i] == 'A')
                {
                    if (GetDiag2(i, j, input))
                        cnt++;
                }
            }
        }

        Console.WriteLine(cnt);
    }

    static List<string> GetStrings(int x, int y, List<string> input)
    {
        List<string> result = new List<string>();

        if (x < input[y].Length - 3)
        {
            result.Add(input[y].Substring(x, 4));        
        }
        if (x >= 3)
            result.Add(new string(input[y].Substring(x - 3, 4).Reverse().ToArray()));
        if (x >= 3 && y >= 3)
        {
            result.Add(GetDiag(x, y, true, true, input));
        }
        if (x >= 3 && y < input.Count - 3)
        {
            result.Add(GetDiag(x, y, false, true, input));
        }
        if (x < (input[y].Length - 3) && y >= 3)
        {
            result.Add(GetDiag(x, y, true, false, input));
        }
        if (x < (input[y].Length - 3) && y < input.Count - 3)
        {
            result.Add(GetDiag(x, y, false, false, input));
        }
        if (y >= 3)
        {
            result.Add(input[y][x].ToString() + input[y-1][x].ToString() + input[y-2][x].ToString() + input[y-3][x].ToString());
        }
        if (y < input.Count - 3)
        {
            result.Add(input[y][x].ToString() + input[y+1][x].ToString() + input[y+2][x].ToString() + input[y+3][x].ToString());
        }
        
        return result;
    }

    static string GetDiag(int x, int y, bool up, bool left, List<string> input)
    {
        int upSign = 1;
        if (up)
        {
            upSign = -1;
        }

        int leftSign = 1;
        if (left)
        {
            leftSign = -1;
        }

        string res = "";
        for (int i = 0; i < 4; i++)
        {
            res += input[y + (upSign * i)][x + (leftSign * i)].ToString();
        }

        return res;
    }

    static bool GetDiag2(int x, int y, List<string> input)
    {
        List<string> result = new List<string>();

        if(y >= 1 && y < input.Count - 1 && x >= 1 && x < input[y].Length - 1)
        {
            result.Add(input[y - 1][x - 1].ToString() + input[y][x].ToString() + input[y + 1][x + 1].ToString());
            result.Add(input[y + 1][x - 1].ToString() + input[y][x].ToString() + input[y - 1][x + 1].ToString());
        }

        return result.Where(x => x == "SAM" || x == "MAS").Count() == 2;
    }
}