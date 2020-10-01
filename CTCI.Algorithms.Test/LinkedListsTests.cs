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

        [TestMethod]
        public void TestReturnKthToLast()
        {
            // Arrange

            // Null head
            SLLNode nullHead = null;
            int kNull = 0;

            // Single node
            SLLNode singleNodeHead = new SLLNode(1);
            int kSingleNode = 1;
            int expectedSingleNodeVal = 1;

            // Multiple nodes
            SLLNode multiNodeHead = new SLLNode(1);
            multiNodeHead.AddToTail(2);
            multiNodeHead.AddToTail(3);
            multiNodeHead.AddToTail(4);
            int kMultiNode = 2;
            int expectedMultiNodeVal = 3;

            // Act
            SLLNode nullHeadResult = LinkedLists.ReturnKthToLast(nullHead, kNull);
            SLLNode singleNodeResult = LinkedLists.ReturnKthToLast(singleNodeHead, kSingleNode);
            int actualSingleNodeVal = singleNodeResult.Data;
            SLLNode multiNodeResult = LinkedLists.ReturnKthToLast(multiNodeHead, kMultiNode);
            int actualMultiNodeVal = multiNodeResult.Data;

            // Assert
            Assert.IsNull(nullHeadResult);
            Assert.AreEqual(expectedSingleNodeVal, actualSingleNodeVal);
            Assert.AreEqual(expectedMultiNodeVal, actualMultiNodeVal);
        }

        [TestMethod]
        public void TestDeleteMiddleNode()
        {
            // Arrange
            SLLNode head = new SLLNode(1);
            SLLNode second = new SLLNode(2);
            SLLNode third = new SLLNode(3);
            SLLNode fourth = new SLLNode(4);
            head.Next = second;
            second.Next = third;
            third.Next = fourth;

            // Act
            LinkedLists.DeleteMiddleNode(second);

            // Assert
            Assert.AreEqual(head.Next.Data, 3);
            Assert.AreEqual(second.Next.Data, 4);
            Assert.IsNull(third.Next);
        }

        [TestMethod]
        public void TestPartition()
        {
            // Arrange

            // Null head
            SLLNode nullHead = null;
            int xNullHead = 3;

            // Single node
            SLLNode singleNode = new SLLNode(3);
            int xSingleNode = 2;

            // All smaller
            SLLNode allSmallerNode = new SLLNode(2);
            allSmallerNode.AddToTail(1);
            allSmallerNode.AddToTail(0);
            int xAllSmallerNode = 3;

            // Common case
            SLLNode commonCaseNode = new SLLNode(8);
            commonCaseNode.AddToTail(3);
            commonCaseNode.AddToTail(2);
            commonCaseNode.AddToTail(7);
            int xCommonCaseNode = 7;

            // Act
            SLLNode nullHeadResult = LinkedLists.Partition(nullHead, xNullHead);
            SLLNode singleNodeResult = LinkedLists.Partition(singleNode, xSingleNode);
            SLLNode allSmallerNodeResult = LinkedLists.Partition(allSmallerNode, xAllSmallerNode);
            SLLNode commonCaseNodeResult = LinkedLists.Partition(commonCaseNode, xCommonCaseNode);

            // Assert
            Assert.IsNull(nullHeadResult);
            Assert.AreEqual(singleNodeResult.Data, 3);
            Assert.IsNull(singleNodeResult.Next);
            Assert.AreEqual(allSmallerNodeResult.Data, 2);
            Assert.AreEqual(allSmallerNodeResult.Next.Data, 1);
            Assert.AreEqual(allSmallerNodeResult.Next.Next.Data, 0);
            Assert.IsNull(allSmallerNodeResult.Next.Next.Next);
            Assert.AreEqual(commonCaseNodeResult.Data, 3);
            Assert.AreEqual(commonCaseNodeResult.Next.Data, 2);
            Assert.AreEqual(commonCaseNodeResult.Next.Next.Data, 8);
            Assert.AreEqual(commonCaseNodeResult.Next.Next.Next.Data, 7);
            Assert.IsNull(commonCaseNodeResult.Next.Next.Next.Next);
        }

        [TestMethod]
        public void TestSumLists()
        {
            // Arrange

            // Both null
            SLLNode nullNode1 = null;
            SLLNode nullNode2 = null;

            // head1 null
            SLLNode nullHead1 = null;
            SLLNode nonNullHead2 = new SLLNode(1);

            // head2 null
            SLLNode nonNullHead1 = new SLLNode(2);
            SLLNode nullHead2 = null;

            // common case
            SLLNode commonCaseHead1 = new SLLNode(1);
            commonCaseHead1.AddToTail(0);
            commonCaseHead1.AddToTail(9);
            SLLNode commonCaseHead2 = new SLLNode(3);
            commonCaseHead2.AddToTail(2);

            // Act
            SLLNode bothNullResult = LinkedLists.SumLists(nullNode1, nullNode2);
            SLLNode nullHead1Result = LinkedLists.SumLists(nullHead1, nonNullHead2);
            SLLNode nullHead2Result = LinkedLists.SumLists(nonNullHead1, nullHead2);
            SLLNode commonCaseResult = LinkedLists.SumLists(commonCaseHead1, commonCaseHead2);

            // Assert
            Assert.IsNull(bothNullResult);
            Assert.AreEqual(nullHead1Result.Data, 1);
            Assert.AreEqual(nullHead2Result.Data, 2);
            Assert.AreEqual(commonCaseResult.Data, 4);
            Assert.AreEqual(commonCaseResult.Next.Data, 2);
            Assert.AreEqual(commonCaseResult.Next.Next.Data, 9);
        }

        [TestMethod]
        public void TestIsPalindrome()
        {
            // Arrange

            // null head
            SLLNode nullHead = null;

            // single node
            SLLNode singleNode = new SLLNode(1);

            // not a palindrome
            SLLNode notAPalindrome = new SLLNode(1);
            notAPalindrome.AddToTail(2);

            // is a palindrome
            SLLNode isAPalindrome = new SLLNode(1);
            isAPalindrome.AddToTail(1);
            isAPalindrome.AddToTail(1);
            isAPalindrome.AddToTail(2);
            isAPalindrome.AddToTail(2);
            isAPalindrome.AddToTail(1);
            isAPalindrome.AddToTail(1);
            isAPalindrome.AddToTail(1);

            // Act
            bool nullHeadResult = LinkedLists.IsPalindrome(nullHead);
            bool singleNodeResult = LinkedLists.IsPalindrome(singleNode);
            bool notAPalindromeResult = LinkedLists.IsPalindrome(notAPalindrome);
            bool isAPalindromeResult = LinkedLists.IsPalindrome(isAPalindrome);

            // Assert
            Assert.IsFalse(nullHeadResult);
            Assert.IsTrue(singleNodeResult);
            Assert.IsFalse(notAPalindromeResult);
            Assert.IsTrue(isAPalindromeResult);
        }

        [TestMethod]
        public void TestIntersection()
        {
            // Arrange

            // either null
            SLLNode nullHead1 = null;
            SLLNode nullHead2 = new SLLNode(1);

            // first
            SLLNode firstHead1 = new SLLNode(99);
            SLLNode firstHead2 = firstHead1;

            // common case intersection
            SLLNode commonCase1 = new SLLNode(2);
            SLLNode commonCaseNext1 = new SLLNode(3);
            commonCase1.Next = commonCaseNext1;
            SLLNode commonCaseNextNext1 = new SLLNode(4);
            commonCaseNext1.Next = commonCaseNextNext1;
            SLLNode commonCaseNextNextNext1 = new SLLNode(5);
            commonCaseNextNext1 = commonCaseNextNextNext1;
            SLLNode commonCase2 = new SLLNode(10);
            SLLNode commonCaseNext2 = new SLLNode(11);
            commonCase2.Next = commonCaseNext2;
            commonCaseNext2.Next = commonCaseNextNext1;

            // no intersection
            SLLNode noIntersectionHead1 = new SLLNode(30);
            SLLNode noIntersectionHead2 = new SLLNode(40);
            noIntersectionHead1.AddToTail(53);
            noIntersectionHead2.AddToTail(64);

            // Act
            SLLNode nullHeadResult = LinkedLists.Instersection(nullHead1, nullHead2);
            SLLNode firstHeadResult = LinkedLists.Instersection(firstHead1, firstHead2);
            SLLNode commonCaseResult = LinkedLists.Instersection(commonCase1, commonCase2);
            SLLNode noIntersectionResult = LinkedLists.Instersection(noIntersectionHead1, noIntersectionHead2);

            // Assert
            Assert.IsNull(nullHeadResult);
            Assert.AreEqual(firstHeadResult, firstHead1);
            Assert.ReferenceEquals(commonCaseResult, commonCaseNextNext1);
            Assert.IsNull(noIntersectionResult);
        }

        [TestMethod]
        public void TestLoopDetection()
        {
            // Arrange
            
            // null head
            SLLNode nullHead = null;

            // single node
            SLLNode singleNode = new SLLNode(1);

            // common case
            SLLNode commonCaseHead = new SLLNode(1);
            SLLNode second = new SLLNode(2);
            commonCaseHead.Next = second;
            SLLNode third = new SLLNode(3);
            second.Next = third;
            SLLNode fourth = new SLLNode(4);
            third.Next = fourth;
            SLLNode fifth = new SLLNode(5);
            fourth.Next = fifth;
            SLLNode sixth = new SLLNode(6);
            fifth.Next = sixth;
            sixth.Next = third;

            // Act
            SLLNode nullHeadResult = LinkedLists.LoopDetection(nullHead);
            SLLNode singleNodeResult = LinkedLists.LoopDetection(singleNode);
            SLLNode commonCaseResult = LinkedLists.LoopDetection(commonCaseHead);

            // Assert
            Assert.IsNull(nullHeadResult);
            Assert.IsNull(singleNodeResult);
            Assert.AreEqual(third, commonCaseResult);

        }
    }
}