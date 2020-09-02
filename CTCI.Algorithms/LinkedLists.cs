using CTCI.DataStructures;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Given a SLL node, removes nodes with duplicate values
        /// O(n) time, O(n) space
        /// </summary>
        /// <param name="headNode">SLLNode</param>
        /// <returns>SLLNode</returns>
        public static SLLNode RemoveDups(SLLNode headNode)
        {
            if (headNode == null)
                return null;
            if (headNode.Next == null)
                return headNode;
            
            HashSet<int> set = new HashSet<int>();
            set.Add(headNode.Data);

            SLLNode currNode = headNode;
            while (currNode.Next != null)
            {
                if (set.Contains(currNode.Next.Data))
                {
                    SLLNode newNextNode = currNode.Next.Next;
                    while (newNextNode != null && set.Contains(newNextNode.Data))
                        newNextNode = newNextNode.Next;
                    
                    currNode.Next = newNextNode;
                    if (newNextNode == null)
                        return headNode;
                    set.Add(newNextNode.Data);
                }
                else
                {
                    set.Add(currNode.Next.Data);
                }

                currNode = currNode.Next;
            }

            return headNode;
        }
    }
}