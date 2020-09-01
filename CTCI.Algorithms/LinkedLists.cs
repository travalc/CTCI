using CTCI.DataStructures;
using System;

namespace CTCI.Algorithms
{
    /// <summary>
    /// Algorithms for Linked List problems
    /// </summary>
    public static class LinkedLists
    {
        /// <summary>
        /// Given a SLLNode head node, and int data, deletes first node containing this value.
        /// </summary>
        /// <param name="headNode">SLLNode</param>
        /// <param name="data">int</param>
        /// <returns>SLLNode</returns>
        public static SLLNode DeleteNode(SLLNode headNode, int data)
        {
            if (headNode == null)
                return null;
            
            if (headNode.Data == data)
                return headNode.Next;
            
            SLLNode currNode = headNode;
            while (currNode.Next != null)
            {
                if (currNode.Next.Data == data)
                {
                    currNode.Next = currNode.Next.Next;
                    return headNode;
                }
                currNode = currNode.Next;
            }

            return headNode;
        }
    }
}