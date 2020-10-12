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

        [TestMethod]
        public void TestListOfDepths()
        {
            // Arrange
            
            // null case
            BTNode<int> nullNode = null;

            // common case
            BTNode<int> commonCaseRoot = new BTNode<int>(3);
            BTNode<int> firstLevelLeft = new BTNode<int>(1);
            BTNode<int> firstLevelRight = new BTNode<int>(8);
            commonCaseRoot.Left = firstLevelLeft;
            commonCaseRoot.Right = firstLevelRight;
            BTNode<int> secondLevelLeftLeft = new BTNode<int>(0);
            BTNode<int> secondLevelLeftRight = new BTNode<int>(2);
            firstLevelLeft.Left = secondLevelLeftLeft;
            firstLevelLeft.Right = secondLevelLeftRight;
            BTNode<int> secondLevelRightLeft = new BTNode<int>(7);
            BTNode<int> secondLevelRightRight = new BTNode<int>(9);
            firstLevelRight.Left = secondLevelRightLeft;
            firstLevelRight.Right = secondLevelRightRight;

            // Act
            List<SLLNode> nullNodeResult = TreesAndGraphs.ListOfDepths(nullNode);
            List<SLLNode> commonCaseResult = TreesAndGraphs.ListOfDepths(commonCaseRoot);

            // Assert
            Assert.IsNull(nullNodeResult);
            Assert.AreEqual(3, commonCaseResult.Count);
            Assert.AreEqual(3, commonCaseResult[0].Data);
            Assert.IsNull(commonCaseResult[0].Next);
            Assert.AreEqual(1, commonCaseResult[1].Data);
            Assert.AreEqual(8, commonCaseResult[1].Next.Data);
            Assert.IsNull(commonCaseResult[1].Next.Next);
            Assert.AreEqual(0, commonCaseResult[2].Data);
            Assert.AreEqual(2, commonCaseResult[2].Next.Data);
            Assert.AreEqual(7, commonCaseResult[2].Next.Next.Data);
            Assert.AreEqual(9, commonCaseResult[2].Next.Next.Next.Data);
            Assert.IsNull(commonCaseResult[2].Next.Next.Next.Next);
        }

        [TestMethod]
        public void TestCheckBalanced()
        {
            // Arrange

            // null case
            BTNode<int> nullRoot = null;

            // single node case
            BTNode<int> singleNode = new BTNode<int>(1);

            // common case true
            BTNode<int> trueRoot = new BTNode<int>(1);
            trueRoot.Left = new BTNode<int>(2);
            trueRoot.Left.Left = new BTNode<int>(4);
            trueRoot.Right = new BTNode<int>(3);

            // common case false
            BTNode<int> falseRoot = new BTNode<int>(1);
            falseRoot.Left = new BTNode<int>(2);
            falseRoot.Right = new BTNode<int>(3);
            falseRoot.Left.Right = new BTNode<int>(4);
            falseRoot.Left.Right.Left = new BTNode<int>(5);

            // Act
            bool nullRootResult = TreesAndGraphs.CheckBalanced(nullRoot);
            bool singleNodeResult = TreesAndGraphs.CheckBalanced(singleNode);
            bool commonCaseTrueResult = TreesAndGraphs.CheckBalanced(trueRoot);
            bool commonCaseFalseResult = TreesAndGraphs.CheckBalanced(falseRoot);

            // Assert
            Assert.IsFalse(nullRootResult);
            Assert.IsTrue(singleNodeResult);
            Assert.IsTrue(commonCaseTrueResult);
            Assert.IsFalse(commonCaseFalseResult);
        }

        [TestMethod]
        public void TestValidateBST()
        {
            // Arrange

            // null case
            BTNode<int> nullRoot = null;

            // single node
            BTNode<int> singleNode = new BTNode<int>(1);

            // common case true
            BTNode<int> commonCaseTrueRoot = new BTNode<int>(5);
            commonCaseTrueRoot.Left = new BTNode<int>(2);
            commonCaseTrueRoot.Left.Left = new BTNode<int>(1);
            commonCaseTrueRoot.Left.Right = new BTNode<int>(3);
            commonCaseTrueRoot.Right = new BTNode<int>(8);
            commonCaseTrueRoot.Right = new BTNode<int>(6);

            // common case false 1
            BTNode<int> commonCaseFalseRoot1 = new BTNode<int>(3);
            commonCaseFalseRoot1.Left = new BTNode<int>(1);
            commonCaseFalseRoot1.Left.Left = new BTNode<int>(0);
            commonCaseFalseRoot1.Left.Right = new BTNode<int>(4);
            commonCaseFalseRoot1.Right = new BTNode<int>(5);
            commonCaseFalseRoot1.Right.Left = new BTNode<int>(5);
            commonCaseFalseRoot1.Right.Right = new BTNode<int>(7);

            // common case false 2
            BTNode<int> commonCaseFalseRoot2 = new BTNode<int>(4);
            commonCaseFalseRoot2.Left = new BTNode<int>(2);
            commonCaseFalseRoot2.Right = new BTNode<int>(6);
            commonCaseFalseRoot2.Right.Left = new BTNode<int>(1);

            // Act
            bool nullRootResult = TreesAndGraphs.ValidateBST(nullRoot);
            bool singleNodeResult = TreesAndGraphs.ValidateBST(singleNode);
            bool commonCaseTrueResult = TreesAndGraphs.ValidateBST(commonCaseTrueRoot);
            bool commonCaseFalseResult1 = TreesAndGraphs.ValidateBST(commonCaseFalseRoot1);
            bool commonCaseFalseResult2 = TreesAndGraphs.ValidateBST(commonCaseFalseRoot2);

            // Assert
            Assert.IsFalse(nullRootResult);
            Assert.IsTrue(singleNodeResult);
            Assert.IsTrue(commonCaseTrueResult);
            Assert.IsFalse(commonCaseFalseResult1);
            Assert.IsFalse(commonCaseFalseResult2);
        }

        [TestMethod]
        public void TestSuccessor()
        {
            // Arrange

            // null node
            BSTPNode nullNode = null;

            // single node
            BSTPNode singleNode = new BSTPNode(1, null);

            // common case
            BSTPNode commonCaseRoot = new BSTPNode(10, null);
            BSTPNode commonCaseLeft = new BSTPNode(7, commonCaseRoot);
            BSTPNode commonCaseLeftRight = new BSTPNode(9, commonCaseLeft);
            BSTPNode commonCaseLeftRightLeft = new BSTPNode(8, commonCaseLeftRight);
            BSTPNode commonCaseRight = new BSTPNode(11, commonCaseRoot);

            commonCaseRoot.Left = commonCaseLeft;
            commonCaseRoot.Right = commonCaseRight;

            commonCaseLeft.Right = commonCaseLeftRight;
            commonCaseLeftRight.Left = commonCaseLeftRightLeft;

            // Act
            BSTPNode nullNodeResult = TreesAndGraphs.Successor(nullNode);
            BSTPNode singleNodeResult = TreesAndGraphs.Successor(singleNode);
            BSTPNode commonCaseResult1 = TreesAndGraphs.Successor(commonCaseLeft);
            BSTPNode commonCaseResult2 = TreesAndGraphs.Successor(commonCaseLeftRight);
            BSTPNode commonCaseResult3 = TreesAndGraphs.Successor(commonCaseRight);

            // Assert
            Assert.IsNull(nullNodeResult);
            Assert.IsNull(singleNodeResult);
            Assert.AreEqual(commonCaseLeftRightLeft, commonCaseResult1);
            Assert.AreEqual(commonCaseRoot, commonCaseResult2);
            Assert.IsNull(commonCaseResult3);
        }

        [TestMethod]
        public void TestBuildOrder()
        {
            // Arrange
            List<char> case1Projects = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f'};
            List<Tuple<char, char>> case1Dependencies = new List<Tuple<char, char>> { 
                new Tuple<char, char> ('a', 'd'),
                new Tuple<char, char> ('f', 'b'),
                new Tuple<char, char> ('b', 'd'),
                new Tuple<char, char> ('f', 'a'),
                new Tuple<char, char> ('d', 'c')
            };

            List<char> case2Projects = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g'};
            List<Tuple<char, char>> case2Dependencies = new List<Tuple<char, char>> { 
                new Tuple<char, char> ('a', 'd'),
                new Tuple<char, char> ('f', 'b'),
                new Tuple<char, char> ('b', 'd'),
                new Tuple<char, char> ('f', 'a'),
                new Tuple<char, char> ('d', 'c'),
                new Tuple<char, char> ('g', 'b')
            };

            // Act
            List<char> case1Result = TreesAndGraphs.BuildOrder(case1Projects, case1Dependencies);
            List<char> case2Result = TreesAndGraphs.BuildOrder(case2Projects, case2Dependencies);

            // Assert
            List<char> case1Expected = new List<char> { 'f', 'e', 'b', 'a', 'd', 'c' };
            CollectionAssert.AreEqual(case1Expected, case1Result);
            List<char> case2Expected = new List<char> { 'f', 'g', 'e', 'b', 'a', 'd', 'c' };
            CollectionAssert.AreEqual(case2Expected, case2Result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestBuildOrderException()
        {
            // Arrange
            List<char> case1Projects = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f'};
            List<Tuple<char, char>> case1Dependencies = new List<Tuple<char, char>> { 
                new Tuple<char, char> ('a', 'd'),
                new Tuple<char, char> ('f', 'b'),
                new Tuple<char, char> ('b', 'd'),
                new Tuple<char, char> ('f', 'a'),
                new Tuple<char, char> ('d', 'c'),
                new Tuple<char, char> ('c', 'a'),
            };

            // Act
            List<char> case1Result = TreesAndGraphs.BuildOrder(case1Projects, case1Dependencies);
        }

        [TestMethod]
        public void TestFirstCommonAncestor()
        {
            // Arrange

            // null case
            BTNode<int> nullRoot = null;
            BTNode<int> nullCaseA = new BTNode<int>(1);
            BTNode<int> nullCaseB = new BTNode<int>(2);

            // common cases
            BTNode<int> commonCaseRoot = new BTNode<int>(6);
            BTNode<int> commonNode4 = new BTNode<int>(4);
            BTNode<int> commonNode8 = new BTNode<int>(8);
            commonCaseRoot.Left = commonNode4;
            commonCaseRoot.Right = commonNode8;
            BTNode<int> commonNode1 = new BTNode<int>(1);
            BTNode<int> commonNode5 = new BTNode<int>(5);
            commonNode4.Left = commonNode1;
            commonNode4.Right = commonNode5;
            BTNode<int> commonNode0 = new BTNode<int>(0);
            BTNode<int> commonNode3 = new BTNode<int>(3);
            commonNode1.Left = commonNode0;
            commonNode1.Right = commonNode3;
            BTNode<int> commonNode7 = new BTNode<int>(7);
            BTNode<int> commonNode9 = new BTNode<int>(9);
            commonNode8.Left = commonNode7;
            commonNode8.Right = commonNode9;

            // Act
            BTNode<int> nullResult = TreesAndGraphs.FirstCommonAncestor(nullRoot, nullCaseA, nullCaseB);
            BTNode<int> commonCaseResult1 = TreesAndGraphs.FirstCommonAncestor(commonCaseRoot, commonNode3, commonNode5);
            BTNode<int> commonCaseResult2 = TreesAndGraphs.FirstCommonAncestor(commonCaseRoot, commonNode0, commonNode9);
            BTNode<int> commonCaseResult3 = TreesAndGraphs.FirstCommonAncestor(commonCaseRoot, commonNode9, commonNode7);

            // Assert
            Assert.IsNull(nullResult);
            Assert.AreEqual(commonNode4, commonCaseResult1);
            Assert.AreEqual(commonCaseRoot, commonCaseResult2);
            Assert.AreEqual(commonNode8, commonCaseResult3);
        }

        [TestMethod]
        public void TestCheckSubtree()
        {
            // Arrange
            BTNode<int> root1 = new BTNode<int>(8);
            root1.Right = new BTNode<int>(9);
            root1.Left = new BTNode<int>(2);
            root1.Left.Left = new BTNode<int>(1);
            root1.Left.Right = new BTNode<int>(4);
            root1.Left.Right.Left = new BTNode<int>(3);
            root1.Left.Right.Right = new BTNode<int>(6);
            root1.Left.Right.Right.Right = new BTNode<int>(7);

            BTNode<int> root2 = new BTNode<int>(2);
            root2.Left = new BTNode<int>(1);
            root2.Right = new BTNode<int>(4);
            root2.Right.Left = new BTNode<int>(3);
            root2.Right.Right = new BTNode<int>(6);

            // Act
            bool isSubtree = TreesAndGraphs.CheckSubtree(root1.Left, root2);

            // Assert
            Assert.IsTrue(isSubtree);
        }
    }
}