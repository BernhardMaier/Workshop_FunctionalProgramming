namespace Results;

public class ResultDemo2(ITestOutputHelper testOutputHelper)
{
  [Fact]
  public void Test()
  {
    var result = Divide_Bugged(8,2);
    
    testOutputHelper.WriteLine(result.ToString());
  }

  private static int Divide_Bugged(int a, int b)
  {
    return a/b;
  }

  private static int Divide_MaybeFixed(int a, int b)
  {
    if (b == 0)
    {
      throw new ArgumentException("Divider must not be zero!", nameof(b)); // Alternative: "return null;"
    }

    return a/b;
  }

  private static Result<int> Divide_DefinitelyFixed(int a, int b)
  {
    if (b == 0)
    {
      return Result.Failure<int>("Divider must not be zero!");
    }

    return a/b;
  }
}