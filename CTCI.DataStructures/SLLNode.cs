using System;

namespace CTCI.DataStructures
{
    /// <summary>
    /// Singly Linked List Node class.
    /// </summary>
    public class SLLNode
    {
        public int Data;
        public SLLNode Next;
        public SLLNode(int data)
        {
            Data = data;
            Next = null;
        }
        /// <summary>
        /// Given given int value, creates node for data and adds to tail of linked list.
        /// </summary>
        /// <param name="data">int</param>
        public void AddToTail(int data)
        {
            SLLNode currNode = this;

            while (currNode.Next != null)
                currNode = currNode.Next;
            
            SLLNode tailNode = new SLLNode(data);
            currNode.Next = tailNode;
        }

        public void RemoveNode(int data)
        {
            
        }
    }
}
