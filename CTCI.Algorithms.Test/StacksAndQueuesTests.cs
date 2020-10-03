using CTCI.Algorithms;
using CTCI.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CTCI.Algorithms.Test
{
    [TestClass]
    public class StacksAndQueuesTests
    {
        [TestMethod]
        public void TestSortStack()
        {
            // Arrange

            // null stack
            Stack<int> nullStack = null;

            // empty stack
            Stack<int> emptyStack = new Stack<int>();

            // single item stack
            Stack<int> singleItemStack = new Stack<int>();
            singleItemStack.Push(1);

            // common case
            Stack<int> commonCaseStack = new Stack<int>();
            commonCaseStack.Push(4);
            commonCaseStack.Push(2);
            commonCaseStack.Push(12);
            commonCaseStack.Push(8);
            commonCaseStack.Push(89);
            commonCaseStack.Push(1000);
            commonCaseStack.Push(3);
            commonCaseStack.Push(67);

            // Act
            Stack<int> nullStackResult = StacksAndQueues.SortStack(nullStack);
            Stack<int> emptyStackResult = StacksAndQueues.SortStack(emptyStack);
            Stack<int> singleItemResult = StacksAndQueues.SortStack(singleItemStack);
            Stack<int> commonCaseResult = StacksAndQueues.SortStack(commonCaseStack);

            // Assert
            Assert.IsNull(nullStackResult);
            Assert.AreEqual(0, emptyStackResult.Count);
            Assert.AreEqual(2, commonCaseResult.Pop());
            Assert.AreEqual(3, commonCaseResult.Pop());
            Assert.AreEqual(4, commonCaseResult.Pop());
            Assert.AreEqual(8, commonCaseResult.Pop());
            Assert.AreEqual(12, commonCaseResult.Pop());
            Assert.AreEqual(67, commonCaseResult.Pop());
            Assert.AreEqual(89, commonCaseResult.Pop());
            Assert.AreEqual(1000, commonCaseResult.Pop());
        }
    }
}