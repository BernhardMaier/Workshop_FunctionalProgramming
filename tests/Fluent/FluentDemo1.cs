namespace Fluent;

public class FluentDemo1(ITestOutputHelper testOutputHelper)
{
  [Fact]
  public void Test()
  {
    var words = new[] { "Hello", "World", "!" };
    var lengths = GetLengths_Short(words);
    
    testOutputHelper.WriteLine(string.Join(',', lengths));
  }
  
  private static List<int> GetLengths(IReadOnlyList<string> words)
  {
    var list = new List<int>();
    
    for (var i = 0; i < words.Count; i++)
    {
      list.Add(words[i].Length);
    }

    return list;
  }

  private static IEnumerable<int> GetLengths_Short(IEnumerable<string> words)
  {
    return words
      .Select(t => t.Length)
      .ToList();
  }
}