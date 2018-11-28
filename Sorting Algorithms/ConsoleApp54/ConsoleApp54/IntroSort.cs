using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    class IntroSortAlgorithm
    {
        public static void IntroSort(int[] data)
        {
            int partitionSize = Partition(ref data, 0, data.Length - 1);

            if (partitionSize < 16)
            {
                InsertionSort(data);
            }
            else if (partitionSize > (2 * Math.Log(data.Length)))
            {
                HeapSort(ref data);
            }
            else
            {
                QuickSortRecursive(ref data, 0, data.Length - 1);
            }
        }

        private static void InsertionSort(int[] data)
        {
            for (int i = 1; i < data.Length; ++i)
            {
                int j = i;

                while ((j > 0))
                {
                    if (data[j - 1] > data[j])
                    {
                        data[j - 1] ^= data[j];
                        data[j] ^= data[j - 1];
                        data[j - 1] ^= data[j];

                        --j;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void HeapSort(ref int[] data)
        {
            int heapSize = data.Length;

            for (int p = (heapSize - 1) / 2; p >= 0; --p)
                MaxHeapify(ref data, heapSize, p);

            for (int i = data.Length - 1; i > 0; --i)
            {
                int temp = data[i];
                data[i] = data[0];
                data[0] = temp;

                --heapSize;
                MaxHeapify(ref data, heapSize, 0);
            }
        }

        private static void MaxHeapify(ref int[] data, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && data[left] > data[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && data[right] > data[largest])
                largest = right;

            if (largest != index)
            {
                int temp = data[index];
                data[index] = data[largest];
                data[largest] = temp;

                MaxHeapify(ref data, heapSize, largest);
            }
        }

        private static void QuickSortRecursive(ref int[] data, int left, int right)
        {
            if (left < right)
            {
                int q = Partition(ref data, left, right);
                QuickSortRecursive(ref data, left, q - 1);
                QuickSortRecursive(ref data, q + 1, right);
            }
        }

        private static int Partition(ref int[] data, int left, int right)
        {
            int pivot = data[right];
            int temp;
            int i = left;

            for (int j = left; j < right; ++j)
            {
                if (data[j] <= pivot)
                {
                    temp = data[j];
                    data[j] = data[i];
                    data[i] = temp;
                    i++;
                }
            }

            data[right] = data[i];
            data[i] = pivot;

            return i;
        }
    }
}
