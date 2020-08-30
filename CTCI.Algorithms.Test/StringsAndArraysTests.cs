using CTCI.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CTCI.Algorithms.Test
{
    [TestClass]
    public class StringsAndArraysTests
    {
        [TestMethod]
        public void TestStringsAndArraysIsUnique()
        {
            // Arrange
            string trueString = "the";
            string falseString = "keep";
            string emptyString = "";
            string singleChar = "m";

            // Act 
            bool trueStringResult = StringsAndArrays.IsUnique(trueString);
            bool falseStringResult = StringsAndArrays.IsUnique(falseString);
            bool emptyStringResult = StringsAndArrays.IsUnique(emptyString);
            bool singleCharResult = StringsAndArrays.IsUnique(singleChar);

            // Assert
            Assert.IsTrue(trueStringResult);
            Assert.IsFalse(falseStringResult);
            Assert.IsFalse(emptyStringResult);
            Assert.IsTrue(singleCharResult);
        }

        [TestMethod]
        public void TestCheckPermutation()
        {
            // Arrange

            // empty strings
            string emptyS1 = "";
            string emptyS2 = "";

            // diff lengths
            string diffS1 = "ab";
            string diffS2 = "abc";

            // s2 char not in s1
            string s1Missing = "cat";
            string s2Missing = "rac";

            // too many of same char in s2
            string s1TooMany = "cacc";
            string s2TooMany = "cccc";
            
            // true permutation
            string s1True = "carrace";
            string s2True = "racecar";

            // Act
            bool trueEmptyStringResult = StringsAndArrays.CheckPermutation(emptyS1, emptyS2);
            bool falseDiffLengthResult = StringsAndArrays.CheckPermutation(diffS1, diffS2);
            bool falseMissingCharResult = StringsAndArrays.CheckPermutation(s1Missing, s2Missing);
            bool falseTooManyResult = StringsAndArrays.CheckPermutation(s1TooMany, s2TooMany);
            bool truePermResult = StringsAndArrays.CheckPermutation(s1True, s2True);

            // Assert
            Assert.IsTrue(trueEmptyStringResult);
            Assert.IsFalse(falseDiffLengthResult);
            Assert.IsFalse(falseMissingCharResult);
            Assert.IsFalse(falseTooManyResult);
            Assert.IsTrue(truePermResult);
        }

        [TestMethod]
        public void TestURLify()
        {
            // Arrange

            // emptyInput
            string emptyInput = "";

            // all white space
            string allWhiteSpace = "    ";

            // single non-whitespace
            string singleNonWhiteSpace = "   a   ";

            // common case
            string commonCase = " c at";

            // Act
            string emptyInputResult = StringsAndArrays.URLify(emptyInput);
            string allWhiteSpaceResult = StringsAndArrays.URLify(allWhiteSpace);
            string singleNonWhiteSpaceResult = StringsAndArrays.URLify(singleNonWhiteSpace);
            string commonCaseResult = StringsAndArrays.URLify(commonCase);

            // Assert
            string expectedEmptyInputResult = "";
            string expectedAllWhiteSpaceInputResult = "";
            string expectedSingleNonWhiteSpaceResult = "a";
            string expectedCommonCaseResult = "c%20at";
            
            Assert.AreEqual(expectedEmptyInputResult, emptyInputResult);
            Assert.AreEqual(expectedAllWhiteSpaceInputResult, allWhiteSpaceResult);
            Assert.AreEqual(expectedSingleNonWhiteSpaceResult, singleNonWhiteSpaceResult);
            Assert.AreEqual(expectedCommonCaseResult, commonCaseResult);
        }

        [TestMethod]
        public void TestIsPalindromePermutation()
        {
            // Arrange
            string emptyString = "";
            string allWhiteSpaceString = "   ";
            string singleCharString = "a";
            string isAPalindromeString = "acer rac";
            string isNotAPalindromeString = " baar";

            // Act
            bool emptyStringResult = StringsAndArrays.IsPalindromePermutation(emptyString);
            bool allWhiteSpaceStringResult = StringsAndArrays.IsPalindromePermutation(allWhiteSpaceString);
            bool singleCharStringResult = StringsAndArrays.IsPalindromePermutation(singleCharString);
            bool isAPalindromeStringResult = StringsAndArrays.IsPalindromePermutation(isAPalindromeString);
            bool isNotAPalindromeStringResult = StringsAndArrays.IsPalindromePermutation(isNotAPalindromeString);

            // Assert
            Assert.IsFalse(emptyStringResult);
            Assert.IsFalse(allWhiteSpaceStringResult);
            Assert.IsTrue(singleCharStringResult);
            Assert.IsTrue(isAPalindromeStringResult);
            Assert.IsFalse(isNotAPalindromeStringResult);
        }

        [TestMethod]
        public void TestIsOneAway()
        {
            // Arrange

            // Same strings
            string sameStringsS1 = "cat";
            string sameStringsS2 = "cat";

            // Unequal lengths but true
            string unequalTrueS1 = "stop";
            string unequalTrueS2 = "sop";

            // Unequal lengths false
            string unequalFalse1 = "star";
            string unequalFalse2 = "tat";

            // Diff is greater than 2
            string diffFalseS1 = "dogs";
            string diffFalseS2 = "do";

            // Equal lengths false
            string equalFalse1 = "gang";
            string equalFalse2 = "gilg";

            // Equal lengths true
            string equalTrue1 = "gang";
            string equalTrue2 = "gamg";

            // Act
            bool sameStringsResult = StringsAndArrays.IsOneAway(sameStringsS1, sameStringsS2);
            bool unequalLengthsTrueResult = StringsAndArrays.IsOneAway(unequalTrueS1, unequalTrueS2);
            bool uneqalLengthsFalseResult = StringsAndArrays.IsOneAway(unequalFalse1, unequalFalse2);
            bool diffGreaterThan2Result = StringsAndArrays.IsOneAway(diffFalseS1, diffFalseS2);
            bool equalLengthsFalseResult = StringsAndArrays.IsOneAway(equalFalse1, equalFalse2);
            bool equalLengthsTrueResult = StringsAndArrays.IsOneAway(equalTrue1, equalTrue2);

            // Assert
            Assert.IsTrue(sameStringsResult);
            Assert.IsTrue(unequalLengthsTrueResult);
            Assert.IsFalse(uneqalLengthsFalseResult);
            Assert.IsFalse(diffGreaterThan2Result);
            Assert.IsFalse(equalLengthsFalseResult);
            Assert.IsTrue(equalLengthsTrueResult);
        }

        [TestMethod]
        public void TestCompressString()
        {
            // Arrange
            string lessThanLength3String = "aa";
            string moreThanInputString = "aab";
            string equalToInputString = "aabb";
            string lessThanInputString = "aaabbccdd";

            // Act
            string lessThanLength3StringOutput = StringsAndArrays.CompressString(lessThanLength3String);
            string moreThanInputStringOutput = StringsAndArrays.CompressString(moreThanInputString);
            string equalToInputStringOutput = StringsAndArrays.CompressString(equalToInputString);
            string lessThanInputStringOutput = StringsAndArrays.CompressString(lessThanInputString);

            // Assert
            string lessThanLength3Expected = "aa";
            string moreThanInputStringExpected = "aab";
            string equalToInputStringExpected = "aabb";
            string lessThanInputStringExpected = "a3b2c2d2";

            Assert.AreEqual(lessThanLength3Expected, lessThanLength3StringOutput);
            Assert.AreEqual(moreThanInputStringExpected, moreThanInputStringOutput);
            Assert.AreEqual(equalToInputStringExpected, equalToInputStringOutput);
            Assert.AreEqual(lessThanInputStringExpected, lessThanInputStringOutput);
        }

        [TestMethod]
        public void TestRotateMatrix()
        {
            // Arrange
            int [,] emptyMatrix = new int[0, 0] {};
            int [,] oneDimensionalMatrix = new int[1, 1] {{5}};
            int [,] twoDimensionalMatrix = new int[2, 2] 
            {
                {1, 2},
                {3, 4}
            };
            int [,] threeDimensionalMatrix = new int[3, 3]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            int [,] fourDimensionalMatrix = new int[4,4]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
            };

            int [,] emptyMatrixExpected = new int[0,0] {};
            int [,] oneDimensionalMatrixExpected = new int[1,1] {{5}};
            int [,] twoDimensionalMatrixExpected = new int[2,2]
            {
                {3, 1},
                {4, 2}
            };
            int [,] threeDimensionalMatrixExpected = new int[3, 3]
            {
                {7, 4, 1},
                {8, 5, 2},
                {9, 6, 3}
            };
            int [,] fourDimensionalMatrixExpected = new int[4,4]
            {
                {13, 9, 5, 1},
                {14, 10, 6, 2},
                {15, 11, 7, 3},
                {16, 12, 8, 4}
            };

            // Act
            int [,] emptyMatrixActual = StringsAndArrays.RotateMatrix(emptyMatrix);
            int [,] oneDimensionalMatrixActual = StringsAndArrays.RotateMatrix(oneDimensionalMatrix);
            int [,] twoDimensionalMatrixActual = StringsAndArrays.RotateMatrix(twoDimensionalMatrix);
            int [,] threeDimensionalMatrixActual = StringsAndArrays.RotateMatrix(threeDimensionalMatrix);
            int [,] fourDimensionalMatrixActual = StringsAndArrays.RotateMatrix(fourDimensionalMatrix);

            // Assert
            CollectionAssert.AreEqual(emptyMatrixExpected, emptyMatrixActual);
            CollectionAssert.AreEqual(oneDimensionalMatrixExpected, oneDimensionalMatrixActual);
            CollectionAssert.AreEqual(twoDimensionalMatrixExpected, twoDimensionalMatrixActual);
            CollectionAssert.AreEqual(threeDimensionalMatrixExpected, threeDimensionalMatrixActual);
            CollectionAssert.AreEqual(fourDimensionalMatrixExpected, fourDimensionalMatrixActual);
        }

        [TestMethod]
        public void TestZeroMatrix()
        {
            // Arrange
            int [,] oneZeroMatrix = new int[4,4]
            {
                {13, 9, 5, 1},
                {14, 0, 6, 2},
                {15, 11, 7, 3},
                {16, 12, 8, 4}
            };

            int [,] oneZeroMatrixExpected = new int[4,4]
            {
                {13, 0, 5, 1},
                {0, 0, 0, 0},
                {15, 0, 7, 3},
                {16, 0, 8, 4}
            };

            int [,] noZeroMatrix = new int[2, 3]
            {
                {7, 4, 1},
                {8, 5, 2}
            };

            int [,] noZeroMatrixExpected = new int[2, 3]
            {
                {7, 4, 1},
                {8, 5, 2}
            };

            int [,] twoZeroMatrix = new int[3, 3]
            {
                {7, 4, 1},
                {8, 0, 2},
                {9, 6, 0}
            };

            int [,] twoZeroMatrixExpected = new int[3, 3]
            {
                {7, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };

            int [,] emptyMatrix = new int[0, 0] {};
            int [,] emptyMatrixExpected = new int[0, 0] {};

            // Act
            int[,] oneZeroMatrixActual = StringsAndArrays.ZeroMatrix(oneZeroMatrix);
            int[,] noZeroMatrixActual = StringsAndArrays.ZeroMatrix(noZeroMatrix);
            int[,] twoZeroMatrixActual = StringsAndArrays.ZeroMatrix(twoZeroMatrix);
            int[,] emptyMatrixActual = StringsAndArrays.ZeroMatrix(emptyMatrix);

            // Assert
            CollectionAssert.AreEqual(oneZeroMatrixExpected, oneZeroMatrixActual);
            CollectionAssert.AreEqual(noZeroMatrixExpected, noZeroMatrixActual);
            CollectionAssert.AreEqual(twoZeroMatrixExpected, twoZeroMatrixActual);
            CollectionAssert.AreEqual(emptyMatrixExpected, emptyMatrixActual);
        }
    }
}
