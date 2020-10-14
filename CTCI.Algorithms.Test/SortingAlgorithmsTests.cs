using CTCI.Algorithms;
using CTCI.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CTCI.Algorithms.Test
{
    [TestClass]
    public class SortingAlgorithmsTests
    {
        [TestMethod]
        public void TestMergeSort()
        {
            // Arrange
            int[] arr = new int[] { 4, 10, 2, 1, 8, 9, 5, 7, 6, 3 };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            SortingAlgorithms.MergeSort(arr);

            // Assert
            CollectionAssert.AreEqual(expected, arr);
        }

        [TestMethod]
        public void TestBubbleSort()
        {
            // Arrange
            int[] arr = new int[] { 4, 10, 2, 1, 8, 9, 5, 7, 6, 3 };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            SortingAlgorithms.BubbleSort(arr);

            // Assert
            CollectionAssert.AreEqual(expected, arr);
        }

        [TestMethod]
        public void TestSelectionSort()
        {
            // Arrange
            int[] arr = new int[] { 4, 10, 2, 1, 8, 9, 5, 7, 6, 3 };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            SortingAlgorithms.SelectionSort(arr);
            foreach (int i in arr)
                Console.WriteLine(i);

            // Assert
            CollectionAssert.AreEqual(expected, arr);
        }
    }
}