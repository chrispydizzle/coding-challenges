namespace CodeChallenges.Solves
{
    public class CommonCharacterCount
    {
        public int commonCharacterCount(string s1, string s2)
        {
            int count = 0;
            foreach (char c in s1)
            {
                for (int i = 0; i < s2.Length; i++)
                {
                    if (c == s2[i])
                    {
                        count++;
                        s2 = s2.Remove(i, 1);
                        break;
                    }
                }
            }

            return count;
        }
    }
}