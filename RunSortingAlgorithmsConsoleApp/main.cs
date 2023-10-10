using System;
using System.Collections.Generic;
using System.Diagnostics;
using Common;
class MainClass
{
    public static void TestSortingAlgorithm(ISortingAlgorithm sortingAlgorithm)
    {
        Console.WriteLine($"## Testing sorting algorithm {sortingAlgorithm.GetType().Name}");
        Console.WriteLine("1. Checking the algorithm works");
        if (!sortingAlgorithm.CheckIsCorrect())
            return;

        Console.WriteLine("2. Measuring speed");
        Stopwatch stopwatch = new Stopwatch();

        
        int maxSize = 100000;
        int size = 10;
        while (size <= maxSize)
        {
            stopwatch.Start();

            int[] A = Utils.CreateIntArray(size);
            sortingAlgorithm.Sort(A);

            stopwatch.Stop();

            if (!Utils.IsOrdered(A))
                return;

            Console.WriteLine($"n={size} => {stopwatch.Elapsed.TotalSeconds}s");
            
            size *= 10;
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        TestSortingAlgorithm(new SelectionSort());
        TestSortingAlgorithm(new QuickSort());
        TestSortingAlgorithm(new MergeSort());
    }
}