using CTCI.Algorithms;
using CTCI.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CTCI.Algorithms.Test
{
    [TestClass]
    public class LinkedListsTests
    {
        [TestMethod]
        public void TestDeleteNode() 
        {
            // Arrange
            SLLNode nullNode = null;

            SLLNode headNodeToDelete = new SLLNode(1);
            headNodeToDelete.AddToTail(2);
            int expectedNewHeadNodeVal = 2;

            SLLNode commonCaseHeadNode = new SLLNode(1);
            commonCaseHeadNode.AddToTail(2);
            commonCaseHeadNode.AddToTail(3);
            int expectedNewSecondNodeVal = 3;

            // Act
            SLLNode nullNodeResult = LinkedLists.DeleteNode(nullNode, 1);

            SLLNode deletedHeadNodeResult = LinkedLists.DeleteNode(headNodeToDelete, 1);
            int actualNewHeadNodeVal = deletedHeadNodeResult.Data;

            SLLNode commonCaseResult = LinkedLists.DeleteNode(commonCaseHeadNode, 2);
            int actualNewSecondNodeVal = commonCaseResult.Next.Data;

            // Assert
            Assert.IsNull(nullNodeResult);
            Assert.AreEqual(expectedNewHeadNodeVal, actualNewHeadNodeVal);
            Assert.AreEqual(expectedNewSecondNodeVal, actualNewSecondNodeVal);
        }
    }
}