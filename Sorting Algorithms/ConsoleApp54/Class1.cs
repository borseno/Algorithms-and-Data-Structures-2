using System;

static void InsertionSort(int[] arr)
{
    for (int i = 1; i < arr.Length; i++)
    {
        int position = 0;
        for (int j = i - 1; j >= 0; j--)
        {
            if (arr[i] > arr[j])
            {
                position = j + 1;
                break;
            }
        }
        int result = arr[i];
        for (int k = i; k > position; k--)
        {
            arr[k] = arr[k - 1];
        }
        arr[position] = result;
    }
}
static void BinaryInsertionSort(int[] arr)
{
    for (int i = 1; i < arr.Length; i++)
    {
        /*// search for the position //*/
        int mid = 0;
        int low = 0;
        int high = i - 1;
        while (low < high)
        {
            if (arr[i] >= arr[mid])
                low = mid + 1;
            else if (arr[i] <= arr[mid])
                high = mid;
            mid = low + (high - low) / 2;
        }
        /*//*/
        if (arr[i] > arr[mid])
            mid = mid + 1;

        int result = arr[i];
        for (int k = i; k > mid; k--)
        {
            arr[k] = arr[k - 1];
        }
        arr[mid] = result;
    }
}
