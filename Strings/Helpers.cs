namespace CodeChallenges.Strings
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Helpers
    {
        public static List<IList<string>> CreateLists(this string[][] args)
        {
            var result = new List<IList<string>>();
            foreach (string[] strings in args)
            {
                result.Add(strings.ToList());
            }

            return result;
        }
    }
}