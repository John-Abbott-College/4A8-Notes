# Application Testing and Code Coverage

Testing is crucial to verifying that your code base works as intended and that it is robust. 

# Unit testing

### What is a Unit Test?

The testing of a small, isolated unit of code. 

* Narrow scope
* Testing an individual unit of code, ideally the smallest testable piece (method or class). Often, the unit is a method.
* No dependencies on any outside systems. You are testing the internal workings of this unit. You do not care how it interacts with anything else.

### Purpose

Make the contract of code explicit. This allows you to verify that your code does what you want it to do.

Also helps:

- Find bugs before they get out into production.
- Make you consciously consider edge cases and various scenarios.
- Ensure that future changes do not inadvertently break the contract of the code.

### What a unit test does NOT test

1. Multiple components, the whole system, end to end.
2. The interaction between parts of your application.
3. Things that could go wrong if your system is not well set up (environment).

### Use a Unit test Framework

Using a framework to write and run unit tests make sense. You do not want to have to write all that functionality yourself! 

What functionality does the unit test framework usually provide?

- a way to run unit tests
- the ability to see which unit tests passed and failed
- the stack trace and failed test info for failed tests.

We are using **XUnit** which gives us ways to specify when a function is a test `[Fact]` and an interface for running and tracking tests. 



### Organizing and naming your unit test methods

#### Unit test class name

**Classes** are a useful way to organize unit tests.

Name your class to reflect the class it contains unit tests for. example: *TestMyClass.cs*



#### Unit test method name

The unit tests themselves are methods in the class. 

As always, use a very descriptive name. Good test names helps make it clear what is tested.  They come in very handy when a report of failed tests is seen - the possible problem can be clearer faster.

A good template for a unit test method name is to specify what is tested and the expected result. Example: `Add_2And4_ShouldReturn6`

`Add_TwoNegativeNumbers_ShouldReturnANegativeNumber`



### Parts of a unit test

You are testing a hypothesis.

1. **Arrange** - setup the necessary variables and values.

2. **Act** - run the method you are testing.

3. **Assert** - check that your hypothesis is correct.

   

### What should you test?

You want to test:

1. typical use of the code
2. atypical uses of the code
3. expected functioning in edge case conditions.

Adding a test when you fix a bug that comes up is a good idea. It is something that was missed, having a test makes it hard to miss in the future. 

Fixes often get inadvertently reverted (merged conflict, bringing in old code).



### Using the Assert class

`Assert.ConditionThatMustBeMet( parametersList )`

These methods throw exceptions if the condition is not met.



For example: 

- `Assert.Equal` fails (throws an exception that causes the unit test to fail) if the given parameters are not equal. 

- `Assert.False` fails (throws an exception that causes the unit test to fail) if the given parameter does not evaluate to False (if it is True). 

- Will this assert throw an exception?

  

  ```C#
          List<string> listActual = new List<string> { "one", "two", "three" };
          listActual.RemoveAt(2);
  
          Assert.DoesNotContain<string>("three", listActual);
  ```



### Private, helper methods

It is perfectly ok to add private methods to your test class. You would **not** specify these as `[Fact]` methods.

You could reuse code to Arrange things or even in the Assert part. 



### Make your test independent

The framework you are using should be able to run your tests in any order. Often, they are run in parallel.



### Add them to your build

Have them be run automatically on every commit to master  MORE ON THIS LATER!




## Integration testing

- Normally done once there is assurance that each individual component works properly - i.e. they are each well unit tested.

- Testing the interaction between components of the system.

  - You are verifying that your code behaves nicely with other code it is using.

- Test environment resembles production.	

  

  Integration test: you test with the actual instance of the database, test against the actual server. 

  ​                                                                     VS	

  Unit test: you mock the other components to only test the behavior of the one unit.



## Regression testing

- Verify if new bugs were introduced in the system after it was changed. 

- It is good practice to add regression tests for bug fixes that feel unsteady (easily reintroduced).

- You run your regression tests to make sure all existing functionality is still as expected.

  

  Wikipedia - good description of ways changes cause unexpected bugs:

  *“As software is updated or changed, or reused on a modified target, emergence of new faults and/or re-emergence of old faults is quite common. Sometimes re-emergence occurs because a fix gets lost through poor [revision control](https://en.wikipedia.org/wiki/Revision_control) practices (or simple [human error](https://en.wikipedia.org/wiki/Human_error) in revision control). Often, a fix for a problem will be "[fragile](https://en.wikipedia.org/wiki/Software_brittleness)" in that it fixes the problem in the narrow case where it was first observed but not in more general cases which may arise over the lifetime of the software. Frequently, a fix for a problem in one area inadvertently causes a [software bug](https://en.wikipedia.org/wiki/Software_bug) in another area. Finally, it may happen that, when some feature is redesigned, some of the same mistakes that were made in the original implementation of the feature are made in the redesign.”*

  Note: All this testing is increasingly automated. 



## Code Coverage

The degree to which the source code of a program is executed when unit tests are run.

Depending on the unit testing framework used, metrics could be provided to indicate which functions are run, which statements are run, and which lines are run by the unit tests. 

Information on which conditions or branches of control statements are executed could also be provided (in if and case statements, for example).



### Code coverage in Visual Studio Enterprise 

> code coverage functionality is not provided in base VS

After performing a run of your unit tests, you could trigger a code coverage analysis run (Test > Analyze Code Coverage for All Tests):

![image-CodeCoverageTrigger](.\Images\CodeCoverageTrigger.JPG)





The code coverage results will appear in a tab:

![image-CodeCoverageResults](.\Images\CodeCoverageResults.JPG)



An interesting metric is the % of lines of code that are executed. 

You may need to add this column to your Code Coverage Results View.

![image-CodeCoverageAddColumnMenu](.\Images\CodeCoverageAddColumnMenu.JPG)



![image-CodeCoverage_percent_Column](.\Images\CodeCoverage_percent_Column.JPG)



At many companies, maintaining a minimum code coverage % is required. In fact, some teams set up their systems to block commits automatically if they lower the current % covered by the unit tests. 



!! **<u>Careful</u> !!**

Code coverage does NOT guarantee full testing or good code.

Remember, just because a line of code is considered covered with respect to code coverage, does not mean that it has been fully tested, it may not have been run in all possible code paths or situations that should be tested.



Consider the following method: 

```C#
public float getFuelPerKilometerCorrectedForTemperature( float litersOfFuel, 
                                                         float kilometersTravelled, 
                                                         float temperatureInCelsius )
{
    if ( litersOfFuel > 400 || temperatureInCelsius < -40 )
    {
        throw new Exception( "this makes no sense!" );
    }

    return ( litersOfFuel / kilometersTravelled ) * ( temperatureInCelsius / 32 );
}
```

And the unit test that tests it:

```C#
[Fact]
public void Test_getFuelPerKilometerCorrectedForTemperature()
{
	//Arrange
	FuelCalculator fuelCalculator = new FuelCalculator();

    float litersOfFuel = 20;
    float kilometersTravelled = 4;
    float temperatureInCelsius = 30;

    //Act
    float fuelPerKilometer =         	
    	fuelCalculator.getFuelPerKilometerCorrectedForTemperature( litersOfFuel,
    															   kilometersTravelled,
                                                                   temperatureInCelsius);

    //Assert
    Assert.AreEqual(4.6875, fuelPerKilometer);
}
```

The current unit tests are inadequate. The code coverage analysis shows 50% coverage:

![image-CodeCoverage_method_50percent](.\Images\CodeCoverage_method_50percent.JPG)



Adding the following test, brings code coverage to 100%!

```C#
[Fact]
public void Test_getFuelPerKilometerCorrectedForTemperature_litersTooBig_exceptionExpected()
{
    //Arrange
    FuelCalculator fuelCalculator = new FuelCalculator();

    float litersOfFuel = 500;
    float kilometersTravelled = 4;
    float temperatureInCelsius = 30;

    //Act
    try
    {
       float fuelPerKilometer = 	
           fuelCalculator.getFuelPerKilometerCorrectedForTemperature(litersOfFuel,
                                                                     kilometersTravelled,
                                                                     temperatureInCelsius);
    }
    catch
    {
    	Assert.IsTrue( true, "Liters beyond maximum threw exception");
    }
}
```



![image-CodeCoverage_method_100percent](.\Images\CodeCoverage_method_100percent.JPG)





This is misleading!

The tests are not testing all the logic! For example, they do not ensure that:

- an exception is thrown when the temperature is too small (control statement alternate flow)
- that edge cases are handled - what if the km travelled is 0?

Additionally, code quality is not ensured:

- the public method is not documented
- naming conventions could have not been followed (they are here)



It is your responsibility to make sure that your code is properly tested in unit tests by adding tests that test:

- all possible logic flows in the expected use of the method
- all possible cases where things could go wrong: edge cases
- intentional misuses of your method (security risks)



#### Removing code coverage highlighting

 To remove the code coverage highlighting in the code, select the **X** in the Code Coverage Results tab toolbar:

![image-CodeCoverage_removeHighlight](.\Images\CodeCoverage_removeHighlight.JPG)



## Reference

https://stackify.com



# 🧩🧩Lab 1 - Writing good unit tests



Activity using the `TestMathWhiz` unit test class:

1. Set up your solution:

   1. Create a C# ConsoleApp project and add `MathWhiz.cs`to it.  

   2. Create an xUnit project in the same solution. Add `TestMathWhiz.cs` to it. 

   3. Make the xUnit project aware of the ConsoleApp project. Make any namespace or using statement changes, as required.

      

2. Fix up the unit test class!

   Look over the unit tests for the Multiply method and correct any issues you identify by verifying that:

   - All methods are tested, including constructors (explicit ones if there are any, the default one otherwise)

   - Unit test guidelines are followed:

     - each test should test a **single** scenario

     - the unit test should be well named: `FunctionTested_scenarioTested_expectedResult`
     - test out that **exceptions** are thrown when expected

     - when your method's contract explicitly does not throw an exception for a special scenario, test that no exception is thrown.

     - **code coverage** should be as complete as possible.

     - unit test code is still code!

       - all variables within the unit test code should be well named

       - move any duplicated code into private methods to avoid code duplication

         

3. After your unit tests are finalized, for each one, identify the 3 sections, 

   ```C#
   //Arrange
   
   //Act
   
   //Assert
   ```

​	

​	

# 🧩🧩Lab 2 - Test Driven Development (TDD)



## What is it? 

The 'contract' of your method is of the utmost importance.

In TDD, you write out the unit tests first, so that you consider all the details of your functionality without being influenced by your chosen implementation.

The tests should consider all the important scenarios:

- What is the typical case? 
- What other flavours of a usual run are there? 
- What are all the edge cases - what should happen in those cases? 
- Are there any exceptions thrown?



## How does TDD work?  

- **Do not code** out ANY of the method itself!
- Specify the **contract** of your function using unit tests as a first step. 
- Once all the unit tests are done, start coding your function to make your unit tests run. 
- Continue developing your function until your unit tests all pass.
- Make sure you have full (or as full as possible) code coverage.  Add tests as needed.  Make sure they fail first.



## Try it out!

#### Write the tests

Write all the unit tests for a new method for the  `MathWhiz` class that will be called `DividePositiveNumbers`.  DO NOT code the method.

In your tests, you should enforce the following contract details of the future `DividePositiveNumbers` method:

- it will accept two integers, the number to be divided and the divisor.
- if a divisor of 0 is passed in, an ArgumentException should be thrown indicating that Division by zero is not permitted.
- the exception prefix should be added to the beginning of the thrown exception message with a space in between.
- if either of the passed in values are negative, 0 should be returned.
- If there are no problematic inputs, the quotient should be returned.

As usual be mindful of the unit test guidelines (see Lab 1). Think of a broad range of scenario categories.

Remember! Full code coverage does not guarantee complete logic testing, make sure you consider all the relevant scenarios!



#### Write the method

Once all the unit tests are coded, start writing the  `DividePositiveNumbers` method to the `MathWhiz` class.  

Start by making the method with an empty body (does nothing). Run a unit test to see it fail, then implement the contract detail in the method to get the test to pass. Keep going until all your tests pass.



#### Verify

Did you miss any test scenarios?  Add them.

Check the code coverage of your method.  Are there untested lines?  Add tests as needed.









