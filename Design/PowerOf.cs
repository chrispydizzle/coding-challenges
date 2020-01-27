namespace CodeChallenges.Design
{
    using System.Collections.Generic;

    public class PowerOf
    {
        public PowerOf()
        {
            results = new List<double>();
        }

        public double MyPow(double x, int n)
        {
            int subt = 0;
            int raised = 1;
            bool neg = false;
            if (n == 0) return 1;

            if (n < 0)
            {
                neg = true;
                n = -n;
            }

            int divs = 0;
            int lessWork = n;
            double result = x;
            while (lessWork > 0)
            {
                if (lessWork % 2 > 0)
                {
                    result *= x;
                    results.Add(result);
                }

                lessWork = lessWork / 2;


                divs += 1;
            }


            while (raised < divs)
            {
                result *= result;

                raised++;
                results.Add(result);
            }

            while (subt > 0)
            {
                result = result * x;
                subt--;
            }

            if (neg) result = 1 / result;
            return result;
        }

        private List<double> results;

        public double AltPow(double x, int n)
        {
            long N = n;
            if (N < 0)
            {
                x = 1 / x;
                N = -N;
            }

            return FastPow(x, N);
        }

        private double FastPow(double x, long n)
        {
            if (n == 0)
            {
                return 1.0;
            }

            double half = FastPow(x, n / 2);
            if (n % 2 == 0)
            {
                results.Add(half * half);
                return results[results.Count - 1];
            }
            else
            {
                results.Add(half * half * x);
                return results[results.Count - 1];
            }
        }
    }
}