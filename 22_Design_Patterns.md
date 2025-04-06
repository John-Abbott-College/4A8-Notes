#  Patterns

> This book is an absolute *must* for software developers:
>
> [Design Patterns](https://www.amazon.ca/Design-Patterns-Elements-Reusable-Object-Oriented/dp/0201633612) by 'the gang of four'

## What is a Design Pattern?

[wikipedia source](https://en.wikipedia.org/wiki/Design_Patterns)

A **software design pattern** is a general, *reusable* solution to a commonly occurring problem within a given context in *software design*. 

It is a description or template for how to solve a problem that can be used in many different situations. 

Are formalized *best practices* that the programmer can use to solve common problems when designing an application or system.

> ... "Each pattern describes a problem which occurs over and over again in our environment, and then describes the core of the solution to each problem, in such a way that you can use this solution a million times over, without ever doing it the same way twice" [AIS+77, page *x*]
>
> **Design Patterns: Elements of Reusable Object-Oriented Software** Erich Gamma, Richard Helm, Ralph Johnson, John Vlissades, *Addison-Wesley Professional; 1st edition (Oct. 31 1994)*, page 2,

## Design Pattern Examples

### Singleton

Intent:

*  `Singleton` is a creational design pattern that lets you ensure that a class has only one instance, while providing a global access point to this instance.

Requirements:

* Ensure that a class has only a single instance
* Provide a global access point to that instance

Pattern:

* Make the default constructor *private*
* Create a static method that acts as a constructor
* Call the constructor, and save the object in a static field

> An example would be what we have done for the `Database` class in `HomeBudget`, but with an instance of Database itself.

### Observer

[wikipedia](https://en.wikipedia.org/wiki/Observer_pattern#:~:text=The%20observer%20pattern%20is%20a,calling%20one%20of%20their%20methods.)

The Observer pattern addresses the following problems:

- A one-to-many dependency between objects should be defined without making the objects tightly coupled.
- It should be ensured that when one object changes state, an open-ended number of dependent objects are updated automatically.
- It should be possible that one object can notify an open-ended number of other objects.

It is mainly used for implementing distributed event handling systems, in "event driven" software. 

#### Complex Example (C#)

Using `IObservable` interface ([.NET documentation](https://docs.microsoft.com/en-us/dotnet/api/system.iobservable-1?view=net-6.0))

#### Simple Example (C#)

This is the class that will be broadcasting the information. It Requires a `Subscribe` method that takes in a `Calendar` object.
```csharp
class Broadcaster {
  
  private List<Calendar> Calendars;
  
  // Constructor
  public Broadcaster() { 
    Calendars = new List<Calendar>();
  }
  
  // Subscribe
  public void Subscribe(Calendar Calendar) {
    Calendars.Add(Calendar);
  }

  // Tell everyone who is interested about the 'Special Event'
  public void Broadcast( SpecialEvent e ) {
    foreach (var Calendar in Calendars) { 
      Calendar.update(e); 
    }
  }
}
```
This is a `Calendar`. It is an *observer*, meaning that once subscribed to the `Broadcaster`, it waits for *updates* from the `Broadcaster`. Requires an `update` method that takes a `SpecialEvent` object.
```csharp
class Calendar {
  private String _name;
  public Calendar(String name) { _name = name; }
  
  // Waits for the someone else to tell it to add the 
  // special event to our calendar
  public void update(SpecialEvent specialEvent ) {
    
  		Console.WriteLine($"{_name} has been notified of " +  
                    "{specialEvent.Description} by object " + 	
                        specialEvent.Sender.GetType());
    
      UpdateCalendar( specialEvent )
  }
  
  // UpdateCalendar(...)
}
```
This is what we are going to broadcasting 
```csharp
public struct SpecialEvent {
  Object _sender;
  String _description;
  public Object Sender { get { return _sender; } }
  public String Description { get { return _description; } }

  public SpecialEvent(Object sender, String descr) {
    _sender = sender;
    _description = descr;
  }
}
```

How to use the above
```csharp
static void Main(string[] args) {
  var sandyCalendar = new Calendar("sandy");
  var bobCalendar = new Calendar("bob");
  var betteCalendar = new Calendar("bette");

  var EventsCoordinator = new Broadcaster();
  EventsCoordinator.Subscribe(sandyCalendar);
  EventsCoordinator.Subscribe(betteCalendar);
  EventsCoordinator.Subscribe(bobCalendar);

  // Let everyone know about the birthday party!
  EventsCoordinator.BroadcastEvent(
    new SpecialEvent(EventsCoordinator, "Birthday Party!!")
  );
}
```

#### Notes
* The above example is missing error checking and *un-subscribing*
* The Calendar and the Broadcaster know nothing of each other (loose coupling) 

