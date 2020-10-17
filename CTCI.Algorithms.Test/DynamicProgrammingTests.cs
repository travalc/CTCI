using CTCI.Algorithms;
using CTCI.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CTCI.Algorithms.Test
{
    [TestClass]
    public class DynamicProgrammingTests
    {
        [TestMethod]
        public void TestTripleStep()
        {
            // Arrange
            int n = 5;

            // Act
            int result = DynamicProgramming.TripleStep(n);
            int bottomUpResult = DynamicProgramming.TripleStepBottomUp(n);

            // Assert
            Assert.AreEqual(11, result);
            Assert.AreEqual(11, bottomUpResult);
        }
    }
}