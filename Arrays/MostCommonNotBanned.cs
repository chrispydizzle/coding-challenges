namespace CodeChallenges.Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MostCommonNotBanned
    {
        // !?',;.
        public string MostCommonWord(string paragraph, string[] banned)
        {
            // this seems deceptively simple?
            // replace each punctuation mark and banned word with a blank space
            // split string by " ", removeemptyentries. lcase
            // count words,return most seen...?
            List<string> repList = new List<string>(new[] {"!", "?", "'", ",", ";", "."});
            string newPara = " " + paragraph.ToLower();
            foreach (string s in repList)
            {
                newPara = newPara.Replace(s, " ");
            }

            newPara += " ";
            string[] strings = newPara.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var g = strings.GroupBy(s => s)
                .Select(d => new
                {
                    Value = d.Key,
                    Counted = d.Count()
                }).Where(w => !banned.Contains(w.Value));
            int maxCount = g.Max(m => m.Counted);

            return g.FirstOrDefault(grp => grp.Counted == maxCount).Value;
        }
    }
}