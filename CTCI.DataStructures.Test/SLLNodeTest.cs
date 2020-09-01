using CTCI.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CTCI.DataStructures.Test
{
    [TestClass]
    public class SLLNodeTest
    {
        [TestMethod]
        public void TestAddToTail()
        {
            // Arrange
            SLLNode headNode = new SLLNode(5);
            int expectedVal = 3;

            // Act
            headNode.AddToTail(3);

            // Assert
            SLLNode currNode = headNode;
            while (currNode.Next != null)
                currNode = currNode.Next;
            Assert.AreEqual(expectedVal, currNode.Data);
        }
    }
}
