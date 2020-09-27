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

        /// <summary>
        /// Given a SLL Node, return the kth to last node. Tail is k == 1
        /// O(n) time complexity, O(1) space complexity
        /// </summary>
        /// <param name="head">SLLNode</param>
        /// <param name="k">int</param>
        /// <returns>SLLNode</returns>
        public static SLLNode ReturnKthToLast(SLLNode head, int k)
        {
            if (head == null)
                return null;
            
            int count = 1;
            SLLNode pointer = head;
            while (pointer.Next != null)
            {
                pointer = pointer.Next;
                count ++;
            }
            pointer = head;
            int numMoves = count - k;
            while (numMoves > 0)
            {
                pointer = pointer.Next;
                numMoves --;
            }

            return pointer;
        }

        /// <summary>
        /// Given SLLNode (not head or tail or null), delete it from the list it is in
        /// O(n) time, O(1) space
        /// </summary>
        /// <param name="node">SLLNoid</param>
        /// <returns>void</returns>
        public static void DeleteMiddleNode(SLLNode node)
        {
            SLLNode p1 = node;
            SLLNode p2 = node.Next;
            SLLNode p3 = node.Next.Next;

            while (true)
            {
                p1.Data = p2.Data;
                if (p3 == null)
                {
                    p1.Next = p3;
                    break;
                }
                p1 = p1.Next;
                p2 = p2.Next;
                p3 = p3.Next;
            }

            return;
        }

        /// <summary>
        /// Given SLLNode and integer, partitions list by x (does not reorder list ascending)
        /// O(n) time, O(n) space
        /// </summary>
        /// <param name="head">SLLNode</param>
        /// <param name="x">int</param>
        /// <returns></returns>
        public static SLLNode Partition(SLLNode head, int x)
        {
            if (head == null)
                return head;
            
            SLLNode smaller = null;
            SLLNode larger = null;
            SLLNode p1 = null;
            SLLNode p2 = null;
            SLLNode currNode = head;
            while (currNode != null)
            {
                if (currNode.Data < x)
                {
                    if (smaller == null)
                    {
                        smaller = currNode;
                        p1 = smaller;
                    }
                    else
                    {
                        p1.Next = currNode;
                        p1 = p1.Next;
                    }
                }
                else
                {
                    if (larger == null)
                    {
                        larger = currNode;
                        p2 = larger;
                    }
                    else
                    {
                        p2.Next = currNode;
                        p2 = p2.Next;
                    }
                }
                currNode = currNode.Next;
            }

            if (smaller == null)
                return larger;
            
            p1.Next = larger;
            return smaller;
        }
    }
}