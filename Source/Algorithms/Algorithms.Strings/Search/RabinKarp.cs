using System;
using System.Collections.Generic;

namespace Algorithms.Strings.Search
{
    public class RabinKarp : ISearch
    {

        static int primeNumber = 101;

        public IEnumerable<int> Search(string text, string pattern)
        {
            List<int> resultIndex = new List<int>();

            int patternLength = pattern.Length;
            int textLength = text.Length;
            int i, j;

            int patternHash = 0; // hash value for pattern  
            int textHash = 0; // hash value for txt  
            int h = 1;

            // The value of h would be "pow(d, M-1)%q"  
            for (i = 0; i < patternLength - 1; i++)
                h = (h * d) % primeNumber;

            // Calculate the hash value of pattern and first  
            // window of text  
            for (i = 0; i < patternLength; i++)
            {
                patternHash = (d * patternHash + pattern[i]) % primeNumber;
                textHash = (d * textHash + text[i]) % primeNumber;
            }

            // Slide the pattern over text one by one  
            for (i = 0; i <= textLength - patternLength; i++)
            {

                // Check the hash values of current window of text  
                // and pattern. If the hash values match then only  
                // check for characters on by one  
                if (patternHash == textHash)
                {
                    /* Check for characters one by one */
                    for (j = 0; j < patternLength; j++)
                    {
                        if (text[i + j] != pattern[j])
                            break;
                    }

                    // if p == t and pat[0...M-1] = txt[i, i+1, ...i+M-1]  
                    if (j == patternLength)
                        resultIndex.Add(i);
                }

                // Calculate hash value for next window of text: Remove  
                // leading digit, add trailing digit  
                if (i < textLength - patternLength)
                {
                    textHash = (d * (textHash - text[i] * h) + text[i + patternLength]) % primeNumber;

                    // We might get negative value of t, converting it  
                    // to positive  
                    if (textHash < 0)
                        textHash = (textHash + primeNumber);
                }
            }

            return resultIndex;
        }



        #region Other Options

        public static int SearchII(string source, string pattern)
        {
            int patternHash = pattern.GetHashCode();

            for (int i = 0; i <= source.Length - pattern.Length; i++)
            {
                int currentHash = source.Substring(i, i + pattern.Length).GetHashCode();
                if (currentHash == patternHash && source.Substring(i, i + pattern.Length) == pattern)
                    return i;
            }

            return -1;
        }

        public static int[] SearchString(string A, string B)
        {
            List<int> retVal = new List<int>();
            ulong siga = 0;
            ulong sigb = 0;
            ulong Q = 100007;
            ulong D = 256;

            for (int i = 0; i < B.Length; ++i)
            {
                siga = (siga * D + (ulong)A[i]) % Q;
                sigb = (sigb * D + (ulong)B[i]) % Q;
            }

            if (siga == sigb)
                retVal.Add(0);

            ulong pow = 1;

            for (int k = 1; k <= B.Length - 1; ++k)
                pow = (pow * D) % Q;

            for (int j = 1; j <= A.Length - B.Length; ++j)
            {
                siga = (siga + Q - pow * (ulong)A[j - 1] % Q) % Q;
                siga = (siga * D + (ulong)A[j + B.Length - 1]) % Q;

                if (siga == sigb)
                    if (A.Substring(j, B.Length) == B)
                        retVal.Add(j);
            }

            return retVal.ToArray();
        }


        public readonly static int d = 256;

        /* pat -> pattern  
            txt -> text  
            q -> A prime number  
        */

        static void SearchIII(string text, string pattern)
        {
            int patternLength = pattern.Length;
            int textLength = text.Length;
            int i, j;

            int patternHash = 0; // hash value for pattern  
            int textHash = 0; // hash value for txt  
            int h = 1;

            // The value of h would be "pow(d, M-1)%q"  
            for (i = 0; i < patternLength - 1; i++)
                h = (h * d) % primeNumber;

            // Calculate the hash value of pattern and first  
            // window of text  
            for (i = 0; i < patternLength; i++)
            {
                patternHash = (d * patternHash + pattern[i]) % primeNumber;
                textHash = (d * textHash + text[i]) % primeNumber;
            }

            // Slide the pattern over text one by one  
            for (i = 0; i <= textLength - patternLength; i++)
            {

                // Check the hash values of current window of text  
                // and pattern. If the hash values match then only  
                // check for characters on by one  
                if (patternHash == textHash)
                {
                    /* Check for characters one by one */
                    for (j = 0; j < patternLength; j++)
                    {
                        if (text[i + j] != pattern[j])
                            break;
                    }

                    // if p == t and pat[0...M-1] = txt[i, i+1, ...i+M-1]  
                    if (j == patternLength)
                        Console.WriteLine("Pattern found at index " + i);
                }

                // Calculate hash value for next window of text: Remove  
                // leading digit, add trailing digit  
                if (i < textLength - patternLength)
                {
                    textHash = (d * (textHash - text[i] * h) + text[i + patternLength]) % primeNumber;

                    // We might get negative value of t, converting it  
                    // to positive  
                    if (textHash < 0)
                        textHash = (textHash + primeNumber);
                }
            }
        }





        //public int patternSearch(char[] text, char[] pattern)
        //{
        //    int m = pattern.Length;
        //    int n = text.Length;
        //    long patternHash = createHash(pattern, m - 1);
        //    long textHash = createHash(text, m - 1);
        //    for (int i = 1; i <= n - m + 1; i++)
        //    {
        //        if (patternHash == textHash && checkEqual(text, i - 1, i + m - 2, pattern, 0, m - 1))
        //        {
        //            return i - 1;
        //        }
        //        if (i < n - m + 1)
        //        {
        //            textHash = recalculateHash(text, i - 1, i + m - 1, textHash, m);
        //        }
        //    }
        //    return -1;
        //}

        //private long recalculateHash(char[] str, int oldIndex, int newIndex, long oldHash, int patternLen)
        //{
        //    long newHash = oldHash - str[oldIndex];
        //    newHash = newHash / prime;
        //    newHash += (long)(str[newIndex] * Math.Pow(prime, patternLen - 1));
        //    return newHash;
        //}

        //private long createHash(char[] str, int end)
        //{
        //    long hash = 0;
        //    for (int i = 0; i <= end; i++)
        //    {
        //        hash += (long)(str[i] * Math.Pow(prime, i));
        //    }
        //    return hash;
        //}

        //private bool checkEqual(char[] str1, int start1, int end1, char[] str2, int start2, int end2)
        //{
        //    if (end1 - start1 != end2 - start2)
        //    {
        //        return false;
        //    }
        //    while (start1 <= end1 && start2 <= end2)
        //    {
        //        if (str1[start1] != str2[start2])
        //        {
        //            return false;
        //        }
        //        start1++;
        //        start2++;
        //    }
        //    return true;
        //}

        #endregion
    }
}
