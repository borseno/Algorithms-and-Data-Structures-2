using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    static class MergeSortAlgorithm
    {
        static private void Merge(int[] array, int start, int mid, int end)
        {
            int[] tempArray = new int[end - start + 1];
            int tempIndex = 0;
            int start2 = mid + 1;

            while (start2 <= end && start <= mid)
            {
                if (array[start] <= array[start2])
                {
                    tempArray[tempIndex] = array[start];
                    start++;
                }
                else
                {
                    tempArray[tempIndex] = array[start2];
                    start2++;
                }
                tempIndex++;
            }

            if (start2 > end)
                for (; start <= mid; start++)
                {
                    tempArray[tempIndex] = array[start];
                    tempIndex++;
                }
            else
                for (; start2 <= end; start2++)
                {
                    tempArray[tempIndex] = array[start2];
                    tempIndex++;
                }
            tempIndex--;
            for (; tempIndex >= 0; tempIndex--)
            {
                array[end] = tempArray[tempIndex];
                end--;
            }

        }

        static private void MergeSort(int[] array, int start, int end)
        {
            if ((end - start) > 0)
            {
                int mid = start + (end - start) / 2;
                MergeSort(array, mid + 1, end);
                MergeSort(array, start, mid);
                Merge(array, start, mid, end);
            }
        }

        static public void MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }
    }
}
