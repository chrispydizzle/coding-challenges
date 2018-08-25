namespace Pdrome2
{
    using System.Linq;

    public class MakeArrayConsecutive
    {
        public int makeArrayConsecutive2(int[] statues)
        {
            int max = statues.Max();
            int min = statues.Min();

            int length = statues.Length;

            return (max - min) - length + 1;
        }
    }
}