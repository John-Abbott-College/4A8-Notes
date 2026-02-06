# Unit testing 

reference: https://stackify.com

#### Unit test

The testing of a small, isolated unit of code. A unit is often a method.

#### What a unit test does NOT test

- Multiple components, the whole system, end to end
- The interaction between parts of your application
- Things that could go wrong if your system is not well set up (environment)

#### Use a Unit test Framework

Using a framework to write and run unit tests make sense - you do not want to have to write all that functionality yourself! 

 We are using XUnit which gives us ways to specify when a function is a test ([Fact]) and an interface for running and tracking tests. 



#### Naming your unit test method

Classes are a useful way to organize unit tests. Name your class to reflect the class it contains unit tests for.

TestMyClass.cs 

The unit tests themselves are methods in the class. As always, use a very descriptive name. A good template for a unit test method name is to specify what is tested and the expected result:

Adding_2_And_4_Should_Return_6



#### Parts of a unit test

You are testing a hypothesis.

Arrange - setup the necessary variables and values

Act - run the method you are testing

Assert - check that your hypothesis is correct



#### What should you test?

That the code works as expected. You want to test the typical use of the code, atypical uses of the code, as well as the expected functioning in edge case conditions.

Adding a test when you fix a bug that comes up is a good idea. It is something that was missed, having a test makes it hard to miss in the future. Fixes often get inadvertently reverted (merged conflict, bringing in old code).



#### Using the Assert class

Assert.ConditionThatMustBeMet

For example, Assert.Equal, Assert.False

these methods throw exceptions if the condition is not met.



#### Private, helper methods

It is perfectly ok to add private methods to your test class. You would not specify these as [Fact] methods.

You could reuse code to Arrange things or even in the Assert part. 



#### Make your test independent

The framework you are using should be able to run your tests in any order. Often, they are run in parallel.



#### Add them to your build

Have them be run automatically on every commit to master  MORE ON THIS LATER!
