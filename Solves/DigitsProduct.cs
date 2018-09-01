namespace Pdrome2
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class DigitsProduct
    {
        public int digitsProduct(int product)
        {
            if (product == 1) return 1;
            
            if (product == 0) return 10;
            
            List<int> factors = new List<int>();
            for (int i = 2; i <= 9; i++)
            {
                if (product % i == 0)
                {
                    factors.Add(i);
                }
            }
            
            if (factors.Count == 0) return -1;
            
            int result = 0;
            int places = 1;
            
            Queue<string> q = new Queue<string>();
            //Stack<string> q = new Stack<string>();
            foreach (int factor in factors)
            {
                q.Enqueue(factor.ToString());
                //q.Push(factor.ToString());
            }
            
            while (q.Any())
            {
                string dequeue = q.Dequeue();
                //string dequeue = q.Pop();
                char[] charArray = dequeue.ToCharArray();
                int stProd = 1;
                List<int> numbers = new List<int>();
                foreach (char c in charArray)
                {
                    int i = int.Parse(c.ToString());
                    numbers.Add(i);
                    stProd *= i;
                }
                
                numbers.Sort();
                
                StringBuilder b = new StringBuilder();

                for (int i = 0; i < numbers.Count; i++)
                {
                    b.Append(numbers[i]);
                }
                
                if (stProd == product) return int.Parse(b.ToString());

                if (stProd > product) continue; 
                
                foreach (int factor in factors)
                {
                   // q.Push($"{dequeue}{factor}");
                   q.Enqueue($"{dequeue}{factor}");
                }
            }

            return -1;
        }
    }
}