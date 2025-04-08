# An MVP Design Flaw in HomeBudget

These notes are going to discuss the necessity of breaking the MVP pattern for our application due to a design flaw in the HomeBudget API.

> Sandy's thoughts about this.
>
> * It was my original code that formed the basis of the Home Budget API, and it was created long before I understood the MVP design pattern.  
> * One of the down-sides of *agile* development is that a 'top-down' view of the project is not really given the proper amount of consideration when starting a project, because everything is based on sprints (again, this is only my opinion).

## The Context

The HomeBudget API uses the following classes almost like data-types 

> in C++ or C we could explicitly define a data type, but C# uses classes or structs instead)

Those data types are:

* `BudgetItem`

* `BydgetItemsByMonth`

* `BudgetItemsByCategory`

  > I used to have another class `BudgetItemsByMonthAndCategory` which required some really funky dynamic class stuff, but I removed it because I didn't want to have to explain it.  Instead, I used a dictionary.

* `Category`

  

### Non-MVP Related Improvements

#### Consistency

* Make a new class `BudgetCategory`, located in the file BudgetItems.cs, with the same properties as the current `Category` object.

  > Maybe remove the `Category` object explicitly, or keep it as a wrapper ??

* Make a new class `BudgetItemsByMonthAndCategory` which is just a type `Dictionary<string,object>` 

#### Non-mutable

* I would make the properties in the class `get`, but *not* `set`.



## What is the MVP Related Flaw?

The way it is currently coded, even if the above improvements were implemented, every code that uses the data from the HomeBudget API would need to include dll.

Which means when the view needs to display the data it needs to know the data-type classes described above.

So, **your View needs to have access to HomeBudget via the `using Budget;` code**.  This exposes all of the HomeBudget API methods to the View, which is inconsistent with MVP.  



### What Could be Done to Remove the Flaw?

There is probably many ways to do this, but I (Sandy) would propose the following:

1) Use a different namespace for HomeBudget data-types, isolating it from the HomeBudget `using Budget` code.

2) Now the presenter could have code like:

   ```csharp
   using HomeBudgetDataTypes; 
   using Budget; // presenter still has access to home budget's methods
   
   public class DataPresenter {
     IDataView dataView;
     
     public DataPresenter(IDataView dataView) {
       this.view = view;
     }
     
     public void SomeMethod() {
       HomeBudget budget = new HomeBudget("data.db");
       list<BudgetItem> budgetItems = budget.GetBudgetItems(null,null,false,0);
       dataView.DisplayData(budgetItems);
     }
   }
   ```

   

3) Now, the View could do something like:

   ```csharp
   using HomeBudgetDataTypes;
   // view only has access to the datatypes, not the budget methods
   
   public class mainWindow: Window, IView {
     
   	public void DisplayData( List<BudgetItem> budgetItems) {
       // ...
     }
   }
   ```

   

## Do you need to fix it?

No.

### Why not?

Because as much as we want the experience to be `real world`, it isn't, and we don't have time for it.

* which is often happens in the `real world` where the boss says... unless it is a new feature, we don't have time for it :)

Because I haven't really had the time to review this design, and it also might be flawed. 

