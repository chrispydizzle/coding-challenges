namespace CodeChallenges
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Arrays;
    using Interviews;
    using Strings;

    internal static class Program
    {
        public static void MainS(string[] args)
        {
            string test = @"photo.jpg, Warsaw, 2013-09-05 14:08:15
john.png, London, 2015-06-20 15:13:22
myFriends.png, Warsaw, 2013-09-05 14:07:13
Eiffel.jpg, Paris, 2015-07-23 08:03:02
pisatower.jpg, Paris, 2015-07-22 23:59:59
BOB.jpg, London, 2015-08-05 00:02:03
notredame.png, Paris, 2015-09-01 12:00:00
me.jpg, Warsaw, 2013-09-06 15:40:22
a.png, Warsaw, 2016-02-13 13:33:50
b.jpg, Warsaw, 2016-01-02 15:12:22
c.jpg, Warsaw, 2016-01-02 14:34:30
d.jpg, Warsaw, 2016-01-02 15:15:01
e.png, Warsaw, 2016-01-02 09:49:09
f.png, Warsaw, 2016-01-02 10:55:32
g.jpg, Warsaw, 2016-02-29 22:13:11";

            BetterActual b = new BetterActual();
            // W(b.solutionABC("CABBAC"));
            // W(b.solutionABC("ACCAABBC"));
            // W(b.solutionABC("BABABA"));
            // W(b.solutionABC(""));
            // W(b.solutionABC("A"));
            SortedDictionary<string, List<string>> d = new SortedDictionary<string, List<string>>();
            W(b.solution(test));
            W(b.solution("photo.jpg, Warsaw, 2013-09-05 14:08:15"));
        }

        public static void Main(string[] args)
        {
            ReverseOnlyLters l = new ReverseOnlyLters();
            W(l.ReverseOnlyLetters("Test1ng-Leet=code-Q!"));
            W(l.ReverseOnlyLetters("a-bC-dEf-ghIj"));

            /*W(d.MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new[] {"hit"}));
            W(d.MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new[] {"ball"}));
            W(d.MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new[] {"ball","hit"}));*/
        }

        public static void MainLater(string[] args)
        {
            BetterPractice bp = new BetterPractice();
            List<int> range1 = Enumerable.Range(-1, 6).ToList();
            range1.Remove(3);
            List<int> range2 = Enumerable.Range(0, 200).ToList();
            range2.Remove(101);

            List<int> range3 = Enumerable.Range(-500, 10005).ToList();
            range3.Remove(111);
            List<int> range4 = Enumerable.Range(-1, 500000).ToList();
            range4.Remove(10000);

            List<int> range5 = Enumerable.Range(-1000, 9005).ToList();
            range5.Remove(5);

            List<int> range6 = Enumerable.Range(1, 40004).ToList();
            range6.Remove(40000);

            W(bp.solution(range6.ToArray()));
            W(bp.solution(range5.ToArray()));
            W(bp.solution(new[] {1}));
            W(bp.solution(new[] {1, 2, 3}));
            W(bp.solution(range1.ToArray()));
            W(bp.solution(range2.ToArray()));
            W(bp.solution(range3.ToArray()));
            W(bp.solution(range4.ToArray()));
            W(bp.solution(new[] {1, 1000000}));

            Console.Read();
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
                {
                    93, 157, 226, 308, 365, 384, 479, 539, 557, 652
                },
                {
                    118, 234, 287, 368, 395, 432, 480, 607, 634, 723
                },
                {
                    132, 263, 381, 453, 525, 533, 577, 650, 707, 800
                },
                {
                    171, 307, 473, 504, 526, 596, 643, 719, 776, 842
                },
                {
                    233, 319, 514, 571, 668, 710, 733, 777, 875, 886
                },
                {
                    318, 362, 555, 605, 717, 782, 809, 884, 889, 940
                },
                {
                    349, 415, 622, 708, 787, 795, 824, 921, 957, 1014
                },
                {
                    414, 420, 656, 789, 813, 898, 954, 1052, 1095, 1175
                },
                {
                    430, 477, 705, 863, 961, 991, 1003, 1121, 1190, 1236
                },
                {
                    524, 611, 793, 868, 1027, 1111, 1112, 1123, 1252, 1253
                }
            }, 430));
            W(m.SearchMatrix(grid2, 11));
            W(m.SearchMatrix(grid2, 5));
            W(m.SearchMatrix(grid2, 15));
            int[,] grid =
            {
                {
                    1, 4, 7, 11, 15
                },
                {
                    2, 5, 8, 12, 19
                },
                {
                    3, 6, 9, 16, 22
                },
                {
                    10, 13, 14, 17, 24
                },
                {
                    18, 21, 23, 26, 30
                }
            };
            W(m.SearchMatrix(new[,]
            {
                {
                    1, 4, 7, 11, 15
                }
            }, 4));
            W(m.SearchMatrix(new[,]
            {
                {
                    1, 4, 7, 11, 15
                }
            }, 15));
            W(m.SearchMatrix(new[,]
            {
                {
                    1, 4, 7, 11, 15
                }
            }, 1));
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