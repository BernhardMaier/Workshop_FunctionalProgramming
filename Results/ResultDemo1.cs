namespace Results;

public class ResultDemo1(ITestOutputHelper testOutputHelper)
{
  [Fact]
  public void Test()
  {
    var res1 = Print_Fixed("Hello World!");
    if (res1.IsFailure)
      testOutputHelper.WriteLine(res1.Error);
    
    var res2 = Print_Fixed(null);
    if (res2.IsFailure)
      testOutputHelper.WriteLine(res2.Error);
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