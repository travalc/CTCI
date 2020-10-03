using System;
using System.Collections.Generic;

namespace CTCI.DataStructures
{
    /// <summary>
    /// Stack data structure implemented using 4 different stacks. Size of individual stacks determined upon instantiation
    /// </summary>
    public class StackOfPlates
    {
        public class StackOfPlatesNode
        {
            public int Data;
            public int Size;
            public StackOfPlatesNode Next;

            public StackOfPlatesNode(int data)
            {
                Data = data;
                Next = null;
            }
        }

        private StackOfPlatesNode[] Stacks;
        private int SizeThreshold;

        public StackOfPlates(int sizeThreshold)
        {
            SizeThreshold = sizeThreshold;
            Stacks = new StackOfPlatesNode[] { null, null, null, null };
        }

        /// <summary>
        /// Returns top value from stack
        /// O(1) time and space
        /// </summary>
        /// <returns>int</returns>
        public int Pop()
        {
            StackOfPlatesNode poppedNode;
            for (int i = 0; i < Stacks.Length; i++)
            {
                if (TryPopFromStack(ref Stacks[i], out poppedNode))
                    return poppedNode.Data;
            }
            throw new Exception("Stack is empty.");
        }

        /// <summary>
        /// Helper method that takes an individual stack and tries to get the popped node, returns true upon success and assigns poppedNode, false on failure
        /// </summary>
        /// <param name="stack">StackOfPlatesNode</param>
        /// <param name="poppedNode">StackOfPlatesNode</param>
        /// <returns>bool</returns>
        public bool TryPopFromStack(ref StackOfPlatesNode stack, out StackOfPlatesNode poppedNode)
        {
            if (stack == null)
            {
                poppedNode = null;
                return false;
            }
            
            poppedNode = stack;
            stack = stack.Next;
            return true;
        }

        /// <summary>
        /// Adds new value to top of stack
        /// </summary>
        /// <param name="data">int</param>
        public void Push(int data)
        {
            StackOfPlatesNode pushedNode = new StackOfPlatesNode(data);
            for (int i = Stacks.Length - 1; i >= 0; i--)
            {
                if (TryPushToStack(pushedNode, ref Stacks[i]))
                    return;
            }
            throw new Exception("Stack has exceeded size capacity");
        }

        /// <summary>
        /// Helper method for adding value to top of stack. If individual stack is full, returns false. Returns true on success
        /// </summary>
        /// <param name="pushedNode">StackOfPlatesNode</param>
        /// <param name="stack">StackOfPlatesNode</param>
        /// <returns>bool</returns>
        private bool TryPushToStack(StackOfPlatesNode pushedNode, ref StackOfPlatesNode stack)
        {
            if (stack == null)
            {
                pushedNode.Size = 1;
                stack = pushedNode;
                return true;
            }
            else if (stack.Size < SizeThreshold)
            {
                stack = PushToIndividualStack(pushedNode, stack);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Helper method for pushing to stack. Gets the previous size of the stack and increments by one, assigning size to pushed node.
        /// </summary>
        /// <param name="pushedNode">StackOfPlatesNode</param>
        /// <param name="stack">StackOfPlatesNode</param>
        /// <returns>StackOfPlatesNode</returns>
        private StackOfPlatesNode PushToIndividualStack(StackOfPlatesNode pushedNode, StackOfPlatesNode stack)
        {
            int stackSize = stack.Size;
            pushedNode.Size = stackSize + 1;
            pushedNode.Next = stack;

            return pushedNode;
        }
    }
}