using Algorithms.Strings.Search;
using System;
using System.Linq;
using Xunit;

namespace Algorithms.Tests
{
    public class StringSearchTest
    {
        [Fact]
        public void KMP_Test()
        {
            ISearch kmpSearch = new KnuthMorrisPratt(); 
            AssertStringSearch(kmpSearch);

        }

        [Fact]
        public void BoyerMoore_Test()
        {
            ISearch kmpSearch = new BoyerMoore();
            AssertStringSearch(kmpSearch);

        }

        [Fact]
        public void RabinKarp_Test()
        {
            ISearch kmpSearch = new RabinKarp();
            AssertStringSearch(kmpSearch);

        }


        

        private void AssertStringSearch(ISearch searchAlgorithm)
        {
            string sampleText = "zf3kabxcde224lkzf3mabxc51+crsdtzf3nab=";


            string pattern1 = "abx";
            var pattern1Result = searchAlgorithm.Search(sampleText, pattern1).ToList();
            
            Assert.NotNull(pattern1Result);
            Assert.True(pattern1Result.Count() == 2);
            Assert.Equal(4, pattern1Result[0]);
            Assert.Equal(19, pattern1Result[1]);


            string pattern2 = "zf3";
            var pattern2Result = searchAlgorithm.Search(sampleText, pattern2).ToList();
            
            Assert.NotNull(pattern2Result);
            Assert.True(pattern2Result.Count() == 3);
            Assert.Equal(0, pattern2Result[0]);
            Assert.Equal(15, pattern2Result[1]);
            Assert.Equal(31, pattern2Result[2]);

        }
    }
}
