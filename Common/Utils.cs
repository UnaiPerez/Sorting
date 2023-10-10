using System;

namespace Common
{
    public class Utils
    {
        public static int[] Clone(int[] array)
        {
            int[] clone = new int[array.Length];
            for (int i= 0; i< array.Length; i++)
                clone[i] = array[i];
            return clone;
        }
        public static int[] CreateIntArray(int n)
        {
            int[] A = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
                A[i] = random.Next(0, 100); //Choose a random number in range [0,100]

            return A; //return the array
        }

        public static string AsString(int[] A)
        {
            string output = "[";

            for (int i = 0; i < A.Length; i++)
                output += A[i] + ",";
            output = output.TrimEnd(',') + "]";

            return output;
        }

        public static bool IsOrdered(int[] A)
        {
            int n = A.Length;
            for (int i = 0; i < n - 1; i++)
                if (A[i] > A[i + 1])
                {
                    Console.WriteLine($"Array not sorted: {AsString(A)}");
                    return false;
                }

            return true;
        }

        public static bool IsMergeCorrect(int[] A, int[] lessThanPivot
      , int pivot, int[] greaterThanPivot)
        {
            int indexInMergedArray = 0;

            //check elements in lessThanPivot
            for (int i = 0; i < lessThanPivot.Length; i++)
            {
                if (A[indexInMergedArray] != lessThanPivot[i])
                {
                    Console.WriteLine($"MergePartitions failed: A[{indexInMergedArray}]={A[indexInMergedArray]}, lessThanPivot[{i}]= {lessThanPivot[i]}");
                    return false;
                }
                indexInMergedArray++;
            }

            //check pivot
            if (A[indexInMergedArray] != pivot)
            {
                Console.WriteLine($"MergePartitions failed: A[{indexInMergedArray}]={A[indexInMergedArray]}, pivot= {pivot}");
                return false;
            }
            indexInMergedArray++;

            //check elements in greaterThanPivot
            for (int i = 0; i < greaterThanPivot.Length; i++)
            {
                if (A[indexInMergedArray] != greaterThanPivot[i])
                {
                    Console.WriteLine($"MergePartitions failed: A[{indexInMergedArray}]={A[indexInMergedArray]}, greaterThanPivot[{i}]= {greaterThanPivot[i]}");
                    return false;
                }
                indexInMergedArray++;
            }

            return true;
        }

        public static bool IsPartitionCorrect(int[] A, int[] partition, int partitionStartIndex, int partitionEndIndex)
        {
            if (partition == null)
                return false;
            int partitionLength = partitionEndIndex - partitionStartIndex + 1;
            if (partition?.Length != partitionLength)
            {
                Console.WriteLine($"Wrong partition size: {partition?.Length} != {partitionLength}");
                return false;
            }
            int partitionIndex = 0;
            for (int i = partitionStartIndex; i <= partitionEndIndex; i++)
            {
                if (A[i] != partition[partitionIndex])
                {
                    Console.WriteLine($"Partition failed:");
                    Console.WriteLine($"A= {AsString(A)}");
                    Console.WriteLine($"Partition({partitionStartIndex},{partitionEndIndex})= {AsString(partition)}");
                    return false;
                }
                partitionIndex++;
            }
            return true;
        }

        public static bool IsPartitionCorrect(int[] A, int pivot, int partitionStartIndex, int partitionEndIndex)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (i < pivot && A[i] >= A[pivot])
                {
                    Console.WriteLine($"Partition failed:");
                    Console.WriteLine($"A= {AsString(A)}, Pivot= {pivot}");
                    Console.WriteLine($"A[{i}]= {A[i]}, A[{pivot}] = {A[pivot]}");
                    return false;
                }
                else if (i > pivot && A[i] < pivot)
                {
                    Console.WriteLine($"Partition failed:");
                    Console.WriteLine($"A= {AsString(A)}, Pivot= {pivot}");
                    Console.WriteLine($"A[{i}]= {A[i]}, A[{pivot}] = {A[pivot]}");
                }
            }
            
            return true;
        }

        public static bool IsPartitionCorrect(int[] A, int[] lessThanPivot, int pivot, int[] greaterThanPivot)
        {
            if (lessThanPivot.Length + greaterThanPivot.Length + 1 != A.Length)
            {
                Console.WriteLine($"Wrong partition size: {lessThanPivot.Length}+{greaterThanPivot.Length}+1 != {A.Length}");
                return false;
            }
            for (int i = 0; i < lessThanPivot.Length; i++)
                if (A[pivot] <= lessThanPivot[i])
                {
                    Console.WriteLine($"ElementsLessThan failed: {lessThanPivot[i]} < {A[pivot]}");
                    return false;
                }
            for (int i = 0; i < greaterThanPivot.Length; i++)
                if (A[pivot] > greaterThanPivot[i])
                {
                    Console.WriteLine($"ElementsGreaterThan failed: {greaterThanPivot[i]} > {A[pivot]}");
                    return false;
                }
            Console.WriteLine("OK");
            return true;
        }

        public static void Swap(int[] A, int index1, int index2)
        {
            int tmp = A[index1];
            A[index1] = A[index2];
            A[index2] = tmp;
        }

        public static int Sum(int[] A, int index1, int index2)
        {
            int sum = 0;

            for (int i = index1; i <= index2; i++)
                sum += A[i];

            return sum;
        }
    }
}
