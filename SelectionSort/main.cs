using System;
using System.Diagnostics;

class MainClass 
{
  public static void SelectionSort(int [] A)
  {
    //TODO: Sort A using SelectionSort algorithm
   
  } 

  public static void Main (string[] args) 
  {
    int n = 10;
    int [] A = Utils.CreateIntArray(n);

    Console.WriteLine($"Test array = {Utils.AsString(A)}");

    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    
    SelectionSort(A);

    stopwatch.Stop();

    if (!Utils.IsOrdered(A))
      return;
    
    Console.WriteLine($"Result = {Utils.AsString(A)}");
    Console.WriteLine($"Time spent ordering {n} elements: {stopwatch.Elapsed}");
  }
}