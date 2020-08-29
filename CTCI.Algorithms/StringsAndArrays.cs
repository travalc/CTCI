using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.Algorithms
{
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
    }
}
