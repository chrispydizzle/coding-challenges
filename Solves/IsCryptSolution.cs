namespace CodeChallenges.Solves
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class IsCryptSolution
    {
        public bool isCryptSolution(string[] crypt, char[][] solution)
        {
            Dictionary<char, string> charmap = solution.ToDictionary(c => c[0], c => c[1].ToString());

            long[] results = new long[crypt.Length];

            for (int i = 0; i < crypt.Length; i++)
            {
                string s = crypt[i];
                StringBuilder b = new StringBuilder();
                for (int j = 0; j < s.Length; j++)
                {
                    char c = s[j];
                    if (j == 0 && charmap[c] == "0" && s.Length > 1)
                    {
                        return false;
                    }

                    b.Append(charmap[c]);
                }

                results[i] = long.Parse(b.ToString());
            }

            if (results[0] + results[1] == results[2]) return true;

            return false;
        }

        private void Main(string[] args)
        {
            IsCryptSolution a = new IsCryptSolution();
            Console.WriteLine(a.isCryptSolution(new[]
            {
                "SEND",
                "MORE",
                "MONEY"
            }, new[]
            {
                new[] {'O', '0'},
                new[] {'M', '1'},
                new[] {'Y', '2'},
                new[] {'E', '5'},
                new[] {'N', '6'},
                new[] {'D', '7'},
                new[] {'R', '8'},
                new[] {'S', '9'}
            }));

            Console.WriteLine(a.isCryptSolution(new[]
            {
                "AA",
                "MORE",
                "MONEY"
            }, new[]
            {
                new[] {'O', '0'},
                new[] {'M', '1'},
                new[] {'Y', '2'},
                new[] {'E', '5'},
                new[] {'N', '6'},
                new[] {'D', '7'},
                new[] {'R', '8'},
                new[] {'S', '9'}
            }));

            Console.ReadLine();
        }
    }
}