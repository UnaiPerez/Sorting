using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class QuickSort : ISortingAlgorithm
    {
        public int Partition(int[] A, int firstIndex, int lastIndex)
        {
            //TODO #1: Choose a pivot, move all elements lower than the pivot to the beginning of the array and return the position where the pivot has been moved to
            int pivotPos = 0;
            int pivot = A[firstIndex];
            for(int i = pivotPos + 1;i < lastIndex;i++)
            {
                if (A[i] < pivot)
                {
                    Swap(A, i, pivotPos);
                    pivotPos++;
                }
            }
            Swap(A, pivot, pivotPos);
            return pivotPos;
        }

        private void Swap(int[] A, int i, int pivotPos)
        {
            int num = A[pivotPos];
            A[pivotPos] = A[i];
            A[i] = num;
        }


        public void Sort(int[] A, int firstIndex, int lastIndex)
        {
            //TODO #2: Implement QuickSort using the method above
            //         a) Partition the array

            //         b) Recursively order the elements before the pivot, and after the pivot
           

        }

        public void Sort(int[] A)
        {
            Sort(A, 0, A.Length - 1);
        }

        public bool CheckIsCorrect()
        {
            Console.WriteLine("1.1. Checking Partition()");

            for (int i= 0; i< 1000; i++)
            {
                int[] array = new int[] { 6, 1, 55, 53, 33, 49, 38, 32, 30, 2 };//
                              //                                                  Utils.CreateIntArray(10);
                int[] originalArray = Utils.Clone(array);
                int sumBefore = Utils.Sum(array, 0, array.Length - 1);
                int pivot = Partition(array, 0, array.Length - 1);
                if (pivot < 0 || pivot > array.Length - 1)
                {
                    Console.WriteLine($"FAILED (Partition returned an invalid index: {pivot})");
                    return false;
                }
                int pivotValue = array[pivot];
                int sumAfter = Utils.Sum(array, 0, array.Length - 1);
                if (sumBefore != sumAfter)
                {
                    Console.WriteLine("FAILED (Partition didn't keep all the elements that were in the array)");
                    return false;
                }
                if (!Utils.IsPartitionCorrect(array, pivot, 0, array.Length - 1))
                {
                    Console.WriteLine("FAILED");
                    return false;
                }
            }
            Console.WriteLine("PASSED");

            Console.WriteLine("1.2. Checking Sort()");
            int n = 10;
            int [] A = Utils.CreateIntArray(n);
            Sort(A);
            if (!Utils.IsOrdered(A))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");

            return true;
        }
    }
}
