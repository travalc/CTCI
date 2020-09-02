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

        [TestMethod]
        public void TestRemoveDups()
        {
            // Arrange
            
            // Null head
            SLLNode nullHead = null;

            // Single node
            SLLNode singleNode = new SLLNode(1);
            int singleNodeExpected = 1;

            // No dupes
            SLLNode noDupesNode = new SLLNode(2);
            noDupesNode.AddToTail(2);
            noDupesNode.AddToTail(3);

            // One dupe
            SLLNode oneDupeNode = new SLLNode(1);
            oneDupeNode.AddToTail(2);
            oneDupeNode.AddToTail(2);
            oneDupeNode.AddToTail(3);

            // Multiple dupes
            SLLNode multipleDupesNode = new SLLNode(1);
            multipleDupesNode.AddToTail(1);
            multipleDupesNode.AddToTail(1);
            multipleDupesNode.AddToTail(1);

            // Act
            SLLNode nullHeadResult = LinkedLists.RemoveDups(nullHead);
            SLLNode singleNodeResult = LinkedLists.RemoveDups(singleNode);
            SLLNode noDupesResult = LinkedLists.RemoveDups(noDupesNode);
            SLLNode oneDupeNodeResult = LinkedLists.RemoveDups(oneDupeNode);
            SLLNode multipleDupesNodeResult = LinkedLists.RemoveDups(multipleDupesNode);

            // Assert
            Assert.IsNull(nullHeadResult);
            Assert.AreEqual(singleNodeExpected, singleNodeResult.Data);
            Assert.IsNull(singleNodeResult.Next);

            Assert.AreEqual(3, oneDupeNodeResult.Next.Next.Data);
            Assert.IsNull(multipleDupesNodeResult.Next);
        }
    }
}