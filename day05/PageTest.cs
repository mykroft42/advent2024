using System;
using System.Collections.Generic;
using System.Linq;

namespace Day05
{
    public class PageTest
    {
        private int First;
        private int Second;

        public PageTest(int first, int second)
        {
            First = first;
            Second = second;
        }

        public bool RunTest(List<int> input)
        {
            if (input.Contains(First) && input.Contains(Second))
            {
                return input.IndexOf(First) < input.IndexOf(Second);
            }

            return true;
        }

        public void Fix(List<int> input)
        {
            int firstI = input.IndexOf(First);
            int secondI = input.IndexOf(Second);

            input[firstI] = Second;
            input[secondI] = First;
        }
    }
}