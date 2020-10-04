using CTCI.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
    }
}