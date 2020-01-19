namespace CodeChallenges
{
    using System;
    using System.Collections;
    using BinaryTrees;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = new BTreeUpsideDown();
            Console.WriteLine(s.UpsideDownBinaryTree(TreeNode.BuildTree(1, 2, 3, 4, 5)).ToStringFancy());
            Console.WriteLine(s.UpsideDownBinaryTree(TreeNode.BuildTree(1, 2, null, 3, null, 4, null, 5)).ToStringFancy());
            Console.WriteLine(s.UpsideDownBinaryTree(TreeNode.BuildTree(1, 2, null, 3, null, 4)).ToStringFancy());
            Console.WriteLine(s.UpsideDownBinaryTree(TreeNode.BuildTree(1, 2)).ToStringFancy());

            Console.Read();
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