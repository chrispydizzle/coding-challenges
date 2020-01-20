namespace CodeChallenges.DynamicProgramming
{
    public class FibonacciNum
    {
        public int Fib(int n)
        {
            return this.Fib(n, new int[n + 1]);
        }

        private int Fib(int n, int[] memo)
        {
            return this.FibBottomUp(n);
        }

        private int FibBottomUp(int n)
        {
            if (n == 0 || n == 1) return n;
            int[] memo = new int[n];
            memo[0] = 0;
            memo[1] = 1;
            for (int i = 2; i < n; i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2];
            }

            return memo[n - 1] + memo[n - 2];
        }

        // Top Down DP
        private int FibTopDown(int n, int[] memo)
        {
            if (n == 0 || n == 1) return n;

            if (memo[n] == 0)
            {
                memo[n] = Fib(n - 1, memo) + Fib(n - 2, memo);
            }

            return memo[n];
        }
    }

    public class FibonacciNumSlow
    {
        public int Fib(int N)
        {
            if (N == 0 || N == 1) return N;

            return this.Fib(N - 1) + this.Fib(N - 2);
        }
    }
}