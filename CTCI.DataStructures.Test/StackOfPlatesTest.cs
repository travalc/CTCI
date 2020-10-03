using CTCI.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace CTCI.DataStructures.Test
{
    [TestClass]
    public class StackOfPlatesTest
    {
        [TestMethod]
        public void TestPushAndPop()
        {
            // Arrange
            StackOfPlates stack = new StackOfPlates(4);

            // Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);
            stack.Push(10);
            stack.Push(11);
            stack.Push(12);
            stack.Push(13);
            stack.Push(14);
            stack.Push(15);
            stack.Push(16);

            // Assert
            Assert.AreEqual(stack.Pop(), 16);
            Assert.AreEqual(stack.Pop(), 15);
            Assert.AreEqual(stack.Pop(), 14);
            Assert.AreEqual(stack.Pop(), 13);
            Assert.AreEqual(stack.Pop(), 12);
            Assert.AreEqual(stack.Pop(), 11);
            Assert.AreEqual(stack.Pop(), 10);
            Assert.AreEqual(stack.Pop(), 9);
            Assert.AreEqual(stack.Pop(), 8);
            Assert.AreEqual(stack.Pop(), 7);
            Assert.AreEqual(stack.Pop(), 6);
            Assert.AreEqual(stack.Pop(), 5);
            Assert.AreEqual(stack.Pop(), 4);
            Assert.AreEqual(stack.Pop(), 3);
            Assert.AreEqual(stack.Pop(), 2);
            Assert.AreEqual(stack.Pop(), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPushException()
        {
            // Arrange
            StackOfPlates stack = new StackOfPlates(2);

            // Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPopException()
        {
            // Arrange
            StackOfPlates stack = new StackOfPlates(2);

            // Act
            stack.Pop();
        }
    }
}