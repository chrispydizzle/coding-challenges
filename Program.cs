namespace CodeChallenges
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using BinaryTrees;
    using Interviews;
    using Strings;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = new Uber();
            W(s.closestLocation("Location",
                new[]
                {
                    new[] {-2, 0},
                    new[] {1, 2},
                    new[] {2, 1, 2, 4},
                    new[] {-3, -1, 4, -1}
                },
                new[]
                {
                    "Locati",
                    "Location", "Bat building", "Cast exhibition", "At street", "Cat avenue, ", "Bloop"
                }));


            /*s.nightRoute(new[]
            {
                new[] {-1, -1, 19, 8, 18, -1, -1, -1, -1, -1},
                new[] {10, 6, 4, 7, 0, 10, 18, -1, 0, -1},
                new[] {-1, -1, 15, -1, 17, 3, -1, 14, 16, 3},
                new[] {4, 19, 3, 15, 8, 4, 6, 11, 5, 8},
                new[] {5, 3, 10, -1, 0, 14, 15, 1, 16, 5},
                new[] {-1, 8, -1, -1, 5, -1, 5, 0, 1, -1},
                new[] {-1, 18, -1, 19, 2, -1, 10, -1, 8, 6},
                new[] {14, 8, 12, 16, -1, -1, 0, 16, 15, 17},
                new[] {4, 5, 1, 12, 0, 4, 8, 15, 1, -1},
                new[] {13, 7, 17, -1, 4, 13, 16, 3, 12, 9}
            });*/
            /*W(s.parkingSpot(new[] {3, 2},
                new[]
                {
                    new[] {1, 0, 1, 0, 1, 0},
                    new[] {1, 0, 0, 0, 1, 0},
                    new[] {0, 0, 0, 0, 0, 1},
                    new[] {1, 0, 0, 0, 1, 1}
                }, new[] {1, 1, 2, 3}));*/
            /*W(s.parkingSpot(new[] {4, 2},
                new[]
                {
                    new[] {0, 0, 0, 1},
                    new[] {0, 0, 0, 0},
                    new[] {0, 0, 1, 1}
                }, new[] {0, 0, 1, 3}));
            Console.ReadLine();*/
        }

        public static void MainLata(string[] args)
        {
            var s = new FindReconstructItin();
            List<IList<string>> lists = new[] {new[] {"MUC", "LHR"}, new[] {"JFK", "MUC"}, new[] {"SFO", "SJC"}, new[] {"LHR", "SFO"}}.CreateLists();
            List<IList<string>> lists2 = new[] {new[] {"JFK", "SFO"}, new[] {"JFK", "ATL"}, new[] {"SFO", "ATL"}, new[] {"ATL", "JFK"}, new[] {"ATL", "SFO"}}.CreateLists();
            List<IList<string>> lists3 = new[] {new[] {"JFK", "KUL"}, new[] {"JFK", "NRT"}, new[] {"NRT", "JFK"}}.CreateLists();
            List<IList<string>> lists4 = new[] {new[] {"JFK", "AAA"}, new[] {"AAA", "JFK"}, new[] {"JFK", "BBB"}, new[] {"JFK", "CCC"}, new[] {"CCC", "JFK"}}.CreateLists();
            List<IList<string>> lists5 = new[] {new[] {"EZE", "TIA"}, new[] {"EZE", "HBA"}, new[] {"AXA", "TIA"}, new[] {"JFK", "AXA"}, new[] {"ANU", "JFK"}, new[] {"ADL", "ANU"}, new[] {"TIA", "AUA"}, new[] {"ANU", "AUA"}, new[] {"ADL", "EZE"}, new[] {"ADL", "EZE"}, new[] {"EZE", "ADL"}, new[] {"AXA", "EZE"}, new[] {"AUA", "AXA"}, new[] {"JFK", "AXA"}, new[] {"AXA", "AUA"}, new[] {"AUA", "ADL"}, new[] {"ANU", "EZE"}, new[] {"TIA", "ADL"}, new[] {"EZE", "ANU"}, new[] {"AUA", "ANU"}}.CreateLists();

            W(s.FindItinerary(lists5));
            W(s.FindItinerary(lists4));
            W(s.FindItinerary(lists3));

            W(s.FindItinerary(lists2));
            W(s.FindItinerary(lists));


            Console.ReadLine();
        }

        private static void W(object o)
        {
            if (o is IEnumerable enumerable && !(o is string s))
            {
                foreach (object v in enumerable)
                {
                    W(v);
                }
            }

            Console.WriteLine($" Raw object: {o}");
        }
    }
}