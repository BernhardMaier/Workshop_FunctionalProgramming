namespace Playground;

public class Demo(ITestOutputHelper testOutputHelper)
{
  [Fact]
  public void Test()
  {
    var result = ImprovedCustomer.Create();
    if (result.IsFailure)
      testOutputHelper.WriteLine(result.Error);
  }
}

public class Customer
{
  public int Id { get; set; }
  public int Age { get; set; }
  public Maybe<string> Pet { get; private set; }
}

public class ImprovedCustomer
{
  private ImprovedCustomer() =>
    Id = Guid.NewGuid();

  public Guid Id { get; private set; }
  public int Age { get; private set; }
  public Maybe<string> Pet { get; private set; } = Maybe<string>.None;

  // public static Result<ImprovedCustomer> Create(int age)
  // {
  //   var improvedCustomer = new ImprovedCustomer();
  //   
  //   var updateAgeResult = improvedCustomer.SetAge(age);
  //   if (updateAgeResult.IsFailure)
  //     return updateAgeResult.ConvertFailure<ImprovedCustomer>();
  //   
  //   return Result.Success(improvedCustomer);
  // }

  public static Result<ImprovedCustomer> Create() =>
    Result.Success(18)
      .Bind(defaultAge => Create(defaultAge));
  
  public static Result<ImprovedCustomer> Create(int age) =>
    Result.Success(new ImprovedCustomer())
      .Check(newCustomer => Result.Combine("\n",
        newCustomer.SetAge(age),
        newCustomer.SetAge(age)));

  // public Result SetAge(int newAge)
  // {
  //   if (newAge < 0)
  //     return Result.Failure("Age must not be negative!");
  //
  //   Age = newAge;
  //   
  //   return Result.Success();
  // }
  
  public Result SetAge(int newAge) =>
    Result.Success()
      .Ensure(() => newAge >= 0, "Age must not be negative!")
      .MapTry(() => newAge / 0)
      .Tap(dividedAge => Age = dividedAge);

  // public Result ChangePet(string? pet)
  // {
  //   if (string.IsNullOrWhiteSpace(pet))
  //   {
  //     return Result.Failure("Pet must not be empty!");
  //   }
  //   
  //   Pet = Maybe<string>.From(pet);
  //   
  //   return Result.Success();
  // }

  public Result ChangePet(string? pet) =>
    Result.Success(pet)
      .EnsureNotNull("Pet must not be null!")
      .Ensure(newPet => newPet.Trim().Length > 0, "Pet must not be empty!")
      .Tap(newPet => Pet = Maybe<string>.From(newPet));

  // public Result RemovePet()
  // {
  //   Pet = Maybe<string>.None;
  //   
  //   return Result.Success();
  // }
  
  public Result RemovePet() =>
    Result.Success()
      .Tap(() => Pet = Maybe<string>.None);
}