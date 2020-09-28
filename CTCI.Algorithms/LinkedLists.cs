using CTCI.DataStructures;
using System;
using System.Collections;
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

        /// <summary>
        /// Given 2 linked lists representing numbers, ones digit comes first, return linked list representing the sum
        /// O(n) time, O(n) space
        /// </summary>
        /// <param name="head1">SLLNode</param>
        /// <param name="head2">SLLNode</param>
        /// <returns>SLLNode</returns>
        public static SLLNode SumLists(SLLNode head1, SLLNode head2)
        {
            if (head1 == null && head2 == null)
                return null;
            if (head1 == null)
                return head2;
            if (head2 == null)
                return head1;
            
            int num1 = 0, num2 = 0, multiplier = 1, sum;
            SLLNode currNode = head1;
            while (currNode != null)
            {
                int numToAdd = multiplier * currNode.Data;
                num1 += numToAdd;
                multiplier *= 10;
                currNode = currNode.Next;
            }
            multiplier = 1;
            currNode = head2;
            while (currNode != null)
            {
                int numToAdd = multiplier * currNode.Data;
                num2 += numToAdd;
                multiplier *= 10;
                currNode = currNode.Next;
            }

            sum = num1 + num2;
            SLLNode sumListHead = null;
            while (sum > 0)
            {
                int digit = sum % 10;
                if (sumListHead == null)
                    sumListHead = new SLLNode(digit);
                else
                    sumListHead.AddToTail(digit);
                sum /= 10;
            }

            return sumListHead;
        }

        /// <summary>
        /// Given SLL head node, determines if values form a palindrome
        /// O(n) time, O(n) space
        /// </summary>
        /// <param name="head">SLLNode</param>
        /// <returns>bool</returns>
        public static bool IsPalindrome(SLLNode head)
        {
            if (head == null)
                return false;
            if (head.Next == null)
                return true;

            Stack numStack = new Stack();
            SLLNode p1 = head;
            SLLNode p2 = head.Next;
            while (true)
            {
                numStack.Push(p1.Data);
                if (p2.Next != null && p2.Next.Next != null)
                {
                    p1 = p1.Next;
                    p2 = p2.Next.Next;
                }
                else
                    break;
            }
            
            if (p2.Next != null)
                p1 = p1.Next.Next;
            else
                p1 = p1.Next;
            while (p1 != null)
            {
                int valToCompare = (int)numStack.Pop();
                if (p1.Data != valToCompare)
                    return false;
                p1 = p1.Next;
            }

            return true;
        }
    }
}