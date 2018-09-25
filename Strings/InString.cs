namespace Pdrome2
{
    public class InString
    {
        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle) || haystack == needle) return 0;
            if (string.IsNullOrEmpty(haystack)) return -1;

            int iReset = 0;
            char seek = needle[0];
            for (int i = 0; i < haystack.Length - (needle.Length - 1); i++)
            {
                if (haystack[i] == seek)
                {
                    if (needle.Length == 1) return i;

                    bool foundNeedle = true;
                    for (int j = 1; j < needle.Length; j++)
                    {
                        // potential optimization for i here
                        // if we found another i we can set i to that later incase it fails this search
                        if (needle[j] != haystack[i + j])
                        {
                            foundNeedle = false;
                            break;
                        }
                    }

                    if (foundNeedle == true) return i;
                }
            }

            return -1;
        }
    }
}