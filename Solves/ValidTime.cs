namespace CodeChallenges.Solves
{
    internal class ValidTime
    {
        public bool validTime(string time)
        {
            string[] strings = time.Split(':');
            if (strings.Length != 2) return false;

            if (strings[0].Length != 2 || strings[1].Length != 2) return false;

            int l = int.Parse(strings[0]);
            int r = int.Parse(strings[1]);
            if (l >= 0 && l < 24 && r >= 0 && r < 60)
            {
                return true;
            }

            return false;
        }
    }
}