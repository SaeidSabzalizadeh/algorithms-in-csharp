using System;
using System.Collections.Generic;

namespace Algorithms.Strings.Search
{
    public class KnuthMorrisPratt : ISearch
    {
        public IEnumerable<int> Search(string text, string pattern)
        {
            int textLength = text.Length;
            int patternLength = pattern.Length;

            if (textLength < patternLength)
                return null;

            if (textLength == patternLength && text == pattern)
                return new List<int>() { 0 };
            
            if (patternLength == 0)
                return new List<int>() { 0 };

            int[] lpsArray = new int[patternLength];
            List<int> matchedIndex = new List<int>();

            LongestPrefixSuffix(pattern, ref lpsArray);

            int textIndex = 0;
            int patternIndex = 0;

            while (textIndex < textLength)
            {
                if (text[textIndex] == pattern[patternIndex])
                {
                    textIndex++;
                    patternIndex++;
                }

                // match found at i-j
                if (patternIndex == patternLength)
                {
                    matchedIndex.Add(textIndex - patternIndex);
                    //Console.WriteLine((textIndex - patternIndex).ToString());
                    patternIndex = lpsArray[patternIndex - 1];
                }
                else if (textIndex < textLength && text[textIndex] != pattern[patternIndex])
                {
                    if (patternIndex != 0)
                    {
                        patternIndex = lpsArray[patternIndex - 1];
                    }
                    else
                    {
                        textIndex++;
                    }
                }
            }

            return matchedIndex;
        }

        private void LongestPrefixSuffix(string pattern, ref int[] lpsArray)
        {
            int patternLength = pattern.Length;
            int len = 0;
            lpsArray[0] = 0;
            int patternIndex = 1;

            while (patternIndex < patternLength)
            {
                if (pattern[patternIndex] == pattern[len])
                {
                    len++;
                    lpsArray[patternIndex] = len;
                    patternIndex++;
                }
                else
                {
                    if (len == 0)
                    {
                        lpsArray[patternIndex] = 0;
                        patternIndex++;
                    }
                    else
                    {
                        len = lpsArray[len - 1];
                    }
                }
            }
        }


    }
}
