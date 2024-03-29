using FluentAssertions;

namespace Fluent;

public class FluentDemo2(ITestOutputHelper testOutputHelper)
{
  [Fact]
  public void Test()
  {
    var customer = new CustomerWithFluentMethods();
    
    testOutputHelper.WriteLine("Room for anything...");
    
    customer.SetId(1).SetAge(18);

    customer.Age.Should().Be(18);
    
    testOutputHelper.WriteLine($"Customer with id {customer.Id} and age {customer.Age}.");
  }

  private class Customer
  {
    public int Id { get; set; }
    public int Age { get; set; }
  }

  private class CustomerWithMethods
  {
    public int Id { get; private set; }
    public int Age { get; private set; }

    public void SetId(int newId)
    {
      Id = newId;
    }

    public void SetAge(int newAge)
    {
      Age = newAge;
    }
  }

  private class CustomerWithFluentMethods
  {
    public int Id { get; private set; }
    public int Age { get; private set; }

    public CustomerWithFluentMethods SetId(int newId)
    {
      Id = newId;
      return this;
    }

    public CustomerWithFluentMethods SetAge(int newAge)
    {
      Age = newAge;
      return this;
    }
  }
}