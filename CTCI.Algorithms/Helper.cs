using System;
using System.Collections.Generic;
using System.Linq;

namespace CTCI.Algorithms
{
    /// <summary>
    /// Utilitiy class containing helper mthods
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Method for slicing a list of ints into sublists
        /// </summary>
        /// <param name="list">List<int></param>
        /// <param name="start">int</param>
        /// <param name="end">int</param>
        /// <returns>List<int></returns>
        public static List<int> Slice(List<int> list, int start, int end)
        {
            if (end > list.Count || start > list.Count - 1 || start < 0 || list.Count < 1)
                throw new InvalidOperationException();
            int numToTake = end - start;
            List<int> sliced = list.Skip(start).Take(numToTake).ToList<int>();
            return sliced;
        }
    }
}