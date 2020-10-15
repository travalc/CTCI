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

        /// <summary>
        /// Bubble sort algorithm
        /// O(n^2) runtime, O(1) space
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(int[] arr)
        {
            if (arr.Length < 2)
                return;

            bool swapsMade;
            int p1 = 0;
            int p2 = 1;

            do
            {
                swapsMade = false;
                while (p2 < arr.Length)
                {
                    if (arr[p2] < arr[p1])
                    {
                        int temp = arr[p1];
                        arr[p1] = arr[p2];
                        arr[p2] = temp;
                        swapsMade = true;
                    }
                    p1 ++;
                    p2 ++;
                }
                p1 = 0;
                p2 = 1;
            }
            while (swapsMade);
        }

        /// <summary>
        /// Selection sort algorithm
        /// O(n^2) runtime, O(1) memory
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr)
        {
            if (arr.Length < 2)
                return;
            
            int curr = 0;
            int smallestIndex = 0;
            while (curr < arr.Length)
            {
                for (int i = curr + 1; i < arr.Length; i ++)
                {
                    if (arr[i] < arr[smallestIndex])
                        smallestIndex = i;
                }
                if (curr != smallestIndex)
                {
                    int temp = arr[curr];
                    arr[curr] = arr[smallestIndex];
                    arr[smallestIndex] = temp;
                }
                curr ++;
                smallestIndex = curr;
            }
        }

        /// <summary>
        /// Algorithm for quick sort, partitioning by mid element
        /// Base case - O(nLog(n)) runtime, worst case - O(n^2), O(log(n)) memory
        /// </summary>
        /// <param name="arr"></param>
        public static void QuickSort(int[] arr)
        {
            if (arr.Length < 2)
                return;
            int low = 0;
            int high = arr.Length - 1;
            QuickSort(arr, low, high);
        }

        private static void QuickSort(int[] arr, int low, int high)
        {
            int idx = Partition(arr, low, high);
            if (low < idx - 1)
                QuickSort(arr, low, idx - 1);
            if (idx < high)
                QuickSort(arr, idx, high);
        
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = (low + high) / 2;
            while (low <= high)
            {
                while (arr[low] < arr[pivot])
                    low ++;
                while (arr[high] > arr[pivot])
                    high --;
                if (arr[low] >= arr[high])
                {
                    int temp = arr[low];
                    arr[low] = arr[high];
                    arr[high] = temp;
                    low ++;
                    high --;
                }
            }
            return low;
        }
    }
}