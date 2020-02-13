namespace CodeChallenges
{
    using System;
    using System.Collections;
    using Arrays;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            ThreeSumCloses t = new ThreeSumCloses();
            W(t.ThreeSumClosest(new[] {0, 2, 1, -3}, 1));
            W(t.ThreeSumClosest(new[] {-1, 2, 1, -4}, 1));
        }

        public static void TMain(string[] args)
        {
            Search2DMatrix m = new Search2DMatrix();
            int[,] grid2 = new[,]
            {
                {1, 2, 3, 4, 5},
                {6, 7, 8, 9, 10},
                {11, 12, 13, 14, 15},
                {16, 17, 18, 19, 20},
                {21, 22, 23, 24, 25}
            };

            W(m.SearchMatrix(new[,]
            {
                {93, 157, 226, 308, 365, 384, 479, 539, 557, 652},
                {118, 234, 287, 368, 395, 432, 480, 607, 634, 723},
                {132, 263, 381, 453, 525, 533, 577, 650, 707, 800},
                {171, 307, 473, 504, 526, 596, 643, 719, 776, 842},
                {233, 319, 514, 571, 668, 710, 733, 777, 875, 886},
                {318, 362, 555, 605, 717, 782, 809, 884, 889, 940},
                {349, 415, 622, 708, 787, 795, 824, 921, 957, 1014},
                {414, 420, 656, 789, 813, 898, 954, 1052, 1095, 1175},
                {430, 477, 705, 863, 961, 991, 1003, 1121, 1190, 1236},
                {524, 611, 793, 868, 1027, 1111, 1112, 1123, 1252, 1253}
            }, 430));

            W(m.SearchMatrix(grid2, 11));
            W(m.SearchMatrix(grid2, 5));

            W(m.SearchMatrix(grid2, 15));
            int[,] grid =
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };
            W(m.SearchMatrix(new[,] {{1, 4, 7, 11, 15}}, 4));
            W(m.SearchMatrix(new[,] {{1, 4, 7, 11, 15}}, 15));

            W(m.SearchMatrix(new[,] {{1, 4, 7, 11, 15}}, 1));

            W(m.SearchMatrix(grid, 20));
        }

        public static void SecondOldMain(string[] args)
        {
            TwoSumLTK p = new TwoSumLTK();
            var res1 = p.TwoSumLessThanK(new[] {358, 898, 450, 732, 672, 672, 256, 542, 320, 573, 423, 543, 591, 280, 399, 923, 920, 254, 135, 952, 115, 536, 143, 896, 411, 722, 815, 635, 353, 486, 127, 146, 974, 495, 229, 21, 733, 918, 314, 670, 671, 537, 533, 716, 140, 599, 758, 777, 185, 549},
                1800);
            var res = p.TwoSumLessThanK(new[] {34, 23, 1, 24, 75, 33, 54, 8}, 60);
            Console.Read();
        }

        private static void W(object o)
        {
            if (o is IEnumerable enumerable && !(o is string s))
            {
                if (o is IList)
                {
                    Console.WriteLine($" IList count: {(o as IList).Count}");
                }

                foreach (object v in enumerable)
                {
                    W(v);
                }
            }

            Console.WriteLine($" Raw object: {o}");
        }
    }
}

namespace ExtensionMs
{
}