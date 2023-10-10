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
            
        }

        public void Sort(int[] A)
        {
            //TODO #3: Implement MergeSort using the methods above
        }

        public bool CheckIsCorrect()
        {
            int n = 10;
            int[] A = Utils.CreateIntArray(n);

            Console.WriteLine("1.1 Checking Partition()");
            if (!Utils.IsPartitionCorrect(A, Partition(A, 0, 9), 0, 3))
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
