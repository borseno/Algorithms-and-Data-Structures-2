using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    public static class HeapSortAlgorithm
    {
        public static void HeapSort(int[] input)
        {                   // temp: 10
            //Build-Max-Heap             // 2 4 10 15 20// { 4, 10, 2, 15}; --> 
            int i;
            for (i = ((input.Length - 1) / 2); i >= 0; i--) // p = 2 >= 0 2--;
                MaxHeapify(input, input.Length, i);

            for (i = input.Length - 1; i > 0; i--)
            {
                //Swap
                int temp = input[i];
                input[i] = input[0];
                input[0] = temp;

                MaxHeapify(input, i, 0);
            }
        }

        private static void MaxHeapify(int[] input, int heapSize, int index)
        {//                            
            int left = index * 2 + 1; // 10 4 2 
            int right = left + 1;
            int largest = index;

            if (left < heapSize && input[left] > input[index])
                largest = left;
            if (right < heapSize && input[right] > input[largest])
                largest = right;

            if (largest != index)
            {
                int temp = input[index];
                input[index] = input[largest];
                input[largest] = temp;

                MaxHeapify(input, heapSize, largest);
            }
        }
    }
}
