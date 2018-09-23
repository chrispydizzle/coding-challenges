namespace Pdrome2
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            this.val = x;
        }

        /// <summary>
        /// returns a tree that looks like :
        ///         1
        ///          \
        ///           2
        ///          /
        ///         3
        /// </summary>
        /// <returns>tree node</returns>
        public static TreeNode BuildSimpleTree()
        {
            TreeNode one = new TreeNode(1);
            TreeNode two = new TreeNode(2);
            one.right = two;
            TreeNode three = new TreeNode(3);
            two.left = three;
            return one;
        }
    }
}