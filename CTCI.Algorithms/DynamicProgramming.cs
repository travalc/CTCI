using System;
using System.Collections.Generic;
using System.Linq;

namespace CTCI.Algorithms
{
    /// <summary>
    /// Utilitiy class containing helper mthods
    /// </summary>
    public static class DynamicProgramming
    {
        /// <summary>
        /// Memoized solution counting all possible steps given integer n
        /// O(n) time, O(n) space
        /// </summary>
        /// <param name="n">int</param>
        /// <returns>int</returns>
        public static int TripleStep(int n)
        {
            if (n < 1)
                return 0;
            
            Dictionary<int, int> cache = new Dictionary<int, int>();
            return TripleStep(n, ref cache);
        }

        private static int TripleStep(int n, ref Dictionary<int, int> cache)
        {
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;
            if (n == 3)
                return 3;
            
            if (cache.ContainsKey(n))
                return cache[n];
            cache.Add(n, TripleStep(n - 3, ref cache) + TripleStep(n - 2, ref cache) + TripleStep(n - 1, ref cache));
            
            return cache[n];
        }

        /// <summary>
        /// Bottom up approach to TripleStep, uses variables to remember previous steps
        /// O(n) time, O(1) space
        /// </summary>
        /// <param name="n">int</param>
        /// <returns>int</returns>
        public static int TripleStepBottomUp(int n)
        {
            if (n < 1)
                return 0;
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;
            if (n == 3)
                return 3;
            
            int i = 4;
            int a = 1;
            int b = 2;
            int c = 3;
            int result = a + b + c;

            while (i < n)
            {
                a = b;
                b = c;
                c = result;
                result = a + b + c;
                i ++;
            }

            return result;
        }
    }
}