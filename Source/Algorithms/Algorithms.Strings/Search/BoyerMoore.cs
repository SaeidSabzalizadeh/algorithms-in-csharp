using System;
using System.Collections.Generic;

namespace Algorithms.Strings.Search
{
    public class BoyerMoore : ISearch
    {

        public IEnumerable<int> Search(string text, string pattern)
        {
            List<int> retVal = new List<int>();
            int patternLength = pattern.Length;
            int textLength = text.Length;

            int[] badChar = new int[256];

            BadCharHeuristic(pattern, patternLength, ref badChar);

            int searchIndex = 0;
            while (searchIndex <= (textLength - patternLength))
            {
                int patternIndex = patternLength - 1;

                while (patternIndex >= 0 && pattern[patternIndex] == text[searchIndex + patternIndex])
                    --patternIndex;

                if (patternIndex < 0)
                {
                    retVal.Add(searchIndex);
                    searchIndex += (searchIndex + patternLength < textLength) ? patternLength - badChar[text[searchIndex + patternLength]] : 1;
                }
                else
                {
                    searchIndex += Math.Max(1, patternIndex - badChar[text[searchIndex + patternIndex]]);
                }
            }

            return retVal.ToArray();
        }

        private static void BadCharHeuristic(string str, int size, ref int[] badChar)
        {
            int i;

            for (i = 0; i < 256; i++)
                badChar[i] = -1;

            for (i = 0; i < size; i++)
                badChar[(int)str[i]] = i;
        }

    }
}
