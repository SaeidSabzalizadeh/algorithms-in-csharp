using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Strings.Search
{
    public interface ISearch
    {
        IEnumerable<int> Search(string text, string pattern);
    }
}
