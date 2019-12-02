namespace CodeChallenges.Strings
{
    using System;
    using System.Collections.Generic;

    public class GroupAngram
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> result = new List<IList<string>>();

            // create a dictionary to arrange our anagrams
            Dictionary<string, List<string>> resultDict = new Dictionary<string, List<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                // order characters in the string alphabetically
                char[] array = strs[i].ToCharArray();
                Array.Sort(array);
                string key = new string(array);

                // check dictionary for the key
                List<string> targetList;

                if (!resultDict.TryGetValue(key, out targetList))
                {
                    // if not found, create a new list with the value
                    targetList = new List<string>();
                    resultDict.Add(key, targetList);
                }

                // if found, add to list
                targetList.Add(strs[i]);

                resultDict[key] = targetList;
            }

            foreach (KeyValuePair<string, List<string>> keyValuePair in resultDict)
            {
                result.Add(keyValuePair.Value);
            }

            return result;
        }
    }
}