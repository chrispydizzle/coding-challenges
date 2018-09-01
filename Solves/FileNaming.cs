namespace Pdrome2
{
    using System.Collections.Generic;
    using System.Linq;

    internal class FileNaming
    {
        public string[] fileNaming(string[] names)
        {
            string[] result = new string[names.Length];
            Dictionary<string, int> nameCount = new Dictionary<string, int>();
            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];

                if (nameCount.ContainsKey(name))
                {
                    nameCount[name]++;
                    while (result.Contains($"{name}({nameCount[name]})"))
                    {
                        nameCount[name]++;
                    }
                }
                else
                {
                    nameCount.Add(name, 0);
                }

                if (nameCount[name] > 0)
                {
                    string key = $"{name}({nameCount[name]})";
                    result[i] = key;
                    if (!nameCount.ContainsKey(key))
                    {
                        nameCount.Add(result[i], 0);
                    }
                }
                else
                {
                    result[i] = name;
                }
            }

            return result;
        }
    }
}