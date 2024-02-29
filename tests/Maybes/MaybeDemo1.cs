using CSharpFunctionalExtensions.ValueTasks;

namespace Maybes;

public class MaybeDemo1(ITestOutputHelper testOutputHelper)
{
  private readonly Dictionary<string, string> _dictionary = new();
  
  [Fact]
  public void Test()
  {
    _dictionary.Add("1", "Hello");
    _dictionary.Add("2", "World");
    _dictionary.Add("3", "!");

    string id = "4";
    var value = GetValueById_DefinitelyFixed(id);
    if (value.HasNoValue)
    {
      testOutputHelper.WriteLine("Not Found");
    }
    else
    {
      var res = value.GetValueOrDefault(string.Empty);
      testOutputHelper.WriteLine($"Id '{id}' has value '{res}' with length {res.Length}");
    }
  }

  private string GetValueById_Bugged(string id)
  {
    return _dictionary[id];
  }

  private string GetValueById_MaybeFixed(string id)
  {
    if (id == null)
    {
      return null;
    }
    
    return _dictionary[id];
  }

  private Maybe<string> GetValueById_DefinitelyFixed(string id)
  {
    if (id == null)
    {
      return Maybe<string>.None;
    }
    
    return _dictionary.TryFind(id);
  }
}