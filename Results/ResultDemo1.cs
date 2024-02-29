namespace Results;

public class ResultDemo1(ITestOutputHelper testOutputHelper)
{
  [Fact]
  public void Test()
  {
    Print("Hello World!");
    Print(null);
  }

  private void Print(string? s)
  {
    testOutputHelper.WriteLine($"Message: {s}");
  }

  private void Print_Bugged(string? s)
  {
    if (s != null)
    {
      testOutputHelper.WriteLine($"Message: {s}");
    }
  }
  
  private Result Print_Fixed(string? s)
  {
    if (s == null)
    {
      return Result.Failure("Nothing to print!");
    }
    
    testOutputHelper.WriteLine($"Message: {s}");
    return Result.Success();
  }
}