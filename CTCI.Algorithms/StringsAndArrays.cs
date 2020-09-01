using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.Algorithms
{
    /// <summary>
    /// Algorithms for strings and arrays problems.
    /// </summary>
    public static class StringsAndArrays
    {
        /// <summary>
        /// Algorithm for determining if all chars in a string are unique. O(n) time complexity, O(n) space complexity
        /// </summary>
        /// <param name="s"></param>
        /// <returns>true if all chars in s are unique</returns>
        public static bool IsUnique(string s)
        {
            int sLength = s.Length;
            if (sLength == 0)
                return false;
            if (sLength == 1)
                return true;
            
            HashSet<char> hashSet = new HashSet<char>();
            
            foreach (char c in s)
            {
                if (hashSet.Contains(c))
                    return false;
                hashSet.Add(c);
            }

            return true;
        }

        /// <summary>
        /// Algorithm for determining if one string is a permutation of another. Chars are case sensitive, and includes whitespace.
        /// O(n) time complexity, O(n) space complexity
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns>True if s1 is a permutation of s2</returns>
        public static bool CheckPermutation(string s1, string s2)
        {
            if (s1.Length == 0 && s2.Length == 0)
                return true;
            if (s1.Length != s2.Length)
                return false;
            
            Dictionary<char, int> charDict = new Dictionary<char, int>();
            
            foreach (char c in s1)
            {
                if (!charDict.ContainsKey(c))
                    charDict.Add(c, 1);
                else
                    charDict[c] += 1;
            }

            foreach (char c in s2)
            {
                if (!charDict.ContainsKey(c))
                    return false;
                else
                {
                    if (charDict[c] == 0)
                        return false;
                    else
                        charDict[c] -= 1;
                }
            }

            return true;
        }

        /// <summary>
        /// Algorithm for converting a string to URL format. Whitespace is replaced with "%20". 
        /// O(n) time complexity, O(n) space complexity
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string URLify(string s)
        {
            int sLen = s.Length;
            if (sLen == 0)
                return "";
            
            int leadPointer = 0;
            while (s[leadPointer] == ' ' && leadPointer < sLen - 1)
                leadPointer ++;
            
            if (leadPointer == sLen - 1 && s[leadPointer] == ' ')
                return "";
            
            int tailPointer = sLen - 1;
            while (s[tailPointer] == ' ' && tailPointer >= leadPointer)
                tailPointer --;
            
            StringBuilder sb = new StringBuilder();
            while (leadPointer <= tailPointer)
            {
                if (s[leadPointer] != ' ')
                    sb.Append(s[leadPointer]);
                else
                    sb.Append("%20");
                
                leadPointer ++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Method for determining if string is a permutation of a palindrome.
        /// O(n) time complexity, O(n) space complexity
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>True if permutation of palindrome, false if not.</returns>
        public static bool IsPalindromePermutation(string s)
        {
            if (s.Length == 0)
                return false;
            
            Dictionary<char, int> charDict = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (c != ' ')
                {
                    if (!charDict.ContainsKey(c))
                        charDict.Add(c, 1);
                    else
                        charDict[c] ++;
                }
            }
            if (charDict.Count == 0)
                return false;
            
            bool oddFound = false;
            foreach(KeyValuePair<char, int> entry in charDict)
            {
                int rem = entry.Value % 2;
                if (rem > 0)
                {
                    if (oddFound)
                        return false;
                    oddFound = true;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if 2 strings are <= 1 edit (insert/delete/change) away from being equal
        /// O(n) time complexity, O(1) space complexity
        /// </summary>
        /// <param name="s1">String</param>
        /// <param name="s2">String</param>
        /// <returns>True if one edit away, false if not</returns>
        public static bool IsOneAway(string s1, string s2)
        {
            int s1Len = s1.Length;
            int s2Len = s2.Length;
            int diff = Math.Abs(s1Len - s2Len);
            if (diff > 1)
                return false;
            
            if (s1Len != s2Len)
            {
                string smallerString, largerString;
                if (s1Len < s2Len)
                {
                    smallerString = s1;
                    largerString = s2;
                }
                else
                {
                    smallerString = s2;
                    largerString = s1;
                }
                
                int smallerPointer = 0;
                int largerPointer = 0;
                while (smallerPointer < smallerString.Length && smallerString[smallerPointer] == largerString[largerPointer])
                {
                    smallerPointer ++;
                    largerPointer ++;
                }
                if (smallerPointer == smallerString.Length)
                    return true;
                
                largerPointer ++;
                while (smallerPointer < smallerString.Length)
                {
                    if (smallerString[smallerPointer] != largerString[largerPointer])
                        return false;
                    smallerPointer ++;
                    largerPointer ++;
                }

                return true;
            }

            bool edited = false;
            int pointer = 0;
            while (pointer < s1Len)
            {
                if (s1[pointer] != s2[pointer])
                {
                    if (edited)
                        return false;
                    edited = true;
                }
                pointer ++;
            }

            return true;
        }

        /// <summary>
        /// Compresses a string to less than length of input string.
        /// O(n) time complexity, O(n) space complexity
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>If compressed string is shorter than input, returns a compressed string. Otherwise original is returned</returns>
        public static string CompressString(string s)
        {
            if (s.Length < 3)
                return s;
            
            Dictionary<char, int> charDict = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!charDict.ContainsKey(c))
                    charDict.Add(c, 1);
                else
                    charDict[c] ++;
            }
            if (charDict.Count * 2 >= s.Length)
                return s;
            
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<char, int> entry in charDict)
            {
                string coded = entry.Key + entry.Value.ToString();
                sb.Append(coded);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Rotates matrix in place by 90 degrees.
        /// O(n) time complexity, O(n) space
        /// </summary>
        /// <param name="inputMatrix"></param>
        /// <returns></returns>
        public static int[,] RotateMatrix(int[,] inputMatrix)
        {
            Console.WriteLine(inputMatrix.GetLength(0));
            if (inputMatrix.Length == 0)
                return inputMatrix;
            
            int layers = inputMatrix.GetLength(0) / 2;
            int min = 0;
            int max = inputMatrix.GetLength(0) - 1;

            while (layers > 0)
            {
                MatrixPointer p1 = new MatrixPointer(min, min);
                MatrixPointer p2 = new MatrixPointer(min, max);
                MatrixPointer p3 = new MatrixPointer(max, max);
                MatrixPointer p4 = new MatrixPointer(max, min);

                int i = min;
                while (i < max)
                {
                    SwapPointers(inputMatrix, p1, p2, p3, p4);
                    p1.Col ++;
                    p2.Row ++;
                    p3.Col --;
                    p4.Row --;
                    i ++;
                }
                min ++;
                max --;
                layers --;
            }

            return inputMatrix;
        }

        private static void SwapPointers(int[,] inputMatrix, MatrixPointer p1, MatrixPointer p2, MatrixPointer p3, MatrixPointer p4)
        {
            int temp1, temp2; 
            temp1 = inputMatrix[p2.Row, p2.Col];
            inputMatrix[p2.Row, p2.Col] = inputMatrix[p1.Row, p1.Col];
            temp2 = temp1;
            temp1 = inputMatrix[p3.Row, p3.Col];
            inputMatrix[p3.Row, p3.Col] = temp2;
            temp2 = temp1;
            temp1 = inputMatrix[p4.Row, p4.Col];
            inputMatrix[p4.Row, p4.Col] = temp2;
            temp2 = temp1;
            inputMatrix[p1.Row, p1.Col] = temp1;
        }

        /// <summary>
        /// Finds all zero elements in a NxM matrix and zeroes out their columns and rows
        /// O(n) time and space complexity
        /// </summary>
        /// <param name="inputMatrix">int[,] matrix</param>
        /// <returns>int[,] matrix</returns>
        public static int[,] ZeroMatrix(int[,] inputMatrix)
        {
            if (inputMatrix.GetLength(0) == 0 || inputMatrix.GetLength(1) == 0)
                return inputMatrix;
            
            List<MatrixPointer> zeroList = new List<MatrixPointer>();
            for (int row = 0; row < inputMatrix.GetLength(0); row ++)
            {
                for (int col = 0; col < inputMatrix.GetLength(1); col ++)
                {
                    if (inputMatrix[row, col] == 0)
                    {
                        MatrixPointer zeroPointer = new MatrixPointer(row, col);
                        zeroList.Add(zeroPointer);
                    }
                }
            }
            if (zeroList.Count == 0)
                return inputMatrix;
            
            foreach (MatrixPointer pointer in zeroList)
            {
                int zeroRow = pointer.Row;
                int zeroCol = pointer.Col;

                int currRow = 0;
                while (currRow < inputMatrix.GetLength(0))
                {
                    if (inputMatrix[currRow, zeroCol] != 0)
                        inputMatrix[currRow, zeroCol] = 0;
                    currRow ++;
                }

                int currCol = 0;
                while (currCol < inputMatrix.GetLength(1))
                {
                    if (inputMatrix[zeroRow, currCol] != 0)
                        inputMatrix[zeroRow, currCol] = 0;
                    currCol ++;
                }
            }

            return inputMatrix;
        }

        /// <summary>
        /// Checks if one string is a rotation of another string
        /// O(n) time, O(n) space
        /// </summary>
        /// <param name="s1">string to be checked if rotation of</param>
        /// <param name="s2">string check to be a rotation of s1</param>
        /// <returns>bool: true if s2 is rotation of s1</returns>
        public static bool IsRotation(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            if (s1.Length == 0 && s2.Length == 0)
                return false;
            if (s1 == s2)
                return true;
            if (s1.Length == 1 && s2.Length == 1)
                return false;
            string s1Concatenated = s1 + s1;
            
            return IsSubstring(s1Concatenated, s2);
        }

        /// <summary>
        /// Helper function for checking if one string is substring of another
        /// </summary>
        /// <param name="s1">container string</param>
        /// <param name="s2">containee string</param>
        /// <returns>bool, true if s2 is substring of s1</returns>
        public static bool IsSubstring(string s1, string s2)
        {
            return s1.Contains(s2);
        }
    }

    /// <summary>
    /// Helper class for tracking pointers in matrix problems.
    /// </summary>
    public class MatrixPointer
    {
        public int Row;
        public int Col;
        public MatrixPointer(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
