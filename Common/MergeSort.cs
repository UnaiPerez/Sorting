using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class MergeSort : ISortingAlgorithm
    {
        public int[] Partition(int[] A, int startIndex, int endIndex)
        {
            //TODO #1: return a new array with all elements in A from index startIndex to endIndex (both included): A[startIndex..endIndex]

            int tamañoPartition = endIndex - startIndex + 1;
            int[] partition = new int[tamañoPartition];
            for (int i = 0; i < tamañoPartition;i++) 
            {
                partition[i] = A[startIndex + i];
            }
     
            return partition;
        }

        public void MergePartitions(int[] A, int[] leftPartition, int[] rightPartition)
        {
            //TODO #2: Merge in A the two partitions sorting them
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < leftPartition.Length && j < rightPartition.Length)
            {
                if (leftPartition[i] < rightPartition[j])
                {
                    A[k] = leftPartition[i];
                    i++;
                }
                else
                {
                    A[k] = rightPartition[j];
                    j++;
                }
                k++;
            }
            

            while (i < leftPartition.Length)
            {
                A[k]= leftPartition[i];
                i++;   
                k++;
            }
            while (j < rightPartition.Length)
            {
                A[k] = rightPartition[j];
                j++;
                k++;
            }
        }

        public void Sort(int[] A)
        {
            //TODO #3: Implement MergeSort using the methods above
            if (A.Length <= 1 || A == null) {
                return;
            }

            int tam = A.Length;
            int mitad = tam / 2;

            int[] izq = Partition(A,0,mitad - 1);
            int[] der = Partition(A, mitad, tam - 1);

            Sort(izq);
            Sort(der);

            MergePartitions(A, izq, der);
        }

        public bool CheckIsCorrect()
        {
            int n = 10;
            int[] A = Utils.CreateIntArray(n);

            Console.WriteLine("1.1 Checking Partition()");
            if (!Utils.IsPartitionCorrect(A, Partition(A, 0, 3), 0, 3))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            if (!Utils.IsPartitionCorrect(A, Partition(A, 1, 1), 1, 1))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");
            Console.WriteLine("1.2. Checking MergePartitions()");
            int[] leftPartition = new int[3] { 1, 4, 6 };
            int[] rightPartition = new int[3] { 2, 3, 7 };
            int[] merged = new int[6] { 1, 4, 6, 2, 3, 7 };
            MergePartitions(merged, leftPartition, rightPartition);
            if (!Utils.IsOrdered(merged))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");
            return true;
        }
    }
}
