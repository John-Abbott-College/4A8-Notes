# An MVP Design Flaw in HomeCalendar
These notes are going to discuss the necessity of breaking the MVP pattern for our application due to a design flaw in the HomeCalendar API.

> * The basis of the Home Calendar API was created long before we added the MVP design pattern.  
>* One of the down-sides of *agile* development is that a 'top-down' view of the project is not really given the proper amount of consideration when starting a project, because everything is based on sprints (again, this is only my opinion).

## The Context

The HomeCalendar API uses the following classes almost like data-types 

Those data types are:

* `CalendarItem`

* `CalendarItemsByMonth`

* `CalendarItemsByCategory`

* `Category`

  

## What is the MVP Related Flaw?

The way it is currently coded, every code that uses the data from the HomeCalendar API would need to include dll.

Which means when the view needs to display the data it needs to know the data-type classes described above.

So, **your View needs to have access to HomeCalendar via the `using Calendar;` code**.  This exposes all of the HomeCalendar API methods to the View, which is inconsistent with MVP.  



### What Could be Done to Remove the Flaw?

There is probably many ways to do this, but I (Sandy) would propose the following:

1) Use a different namespace for HomeCalendar data-types, isolating it from the HomeCalendar `using Calendar` code.

2) Now the presenter could have code like:

   ```csharp
   using HomeCalendarDataTypes; 
   using Calendar; // presenter still has access to home calendar's methods
   
   public class DataPresenter {
     IDataView dataView;
     
     public DataPresenter(IDataView dataView) {
       this.dataView = dataView;
     }
     
     public void SomeMethod() {
       HomeCalendar calendar = new HomeCalendar("data.db");
       List<CalendarItem> calendarItems = calendar.GetCalendarItems(null,null,false,0);
       dataView.DisplayData(calendarItems);
     }
   }
   ```

   

3) Now, the View could do something like:

   ```csharp
   using HomeCalendarDataTypes;
   // view only has access to the datatypes, not the calendar methods
   
   public class mainWindow: Window, IView {
     
   	public void DisplayData( List<CalendarItem> calendarItems) {
       // ...
     }
   }
   ```

   

## Do you need to fix it?

No.

### Why not?

Because as much as we want the experience to be `real world`, it isn't, and we don't have time for it.

* which is often happens in the `real world` where the boss says... unless it is a new feature, we don't have time for it :)



---

### Non-MVP Related Improvements

#### Consistency

* Make a new class `CalendarCategory`, located in the file `CalendarItems.cs`, with the same properties as the current `Category` object.

  > Maybe remove the `Category` object explicitly, or keep it as a wrapper ??

* Make a new class `CalendarItemsByMonthAndCategory` which is just a type `Dictionary<string,object>` 

#### Non-mutable

* I would make the properties in the class `get`, but *not* `set`.
