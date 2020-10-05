using CTCI.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CTCI.Algorithms.Test
{
    [TestClass]
    public class TreesAndGraphsTests
    {
        [TestMethod]
        public void TestRouteExists()
        {
            // Arrange

            // null
            DirectedGraphNode nullSource = null;
            DirectedGraphNode nullDest = new DirectedGraphNode(1);

            // source == dest
            DirectedGraphNode sameSource = new DirectedGraphNode(1);
            DirectedGraphNode sameDest = sameSource;

            // common case
            DirectedGraphNode commonCaseSource = new DirectedGraphNode(1);
            DirectedGraphNode commonCase2 = new DirectedGraphNode(2);
            DirectedGraphNode commonCase3 = new DirectedGraphNode(3);
            DirectedGraphNode commonCaseDest = new DirectedGraphNode(4);
            DirectedGraphNode commonCase5 = new DirectedGraphNode(5);
            commonCaseSource.Children.Add(commonCase2);
            commonCaseSource.Children.Add(commonCase3);
            commonCase2.Children.Add(commonCase3);
            commonCase3.Children.Add(commonCaseDest);

            // Act
            bool nullResult = TreesAndGraphs.RouteExists(nullSource, nullDest);
            bool sameResult = TreesAndGraphs.RouteExists(sameSource, sameDest);
            bool commonCaseResult = TreesAndGraphs.RouteExists(commonCaseSource, commonCaseDest);
            bool commonCaseFalseResult = TreesAndGraphs.RouteExists(commonCaseSource, commonCase5);

            // Assert
            Assert.IsFalse(nullResult);
            Assert.IsTrue(sameResult);
            Assert.IsTrue(commonCaseResult);
            Assert.IsFalse(commonCaseFalseResult);
        }

        [TestMethod]
        public void TestMinimalTree()
        {
            // Arrange

            // empty list
            List<int> emptyList = new List<int>();
            List<int> nullList = null;

            // single val base case
            List<int> singleValList = new List<int>();
            singleValList.Add(1);

            // 2 values base case
            List<int> twoValueList = new List<int>();
            twoValueList.Add(1);
            twoValueList.Add(2);

            // common case
            List<int> commonCaseList1 = new List<int>();
            commonCaseList1.Add(1);
            commonCaseList1.Add(2);
            commonCaseList1.Add(3);
            commonCaseList1.Add(4);

            List<int> commonCaseList2 = new List<int>();
            commonCaseList2.Add(1);
            commonCaseList2.Add(2);
            commonCaseList2.Add(2);
            commonCaseList2.Add(3);
            commonCaseList2.Add(4);

            // Act
            BSTNode emptyListResult = TreesAndGraphs.MinimalTree(emptyList);
            BSTNode nullListResult = TreesAndGraphs.MinimalTree(nullList);

            BSTNode singleValResult = TreesAndGraphs.MinimalTree(singleValList);
            BSTNode twoValueResult = TreesAndGraphs.MinimalTree(twoValueList);

            BSTNode commonCaseList1Result = TreesAndGraphs.MinimalTree(commonCaseList1);
            BSTNode commonCaseList2Result = TreesAndGraphs.MinimalTree(commonCaseList2);

            // Assert
            Assert.IsNull(emptyListResult);
            Assert.IsNull(nullListResult);
            Assert.AreEqual(1, singleValResult.Data);
            Assert.IsNull(singleValResult.Left);
            Assert.IsNull(singleValResult.Right);
            Assert.AreEqual(2, twoValueResult.Data);
            Assert.AreEqual(1, twoValueResult.Left.Data);
            Assert.IsNull(twoValueResult.Right);
            Assert.AreEqual(3, commonCaseList1Result.Data);
            Assert.AreEqual(2, commonCaseList1Result.Left.Data);
            Assert.AreEqual(1, commonCaseList1Result.Left.Left.Data);
            Assert.IsNull(commonCaseList1Result.Left.Left.Right);
            Assert.IsNull(commonCaseList1Result.Left.Left.Left);
            Assert.IsNull(commonCaseList1Result.Left.Right);
            Assert.AreEqual(4, commonCaseList1Result.Right.Data);
            Assert.IsNull(commonCaseList1Result.Right.Left);
            Assert.IsNull(commonCaseList1Result.Right.Right);
            Assert.AreEqual(2, commonCaseList2Result.Data);
            Assert.AreEqual(2, commonCaseList2Result.Left.Data);
            Assert.AreEqual(1, commonCaseList2Result.Left.Left.Data);
            Assert.IsNull(commonCaseList2Result.Left.Right);
            Assert.IsNull(commonCaseList2Result.Left.Left.Left);
            Assert.IsNull(commonCaseList2Result.Left.Left.Right);
            Assert.AreEqual(4, commonCaseList2Result.Right.Data);
            Assert.AreEqual(3, commonCaseList2Result.Right.Left.Data);
            Assert.IsNull(commonCaseList2Result.Right.Right);
            Assert.IsNull(commonCaseList2Result.Right.Left.Left);
            Assert.IsNull(commonCaseList2Result.Right.Left.Right);
        }
    }
}