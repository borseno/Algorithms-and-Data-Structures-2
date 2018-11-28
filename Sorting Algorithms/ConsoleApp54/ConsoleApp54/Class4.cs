using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    static class QuickSortAlgorithm
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }// 3 9 1 8 2 5 6
        private static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
                return;
            int pivot = array[start];
            int left = start;

            for (int i = start + 1; i <= end; ++i)
            {
                if (array[i] <= pivot)
                {
                    int temp = array[left + 1];
                    array[left + 1] = array[i];
                    array[i] = temp;
                    ++left;
                }
            }
            int temp1 = array[left];
            array[left] = pivot;
            array[start] = temp1;

            QuickSort(array, start, left - 1);
            QuickSort(array, left + 1, end);
        }
    }
}
