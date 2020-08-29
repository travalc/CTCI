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
    }
}
