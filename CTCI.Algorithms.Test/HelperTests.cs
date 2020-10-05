using CTCI.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CTCI.Algorithms.Test
{
    [TestClass]
    public class HelperTests
    {
        [TestMethod]
        public void TestListSlice()
        {
            // Arrange
            List<int> input = new List<int>() { 1, 2, 3, 4 };
            int start = 2;
            int end = input.Count();
            int expectedLength = 2;

            // Act
            List<int> output = Helper.Slice(input, start, end);

            // Assert
            Assert.AreEqual(expectedLength, output.Count);
            Assert.AreEqual(3, output[0]);
            Assert.AreEqual(4, output[1]);
        }
    }
}