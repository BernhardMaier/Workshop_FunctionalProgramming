using SharedKernel;

namespace Module1_Result;

public class Demo1 : Runnable
{
  public override void Run()
  {
    Print("Hello World!");
  }

  private static void Print(string? s)
  {
    Console.WriteLine(s);
  }
}