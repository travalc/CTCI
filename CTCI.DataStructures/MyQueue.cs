using System;
using System.Collections;

namespace CTCI.DataStructures
{
    /// <summary>
    /// Queue class implemented using 2 stacks
    /// </summary>
    public class MyQueue
    {
        private Stack AddStack;
        private Stack RemoveStack;

        public MyQueue()
        {
            AddStack = new Stack();
            RemoveStack = new Stack();
        }

        /// <summary>
        /// Adds item to back of queue
        /// O(n) time O(1) space
        /// </summary>
        /// <param name="data">int</param>
        public void Add(int data)
        {
            if (RemoveStack.Count == 0)
            {
                RemoveStack.Push(data);
                return;
            }
            
            while (RemoveStack.Count > 0)
            {
                AddStack.Push(RemoveStack.Pop());
            }
            AddStack.Push(data);

            while (AddStack.Count > 0)
            {
                RemoveStack.Push(AddStack.Pop());
            }
        }

        /// <summary>
        /// Removes and returns value of item at front of queue
        /// O(1) time and space
        /// </summary>
        /// <returns>int</returns>
        public int Remove()
        {
            if (RemoveStack.Count == 0)
                throw new Exception("Queue is empty.");
            
            return (int)RemoveStack.Pop();
        }

        /// <summary>
        /// Returns value of item at front of queue
        /// O(1) time and space
        /// </summary>
        /// <returns>int</returns>
        public int Peek()
        {
            if (RemoveStack.Count == 0)
                throw new Exception("Queue is empty.");

            return (int)RemoveStack.Peek();
        }

        /// <summary>
        /// Returns bool indicating if queue is empty
        /// O(1) time and space
        /// </summary>
        /// <returns>bool</returns>
        public bool IsEmpty()
        {
            return RemoveStack.Count == 0;
        }
    }
}