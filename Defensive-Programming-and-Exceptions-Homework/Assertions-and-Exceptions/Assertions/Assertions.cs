﻿using System;
using System.Diagnostics;

class Assertions
{
    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Collection is null!");
        Debug.Assert(arr.Length >= 0, "Collection is empty!");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Collection is null!");
        Debug.Assert(arr.Length > 0, "Collection is empty!");
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Start index out of range!");
        Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "End index out of range!");
        Debug.Assert(startIndex + 1 <= endIndex, "Start index is greater than end index!");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }
        return minElementIndex;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Collection is null!");
        Debug.Assert(arr.Length > 0, "Collection is empty!");
        Debug.Assert(value != null, "Value is null!");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Collection is null!");
        Debug.Assert(arr.Length > 0, "Collection is empty!");
        Debug.Assert(value != null, "Value is null!");
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Start index out of range!");
        Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "End index out of range!");
        Debug.Assert(startIndex + 1 <= endIndex, "Start index is greater than end index!");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }


    private static void Swap<T>(ref T x, ref T y)
    {
        Debug.Assert(x != null, "X is null!");
        Debug.Assert(y != null, "Y is null!");

        T oldX = x;
        x = y;
        y = oldX;
    }
}
