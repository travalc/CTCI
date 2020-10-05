namespace CTCI.DataStructures
{
    public class BSTNode
    {
        public int Data { get; set; }
        public BSTNode Left { get; set; }
        public BSTNode Right { get; set; }

        public BSTNode (int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}