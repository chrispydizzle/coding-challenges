namespace Pdrome2.Solves
{
    using System;

    internal class IsIPv4
    {
        public bool isIPv4Address(string inputString)
        {
            string[] set = inputString.Split(new[] {"."}, StringSplitOptions.None);
            if (set.Length != 4) return false;

            foreach (string s in set)
            {
                int number = -1;
                bool isInt = int.TryParse(s, out number);
                if (!isInt || number < 0 || number > 255) return false;
            }

            return true;
        }
    }
}