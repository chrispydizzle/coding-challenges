namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;
    using System.Text;

    public class LetterCombinationsPhone
    {
        private readonly Dictionary<char, char[]> map = new Dictionary<char, char[]>()
        {
            {
                '1', new char[] { }
            },
            {
                '2', new char[] {'a', 'b', 'c'}
            },

            {
                '3', new char[] {'d', 'e', 'f'}
            },
            {
                '4', new char[] {'g', 'h', 'i'}
            },

            {
                '5', new char[] {'j', 'k', 'l'}
            },
            {
                '6', new char[] {'m', 'n', 'o'}
            },

            {
                '7', new char[] {'p', 'q', 'r', 's'}
            },

            {
                '8', new char[]
                {
                    't', 'u', 'c'
                }
            },

            {
                '9', new char[]
                {
                    'w', 'x', 'y', 'z'
                }
            },

            {
                '#', new char[]
                {
                }
            },
            {
                '0', new char[]
                {
                    ' '
                }
            },
            {
                '*', new char[]
                {
                }
            }
        };

        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits)) return new List<string>();

            List<char[]> mappedNums = new List<char[]>();
            foreach (char c in digits)
            {
                mappedNums.Add(map[c]);
            }


            return this.LetterCombinations(string.Empty, mappedNums);
        }

        private IList<string> LetterCombinations(string s, List<char[]> mappedNums)
        {
            var result = new List<string>();


            StringBuilder b = new StringBuilder();

            var currentSet = mappedNums[0];
            mappedNums.RemoveAt(0);

            if (mappedNums.Count == 0)
            {
                foreach (char c in currentSet)
                {
                    result.Add($"{s}{c}");
                }

                mappedNums.Insert(0, currentSet);
                return result;
            }


            foreach (char c in currentSet)
            {
                result.AddRange(this.LetterCombinations($"{s}{c}", mappedNums));
            }

            mappedNums.Insert(0, currentSet);
            return result;
        }
    }
}