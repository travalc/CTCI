using CTCI.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CTCI.DataStructures.Test
{
    [TestClass]
    public class MyStackTest
    {
        [TestMethod]
        public void TestPush()
        {
            // Arrange
            MyStack stack = new MyStack();

            // Act
            stack.Push(1);
            stack.Push(2);

            // Assert
            Assert.AreEqual(stack.Peek(), 2);
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            // Arrange

            // false result
            MyStack nonEmptyStack = new MyStack();
            nonEmptyStack.Push(1);

            // true result
            MyStack emptyStack = new MyStack();

            // Act
            bool nonEmptyStackResult = nonEmptyStack.IsEmpty();
            bool emptyStackResult = emptyStack.IsEmpty();

            // Assert
            Assert.IsFalse(nonEmptyStackResult);
            Assert.IsTrue(emptyStackResult);
        }

        [TestMethod]
        public void TestPop()
        {
            // Arrange
            MyStack stack = new MyStack();
            stack.Push(2);
            stack.Push(3);

            // Act
            int top = stack.Pop();

            // Assert
            Assert.AreEqual(top, 3);
            Assert.AreEqual(stack.StackMin(), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPopException()
        {
            // Arrange
            MyStack nullStack = new MyStack();

            // Act
            int nullNum = nullStack.Pop();
        }

        [TestMethod]
        public void TestPeek()
        {
            // Arrange
            MyStack stack = new MyStack();
            stack.Push(3);
            stack.Push(8);

            // Act
            int num = stack.Peek();

            // Assert
            Assert.AreEqual(num, 8);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPeekException()
        {
            // Arrange
            MyStack nullStack = new MyStack();

            // Act
            int nullNum = nullStack.Peek();
        }

        [TestMethod]
        public void TestStackMin()
        {
            // Arrange
            MyStack stack = new MyStack();
            stack.Push(3);
            stack.Push(2);
            stack.Push(4);
            stack.Push(1);

            // Act
            int expectedAs1 = stack.StackMin();
            stack.Pop();
            int expectedAs2 = stack.StackMin();
            stack.Pop();
            int expectedAs2Again = stack.StackMin();
            stack.Pop();
            int expectedAs3 = stack.StackMin();

            // Assert
            Assert.AreEqual(expectedAs1, 1);
            Assert.AreEqual(expectedAs2, 2);
            Assert.AreEqual(expectedAs2Again, 2);
            Assert.AreEqual(expectedAs3, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestStackMinException()
        {
            // Arrange
            MyStack nullStack = new MyStack();

            // Act
            int nullNum = nullStack.StackMin();
        }
    }
}