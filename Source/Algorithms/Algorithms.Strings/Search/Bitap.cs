using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Strings.Search
{
    public class Bitap
    {

		#region OP1

		public static int SearchString(string text, string pattern)
		{
			int m = pattern.Length;
			int R;
			int[] patternMask = new int[128];
			int i;

			if (string.IsNullOrEmpty(pattern)) return 0;
			if (m > 31) return -1; //Error: The pattern is too long!

			R = ~1;

			for (i = 0; i <= 127; ++i)
				patternMask[i] = ~0;

			for (i = 0; i < m; ++i)
				patternMask[pattern[i]] &= ~(1 << i);

			for (i = 0; i < text.Length; ++i)
			{
				R |= patternMask[text[i]];
				R <<= 1;

				if (0 == (R & (1 << m)))
					return (i - m) + 1;
			}

			return -1;
		}


		#endregion

	}
}
