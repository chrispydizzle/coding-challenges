namespace Pdrome2
{
    using System.Text;

    public class DoCountAndSay
    {
        public string CountAndSay(int n) {        
            return this.CountAndSay(n-1, "1") ;
        }
    
        public string CountAndSay(int n, string number) {        
            if(n == 0) return number;
        
            char currentNumber = number[0];
            int count = 0;
            StringBuilder b = new StringBuilder();
        
            // for each char in number
            for(int i = 0; i< number.Length; i++){
                // if char is same as current
                if(currentNumber == number[i])
                {
                    // increment counter && continue
                    count++;
                    continue;
                }
            
                b.Append($"{count}{currentNumber}");
                currentNumber = number[i];
                count = 1;
                // if it is different, append 
                // set currentNumber to the new number and set counter to 1
            }
        
            b.Append($"{count}{currentNumber}");
        
            // recurse 
            return this.CountAndSay(n-1, b.ToString());
        }    
    }
}