using CTCI.DataStructures;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CTCI.Algorithms
{
    public static class StacksAndQueues
    {
        /// <summary>
        /// Returns sorted version of stack, smallest on top
        /// O(n) time and space
        /// </summary>
        /// <param name="stack">Stack<int></param>
        /// <returns>Stack<int></returns>
        public static Stack<int> SortStack(Stack<int> stack)
        {
            if (stack == null)
                return null;
            if (stack.Count <= 1)
                return stack;
            
            Stack<int> sortedStack = new Stack<int>();
            while (stack.Count > 0)
            {
                int curr = stack.Pop();
                while (sortedStack.Count > 0 && sortedStack.Peek() < curr)
                    stack.Push(sortedStack.Pop());
                sortedStack.Push(curr);
            }

            return sortedStack;
        }
    }
}