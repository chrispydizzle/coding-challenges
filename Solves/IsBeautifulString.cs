namespace Pdrome2
{
    internal class IsBeautifulString
    {
        public bool isBeautifulString(string inputString) {
            int[] chars = new int[26];
            foreach (char c in inputString)
            {
                chars[c - 97]++;
            }

            for (int i = 1; i < chars.Length; i++)
            {
                int c = chars[i];
                if (c > chars[i - 1]) return false;
            }

            return true;
        }
    }
}