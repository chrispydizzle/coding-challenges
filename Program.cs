namespace CodeChallenges
{
    using System;
    using Arrays;

    public static class Program
    {
        public static void Main(string[] args)
        {
            ContainerWithMostWater s = new ContainerWithMostWater();
            W(s.MaxArea(new[] {1, 8, 6, 2, 5, 4, 8, 3, 7}));
            W(s.MaxArea(new[] {1, 2, 4, 3}));

            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}