namespace Results;

public class ResultDemo3(ITestOutputHelper testOutputHelper)
{
  [Fact]
  public void Test()
  {
    var customer = new Customer(18);
    
    testOutputHelper.WriteLine(customer.Age.ToString());
  }

  private class Customer
  {
    public Customer(int age)
    {
      Age = age;
    }

    public int Age { get; set; }
  }

  private class Customer_MaybeFixed
  {
    public Customer_MaybeFixed(int age)
    {
      if (age < 0)
      {
        throw new ArgumentException("Age must not be negative!", nameof(age));
      }
      
      Age = age;
    }

    public int Age { get; set; }
  }

  private class Customer_DefinitelyFixed
  {
    private Customer_DefinitelyFixed(int age)
    {
      Age = age;
    }

    public static Result<Customer_DefinitelyFixed> Create(int age)
    {
      if (age < 0)
      {
        return Result.Failure<Customer_DefinitelyFixed>("Age must not be negative!");
      }

      return new Customer_DefinitelyFixed(age);
    }

    public int Age { get; set; }
  }
}