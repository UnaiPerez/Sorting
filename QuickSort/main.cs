using Common;
using System;
using System.Diagnostics;

class MainClass 
{
  public static int [] ElementsLessThan(int [] A, int pivotIndex)
  {
    //TODO #1: return a new array with all elements in A that are less than A[pivotIndex]

    int count = 0;
    for (int i= 0; i<A.Length; i++)
    {
      if (A[i] < A[pivotIndex])
      {
        count++;
      }
    }
    int [] lessThan = new int[count];
    int lessThanIndex = 0;
    for (int i= 0; i<A.Length; i++)
    {
      if (A[i] < A[pivotIndex])
      {
        lessThan[lessThanIndex] = A[i];
        lessThanIndex++;
      }
    }

    return lessThan;
  }

  public static int [] ElementsGreaterThan(int [] A, int pivotIndex)
  {
    //TODO #2: return a new array with all elements in A that are greater or equal to A[pivotIndex]
    int count = 0;
    for (int i= 0; i<A.Length; i++)
    {
      if (i!=pivotIndex && A[i] >= A[pivotIndex])
      {
        count++;
      }
    }
    int [] greaterThan = new int[count];
    int greaterThanIndex = 0;
    for (int i= 0; i<A.Length; i++)
    {
      if (i!=pivotIndex && A[i] >= A[pivotIndex])
      {
        greaterThan[greaterThanIndex] = A[i];
        greaterThanIndex++;
      }
    }

    return greaterThan;
  }
  
  public static void MergePartitions(int [] A, int [] lessThanPivot, int pivot, int [] greaterThanPivot)
  {
    //TODO #3: Merge in A the three different parts ([lessThanPivot],pivot,[greaterThanPivot])

    int aIndex= 0;
    for (int i= 0; i<lessThanPivot.Length; i++)
    {
      A[aIndex] = lessThanPivot[i];
      aIndex++;
    }

    A[aIndex] = pivot;
    aIndex++;

    for (int i= 0; i<greaterThanPivot.Length; i++)
    {
      A[aIndex] = greaterThanPivot[i];
      aIndex++;
    }
  }

  public static void QuickSort(int [] A)
  {
    //TODO #4: Implemen QuickSort using the methods above
    
    //Sort A using SelectionSort algorithm

    //Trivial case #1: empty array
    if (A.Length <= 1)
      return;
    
    //Trivial case #2: only two elements
    if (A.Length == 2)
    {
      if (A[0]>A[1])
      {
        int tmp= A[0];
        A[0] = A[1];
        A[1] = tmp;
      }
      return;
    }
    
    //Inductive case

    int pivotIndex = 0;
    //create partitions
    int [] lessThan = ElementsLessThan(A, pivotIndex);
    int [] greaterThan = ElementsGreaterThan(A, pivotIndex);
    
    //order partitions
    QuickSort(lessThan);
    QuickSort(greaterThan);
    
    //merge ordered partitions
    MergePartitions(A, lessThan, A[pivotIndex], greaterThan);
  } 

  public static void Main (string[] args) 
  {
    int n = 10;
    int [] A = Utils.CreateIntArray(n);

    Console.WriteLine($"Random Array = {Utils.AsString(A)}");

    Console.WriteLine("1. Checking ElementsLessThan/ElementsGreaterThan:");
    if (!Utils.IsPartitionCorrect(A, ElementsLessThan(A,0)
      , 0, ElementsGreaterThan(A,0)))
      return;

    Console.WriteLine("2. Checking MergePartitions:");
    int [] lessThan = ElementsLessThan(A,0);
    int [] greaterThan = ElementsGreaterThan(A,0);
    int pivot = A[0];
    MergePartitions(A, lessThan, pivot, greaterThan);

    if (!Utils.IsMergeCorrect(A, lessThan, pivot, greaterThan))
      return;

    Console.WriteLine("3. Checking QuickSort:");
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    
    QuickSort(A);

    stopwatch.Stop();

    if (!Utils.IsOrdered(A))
      return;

    Console.WriteLine($"Time spent ordering {n} elements: {stopwatch.Elapsed}");
  }
}