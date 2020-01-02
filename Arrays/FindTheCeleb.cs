namespace CodeChallenges.Arrays
{
    public class FindTheCeleb
    {
        private readonly int[][] graph;

        public FindTheCeleb(int[][] graph)
        {
            this.graph = graph;
        }

        private bool Knows(int a, int b)
        {
            return graph[a][b] == 1;
        }

        public int FindCelebrity(int n)
        {
            // if (n < 3) return -1;
            // brute force would just call knows while i < n until we found the person that only knows themselves
            // a better way would be to start with person 0 and traverse the node until we find someone they know,  then check out that person from themselves forward,
            // returning the first on that doesn't know anyone else.

            // special case if it's a two person party
            if (n < 3)
            {
                if (Knows(0, 1) && !Knows(1, 0)) return 1;

                if (Knows(1, 0) && !Knows(0, 1)) return 0;

                return -1;
            }

            int pointer = 0;

            // 0, do you know 1?
            while (pointer < n)
            {
                int knownPointer = pointer + 1;
                while (pointer == n - 1 || knownPointer == n || !Knows(pointer, knownPointer))
                {
                    if (knownPointer == n)
                    {
                        // this is our final test, does the last guy know anyone else?
                        int celebCount = pointer - 1;
                        while (celebCount >= 0)
                        {
                            if (Knows(pointer, celebCount)) return -1;
                            celebCount--;
                        }

                        return pointer;
                    }

                    knownPointer++;
                }

                pointer = knownPointer;
            }

            return -1;
        }
    }
}