using System;
using System.Collections.Generic;

namespace CTCI.DataStructures
{
    /// <summary>
    /// Custom implementatioin of stack data structure, includes method for getting min value of stack
    /// </summary>
    public class MyStack
    {
        /// <summary>
        /// Class representing a node in a stack, includes pointer to the node with next smallest value if this node was ever the min
        /// </summary>
        public class StackNode
        {
            public int Data;
            public StackNode Next;
            public StackNode NextMin;

            public StackNode(int data)
            {
                Data = data;
                Next = null;
                NextMin = null;
            }
        }
        private StackNode Top;
        private StackNode Min;

        public MyStack()
        {
            Top = null;
            Min = null;
        }

        /// <summary>
        /// Returns the value for the top node on the stack
        /// O(1) time and space
        /// </summary>
        /// <returns>int</returns>
        public int Peek()
        {
            if (Top == null)
                throw new Exception("Stack is empty.");
            return Top.Data;
        }

        /// <summary>
        /// Method for removing a node off the top of the stack and returning the val. If node is also stack min, then changes min to next smallest node
        /// O(1) time and space
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            if (Top == null)
                throw new Exception ("Stack is empty.");

            StackNode poppedNode = Top;
            Top = Top.Next;

            if (poppedNode == Min)
                Min = Min.NextMin;
            
            return poppedNode.Data;
        }

        /// <summary>
        /// Method for pushing node to top of stack, also sets node as stack min if it is smaller than all the other nodes
        /// O(1) time and space
        /// </summary>
        /// <param name="data"></param>
        public void Push(int data)
        {
            StackNode pushedNode = new StackNode(data);
            pushedNode.Next = Top;
            Top = pushedNode;
            
            if (Min == null)
                Min = pushedNode;
            else if (pushedNode.Data < Min.Data)
            {
                pushedNode.NextMin = Min;
                Min = pushedNode;
            }
        }

        /// <summary>
        /// Method for checking if stack is empty
        /// O(1) time and space
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Top == null;
        }

        /// <summary>
        /// Method for getting the minimum value in the stack
        /// O(1) time and space
        /// </summary>
        /// <returns></returns>
        public int StackMin()
        {
            if (Min == null)
                throw new Exception("Stack is empty.");
            return Min.Data;
        }
    }
}