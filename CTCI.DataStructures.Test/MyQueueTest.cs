using CTCI.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CTCI.DataStructures.Test
{
    [TestClass]
    public class MyQueueTest
    {
        [TestMethod]
        public void TestAddPeekAndRemoveAndIsEmpty()
        {
            // Arrange
            MyQueue queue = new MyQueue();
            MyQueue emptyQueue = new MyQueue();

            // Act
            queue.Add(1);
            queue.Add(2);
            queue.Add(3);

            // Assert
            Assert.AreEqual(1, queue.Peek());
            Assert.IsFalse(queue.IsEmpty());
            Assert.AreEqual(1, queue.Remove());
            Assert.AreEqual(2, queue.Peek());
            Assert.IsTrue(emptyQueue.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPeekException()
        {
            // Arrange
            MyQueue queue = new MyQueue();

            // Act
            queue.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRemoveException()
        {
            // Arrange
            MyQueue queue = new MyQueue();

            // Act
            queue.Remove();
        }
    }
}