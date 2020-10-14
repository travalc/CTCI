using System;
using System.Collections.Generic;
using System.Linq;

namespace CTCI.Algorithms
{
    public static class SortingAlgorithms
    {
        /// <summary>
        /// Merge sort algorithm
        /// O(nLog(n)) runtime O(n) space
        /// </summary>
        /// <param name="arr">int[]</param>
        public static void MergeSort(int[] arr)
        {
            int len = arr.Length;
            int[] copy = new int[len];
            int mid = len / 2;
            int low = 0;
            int high = len - 1;
            MergeSort(arr, copy, low, mid, high);
        }

        private static void MergeSort(int[] arr, int[] copy, int low, int mid, int high)
        {
            if (low < high)
            {
                int leftLow = low;
                int leftHigh = mid - 1;
                int leftMid = mid / 2;
                int rightLow = mid;
                int rightHigh = high;
                int rightMid = (rightHigh + rightLow + 1) / 2;
                MergeSort(arr, copy, leftLow, leftMid, leftHigh);
                MergeSort(arr, copy, rightLow, rightMid, rightHigh);
                Merge(arr, copy, low, mid, high);
            }
        }

        private static void Merge(int[] arr, int[] copy, int low, int mid, int high)
        {
            for (int i = low; i <= high; i ++)
            {
                copy[i] = arr[i];
            }
            
            int curr = low;
            int leftCurr = low;
            int rightCurr = mid;
            while (leftCurr < mid && rightCurr <= high)
            {
                if (copy[leftCurr] <= copy[rightCurr])
                {
                    arr[curr] = copy[leftCurr];
                    leftCurr ++;
                }
                else
                {
                    arr[curr] = copy[rightCurr];
                    rightCurr ++;
                }
                curr ++;
            }

            int remaining = mid - leftCurr;
            for (int i = 0; i < remaining; i ++)
                arr[curr + i] = copy[leftCurr + i];
        }
    }
}