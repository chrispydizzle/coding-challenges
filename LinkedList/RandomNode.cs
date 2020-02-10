namespace CodeChallenges.LinkedList
{
    using System.Text;

    // Definition for singly-linked list.
    public class RandomNode
    {
        public RandomNode next;
        public int val;
        public RandomNode random;

        public RandomNode(int x)
        {
            this.val = x;
        }

        public static RandomNode Make(params int[] args)
        {
            RandomNode root = new RandomNode(args[0]);
            RandomNode next = root;
            for (int i = 1; i < args.Length; i++)
            {
                RandomNode newNode = new RandomNode(args[i]);
                next.next = newNode;
                next = next.next;
            }

            return root;
        }

        public static RandomNode[] MakeRange(params int[][] args)
        {
            RandomNode[] ln = new RandomNode[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                int[] ints = args[i];
                ln[i] = RandomNode.Make(ints);
            }

            return ln;
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append($"{this.val} => ");
            RandomNode next = this.next;
            while (next != null)
            {
                b.Append($"{next.val} => ");
                next = next.next;
            }

            b.Append($"# ");
            return b.ToString();
        }
    }
}