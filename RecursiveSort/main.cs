using System;
using System.Diagnostics;
using Common;
class MainClass 
{
  
  public static int Factorial(int n)
  {
        //Calculate n! recursively
        //Trivial cases: 0! = 1, 1! = 1
        //Inductive case: n! = n * (n-1)!
        return 0;
  } 

  public static void Main (string[] args) 
  {
    int n = 5;
    
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    
    int result = Factorial(n);

    stopwatch.Stop();

    Console.WriteLine($"{n}! = {result}");
    Console.WriteLine($"Time: {stopwatch.Elapsed}");
  }
}