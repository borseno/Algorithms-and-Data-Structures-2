using System;
using System.Threading;

namespace Sorting
{
    class TestSortingAlgorithms
    {
        delegate void sortingAlgorithm(int[] array);

        static sortingAlgorithm[] sortingAlgorithms = {
            HeapSortAlgorithm.HeapSort, MergeSortAlgorithm.MergeSort, QuickSortAlgorithm.QuickSort, array => Array.Sort(array), array => IntroSortAlgorithm.IntroSort(array) };


        static public void Test(int[] array)
        {
            int[] temp = new int[array.Length];

            foreach (var i in sortingAlgorithms)
            {
                array.CopyTo(temp, 0);
                Test(temp, i);
            }
        }
        static private void Test(int[] array, sortingAlgorithm algorithm)
        {

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            algorithm.Invoke(array);
            stopwatch.Stop();

            bool isSorted = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    isSorted = false;
                    break;
                }
            }

            Console.WriteLine("-------------------------------------------\n");
            Console.WriteLine($"Algorithm: {algorithm.Method.Name} Ticks: {stopwatch.ElapsedTicks}, Time: {stopwatch.Elapsed}, Sorted: {isSorted}\n");
            Console.WriteLine("-------------------------------------------\n\n");
        }
    }


    class Program
    {
        static void Minor()
        {
            for (int ij = 0; ij < 3; ij++)
            {
                int[] RandomArray = new int[100000];
                for (int i = 0; i < RandomArray.Length; i++)
                {
                    RandomArray[i] = new Random().Next(1, RandomArray.Length * 35);
                }

                Console.WriteLine("Testing Random Array!");

                TestSortingAlgorithms.Test(RandomArray);
            }
            Console.Read();
        }

        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(Minor), 1048576 * 100);
            thread.Start();
            Thread anotherThread = new Thread(new ThreadStart(AnotherMethod));
            anotherThread.Start();

            Random rnd = new Random();

            while (rnd.Next(1, 50000000) != 5)
            { }    
            Console.WriteLine("it was 5! =D");
        }
        static void AnotherMethod()
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (i % 92832231 == 0)
                    Console.WriteLine(i);
            }
        }
    }

}
