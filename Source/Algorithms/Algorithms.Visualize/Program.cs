using Algorithms.Strings.Pattern;
using Algorithms.Strings.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Algorithms.Visualize
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "zf3kabxcde224lkzf3mabxc51+crsdtzf3nab=";

            Console.WriteLine("...........................");

            Dictionary<string, int> patterns = PatternDiscovery(text, 3);

            foreach (var item in patterns)
            {
                Console.WriteLine($"'{item.Key}': {item.Value}");
            }


            //RunLZW(text);

            Console.ReadLine();
        }



    private static Dictionary<string, int> PatternDiscovery(string text, int patternLength)
    {
        Dictionary<string, int> patterns = new Dictionary<string, int>();

        for (int i = 0; i < text.Length - patternLength; i++)
        {
            FindPattern(text, text.Substring(i, patternLength), patterns);
        }

        return patterns;

    }

    private static void FindPattern(string text, string pattern, Dictionary<string, int> patterns)
    {
        if (patterns.ContainsKey(pattern))
            return;

        ISearch kmpSearch = new KnuthMorrisPratt();
        List<int> searchResult = kmpSearch.Search(text, pattern)?.ToList();

        if (searchResult != null && searchResult.Any() && searchResult.Count > 1)
            patterns.Add(pattern, searchResult.Count);
    }

        private static void RunLZW(string text)
        {
            List<int> compressed = LZW.Compress(text);
            Console.WriteLine(string.Join(", ", compressed));
            string decompressed = LZW.Decompress(compressed);
            Console.WriteLine(decompressed);
            Console.WriteLine($"text.Length: {text.Length}, compressed.Length: {compressed.Count}");
        }

        private static void RunSuffixTree(string text)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(text);
            Console.WriteLine("----------------------------------------------");
            var st = new SuffixTree(text);

            foreach (var item in st.nodes)
            {
                Console.WriteLine($"'{item.sub}': [{string.Join(", ", item.ch)}]");
            }

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            st.Visualize();
        }
    }
}
