namespace Maybes;

public class MaybeDemo1(ITestOutputHelper testOutputHelper)
{
  private readonly Dictionary<int, string> _dictionary = new();
  
  [Fact]
  public void Test()
  {
    _dictionary.Add(1, "Hello");
    _dictionary.Add(2, "World");
    _dictionary.Add(3, "!");

    var id = 1;
    var value = GetValueById_Bugged(id);
    testOutputHelper.WriteLine($"Id '{id}' has value '{value}' with length {value.Length}");
  }

  private string GetValueById_Bugged(int id)
  {
    return _dictionary[id];
  }

  private string GetValueById_MaybeFixed(int id)
  {
    if (id == null)
    {
      return null;
    }
    
    return _dictionary[id];
  }

  private Maybe<string> GetValueById_DefinitelyFixed(int id)
  {
    if (id == null)
    {
      return Maybe<string>.None;
    }
    
    return _dictionary.TryFind(id);
  }
}