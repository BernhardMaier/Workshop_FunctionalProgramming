namespace Fluent;

public class FluentDemo3(ITestOutputHelper testOutputHelper)
{
  [Fact]
  public void Test()
  {
    var customer = new Customer();
    
    testOutputHelper.WriteLine("Room for anything...");
    
    customer.Id = 1;
    customer.Age = 18;
    
    testOutputHelper.WriteLine($"Customer with id {customer.Id} and age {customer.Age}.");
  }
}

public class Customer
{
  public int Id { get; set; }
  public int Age { get; set; }
}

public static class CustomerExtensions
{
  public static Customer SetId(this Customer customer, int newId)
  {
    customer.Id = newId;
    return customer;
  }
  
  public static Customer SetAge(this Customer customer, int newAge)
  {
    customer.Age = newAge;
    return customer;
  }
}