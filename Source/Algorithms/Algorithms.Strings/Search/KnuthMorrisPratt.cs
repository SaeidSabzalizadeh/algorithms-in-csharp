using System;
using System.Collections.Generic;

namespace Algorithms.Strings.Search
{
    public class KnuthMorrisPratt
    {

        public IEnumerable<int> Search(string source, string pattern)
        {
            int j = 0;
            int k = 0;

            List<int> results = new List<int>();

            while (j < source.Length)
            {
                if (source[j] == pattern[k])
                {
                    j++;
                    k++;

                    if (k == pattern.Length)
                    {
                        results.Add(j - k);

                    }
                    else
                    {


                    }

                }
            }

            return results;
        }

        //    algorithm kmp_search:
        //input:
        //    an array of characters, S (the text to be searched)
        //    an array of characters, W (the word sought)
        //output:
        //    an array of integers, P (positions in S at which W is found)
        //    an integer, nP (number of positions)

        //define variables:
        //    an integer, j ← 0 (the position of the current character in S)
        //    an integer, k ← 0 (the position of the current character in W)
        //    an array of integers, T (the table, computed elsewhere)

        //let nP ← 0

        //while j<length(S) do
        //    if W[k] = S[j] then // if(source[j] == pattern[k])
        //        let j ← j + 1
        //        let k ← k + 1
        //        if k = length(W) then
        //            (occurrence found, if only first occurrence is needed, m ← j - k may be returned here)
        //            let P[nP] ← j - k, nP ← nP + 1
        //            let k ← T[k] (T[length(W)] can't be -1)
        //    else
        //        let k ← T[k]
        //        if k< 0 then
        //            let j ← j + 1
        //            let k ← k + 1


        public List<int> KMPSearch(string text, string pattern)
        {
            int N = text.Length;
            int M = pattern.Length;

            if (N < M)
                return null;

            if (N == M && text == pattern)
                return new List<int>() { 0 };
            
            if (M == 0)
                return new List<int>() { 0 };

            int[] lpsArray = new int[M];
            List<int> matchedIndex = new List<int>();

            LongestPrefixSuffix(pattern, ref lpsArray);

            int i = 0, j = 0;
            while (i < N)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }

                // match found at i-j
                if (j == M)
                {
                    matchedIndex.Add(i - j);
                    Console.WriteLine((i - j).ToString());
                    j = lpsArray[j - 1];
                }
                else if (i < N && text[i] != pattern[j])
                {
                    if (j != 0)
                    {
                        j = lpsArray[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return matchedIndex;
        }

        public void LongestPrefixSuffix(string pattern, ref int[] lpsArray)
        {
            int M = pattern.Length;
            int len = 0;
            lpsArray[0] = 0;
            int i = 1;

            while (i < M)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lpsArray[i] = len;
                    i++;
                }
                else
                {
                    if (len == 0)
                    {
                        lpsArray[i] = 0;
                        i++;
                    }
                    else
                    {
                        len = lpsArray[len - 1];
                    }
                }
            }
        }



        void KMPSearchII(string pat, string txt)
        {
            int M = pat.Length;
            int N = txt.Length;

            // create lps[] that will hold the longest 
            // prefix suffix values for pattern 
            int[] lps = new int[M];
            int j = 0; // index for pat[] 

            // Preprocess the pattern (calculate lps[] 
            // array) 
            computeLPSArray(pat, M, lps);

            int i = 0; // index for txt[] 
            while (i < N)
            {
                if (pat[j] == txt[i])
                {
                    j++;
                    i++;
                }
                if (j == M)
                {
                    Console.Write("Found pattern "
                                  + "at index " + (i - j));
                    j = lps[j - 1];
                }

                // mismatch after j matches 
                else if (i < N && pat[j] != txt[i])
                {
                    // Do not match lps[0..lps[j-1]] characters, 
                    // they will match anyway 
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i = i + 1;
                }
            }
        }

        void computeLPSArray(string pat, int M, int[] lps)
        {
            // length of the previous longest prefix suffix 
            int len = 0;
            int i = 1;
            lps[0] = 0; // lps[0] is always 0 

            // the loop calculates lps[i] for i = 1 to M-1 
            while (i < M)
            {
                if (pat[i] == pat[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else // (pat[i] != pat[len]) 
                {
                    // This is tricky. Consider the example. 
                    // AAACAAAA and i = 7. The idea is similar 
                    // to search step. 
                    if (len != 0)
                    {
                        len = lps[len - 1];

                        // Also, note that we do not increment 
                        // i here 
                    }
                    else // if (len == 0) 
                    {
                        lps[i] = len;
                        i++;
                    }
                }
            }
        }


    }
}
