namespace CTCI.DataStructures
{
    /// <summary>
    /// Binary Tree Node class
    /// </summary>
    public class BTNode<T>
    {
        public T Data { get; set; }
        public BTNode<T> Left { get; set; }
        public BTNode<T> Right { get; set; }

        public BTNode (T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    /// <summary>
    /// Binary Search Tree Node class, inherits from Binary Tree Node.
    /// </summary>
    public class BSTNode : BTNode<int>
    {
        public BSTNode(int data) : base(data) {}
    }
}