# Error Handling

There are many different types of errors, and they do need to be handled differently.

* User input errors, 
  * As much as possible, handle any user inputs as soon as you receive them.  Are they entering a number, does the phone number look valid, does the email address look like an email address, etc.
* Environmental Issues -  Issues, that you the programmer, do not have control over. 
  * Your program needs not to crash, but instead to inform the user of the problem
  * Examples,
    * internet is down and you cannot access data in the cloud
    * database server is not functioning
    * missing or damaged hardware/software
* Incorrect usage of your code 
  * Your program should not crash because of others' bad programming.
  * Example: Some programmer is not reading the documents correctly and trying to get data from the database before they have connected.

## Who needs to know?

Questions to ask yourself when you are deciding how to handle any problems:

* Does the user need to know? Can they do something about it (correct their mistake, try again later)?
* How much information should the user be given 
  * For web pages, it's ok to say there is a database error, it is not ok to say "column abc does not exist", because this information may be useful for hackers
* Does the administrator need to know?
  * If a user typed in an invalid date, does the administrator need to know?
  * If a user has mistyped their password twenty times, does the administrator need to know?
  * If there is a database problem (connectivity issues for example), does the administrator need to know?

## Handling Problems

So who decides what to do when a problem is encountered?

* If you are writing *backend* code, you should NEVER print error messages (although logging them is a good idea). 
  * It is important that the *backend* code *inform* the *frontend* code immediately if there is a problem.  How much information is given to the front-end depends on the type of error
* The *frontend* (GUI / Web / Console) designers decide what to do if there is an error (continue, try again, ignore, bail out, offer choices to the user, etc)

### How to Handle Problems

Generally speaking, programmers tend to follow one of the following philosophies:

#### The code is expected to work 

*i.e* The methods that you create should handle any errors themselves.


```csharp
// method takes care of user input errors
int get_user_age () {
  int age;
	while (True) {
    Console.Write("Please enter your age: ");
    string s_age = Console.ReadLine();
    if (int.TryParse(s_age,out age)) {
      if (age > -1) {
      	return age;
      }
    }
    Console.WriteLine("You did not enter a valid age");
  }
  return 0;
}
```

```csharp
// user of method doesn't have to check for bad input
void main () {
  if (get_user_age() < 14) {
    Console.WriteLine("You are too young for this movie !");
    return;
  }
}
```



#### The code returns error codes

1) If there is an error within a `Foo` method, an exception will not be thrown.
2) The method will return a number.  If that number is zero, then there were no errors, else, the number indicates what the error is
3) It is up to the user of your code to check for errors themselves

*note, there are some variations of how this can be implemented*

```csharp
// class Foo 
class Foo {
	public enum FooError
  	{
    	NoError = 0
    	InvalidPassword = 1,
    	InvalidUsername = 2,
    	DatabaseNotConnected = 3
    };

  void connect (string connect) {
    
    // check for errors
    if (connect != "do something") {
      return InvalidPassword;
    }
    
    // ... some code ....
    
    return NoError;
  }
}
```

```csharp
// when using Foo, you must manually check for errors
using Foo;
var foo = new Foo();
if (int ierror = foo.connect("to something") != 0) 
{
  Console.WriteLine("Could not connect: "+((FooError)ierror).ToString() ); 
  return
}

```



#### The code sets error properties

1) If there is an error within a `Foo` method, an exception will not be thrown.
2) `Foo` class properties (error_number and error_message) are assigned numbers and strings to indicate any errors (error_number = 0 *always* means no error)
3) It is up to the user of your code to check for errors themselves

*note, there are some variations of how this can be implemented*

```csharp
// class Foo sets error properties
class Foo {
  public int error_number;
  public string error_message
  void connect (string connect) {
    
    // reset error information
    Foo.error_number = 0;
    Foo.error_message = "";

    // check for errors
    if (connect != "do something") {
      Foo.error_number = 1;
      Foo.error_message = "Bad connection String";
      return;
    }
    
    // ... some code ....
    
  }
}
```

```csharp
// when using Foo, you must manually check for errors
using Foo;
var foo = new Foo();
foo.connect("to something");

// verify that we were able to connect
if (Foo.error_number > 0) {
  Console.WriteLine("Could not connect: "+ Foo.error_message);
  return Foo.error_number;
}
```



#### The code throws exceptions

1. If there is an error within a `Foo` method, and exception will be thrown.  This can be a specific type of exception, or just the generic one, *but*
2. The exception error message must be clear about what caused the error
3. It is up to the user of your code to use `try/catch` blocks

```csharp
// Foo throws an exception if something bad happens
class Foo {
  void connect (string connect) {
    
    // check for errors
    if (connect != "do something") {
      throw new Exception("Bad connection String");
    }
    
    // ... some code ....
    
  }
}
```

```csharp
// if using Foo, use try/catch, and deal with the errors.
using Foo;
var foo = new Foo();
try {
	foo.connect("to something");
}
catch (Exception e) {
  Console.WriteLine("Could not connect: "+e.Message);
 }

```



# HomeCalendar Possible Errors

Technically speaking, HomeCalendar is a 'model', i.e it retrieves and saves data, that is all that it supposed to do. It is *back-end* code.



## What kind of errors?

### Data Errors

What if a user is asking to delete a category, but there are events that are linked to this category.  This would create a **FOREIGN KEY** error.

* Who needs to know? The front-end needs to know that the category could not be deleted.
* How to inform them? Throw a specific exception.

### Database Issues

Cannot connect to the database?

SQLite file not found

SQLite file is corrupted.

# Making your own specialized Exceptions

*[Microsoft documentation](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions)*

Here is just an example

```csharp
// =============================================================================
// Connection Error
// - inherits from 'Exception' class
// =============================================================================
public class ConnectionException : Exception
{
    public string ConnectString { get; } // extra info

    public ConnectionException() { }		 // standard constructor

    public ConnectionException(string message) // calls 'Exception(message)'
        : base(message) { }

    public ConnectionException(string message, string connectionString)
        : this(message)
    {
        ConnectString = connectionString;
    }
}

class NamedExample
{
	// ========================================================================
  // dummy method that can throw an ConnectionException if something
  // bad happens
  // ========================================================================
  static void Connect(String connectString)
    {
    		// some other code.
        throw new ConnectionException("this is bad", connectString);
    }

    static void Main(string[] args)
    {
        try
        {
            Connect("boo hoo");
        }
        // specifically deal with a connection string error
        catch (ConnectionException e)
        {
            Console.WriteLine(e.Message+":"+e.ConnectString);
        }
        // catches all other exceptions
        catch (Exception e)
        {
            Console.WriteLine("Unknown error:" + e.Message);
        }
    }
  |

```



