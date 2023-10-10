using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SelectionSort : ISortingAlgorithm
    {
        

        public void Sort(int[] A)
        {
            //TODO #1: Implement SelectionSort
            for (int pivot = 0;pivot < A.Length;pivot++) {
                for (int j = pivot + 1;j < A.Length;j++) {
                    if (A[j] < A[pivot])
                    {
                        Swap(A,pivot,j);
                    }
                }
            }
            
        }

        private void Swap(int[] A, int pivot, int j)
        {
            int num = A[pivot];
            A[pivot] = A[j];
            A[j] = num;
        }

        public bool CheckIsCorrect()
        {
            int n = 10;
            int[] A = Utils.CreateIntArray(n);

            Console.WriteLine("1.1 Checking Sort()");
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
