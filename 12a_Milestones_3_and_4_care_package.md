# Milestones 3 and 4 - Care Package

## Troubleshooting Tips

#### The unit tests do not see the API project code?

Is the unit tests project able to access the code? Adding a project reference ensures this.

#### Run the tests and see errors about `sqlite3` not being found?

The unit tests run the sqlite command. The executable needs to be accessible to VS. Make sure it is in your user account path.


#### Run the tests and see errors about `Database.dbConnection` being null?

Are you sure your code is setting it?


#### Tests run when you start them individually, but you see failures indicating that the database is in use running the test suite?

Make sure that the *xunit.runner.json* file is in the unit test project, alongside the *.csproj* file. Then add the following at the end of your xunit project's csproj file (right before the `</Project>` end tag, alongside the other `<ItemGroup>` elements):

```
<ItemGroup>
  <None Update="xunit.runner.json"> 
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </None>
</ItemGroup>
```

#### You checked your tables using the command line tool, but the unit tests insist that the tables are incorrect?

Remember that you cannot have spaces in the path to your solution. Pull your team's repo onto a local path with no spaces. 



## Technical reminders

* Parameterizing any data in your SQL statements prevents SQLInjection vulnerability. SQLInjection vulnerability is bad.
* Select * is bad - why? assumes a column order, exposes all columns (review the notes if this doesn't sound familiar).
* You are switching the API to use a database because the user wants more scalability. They should be able to expect the API methods (except for the `HomeCalendar` constructor) to be the same per their perspective - behavior, parameters, return values, exceptions.
* A story is only done when unit tests for it are complete and pass and the documentation of the public parts of the API are up to date.
* Dead code - comment it out and leave it around?  Remove! You have version control to be able to go see it if you need it later. Commented out code causes clutter - cluttered code is more prone to bugs. Clean code is the way to go.
* Milestone 3: all the unit tests should pass. Have a unit test where the two files are not the same? Check the XML files yourself. Is the difference the way the dates are expressed?  Look below for info on Dates to see how to fix this.
* You must add `System.Data.SQLite.Core` to both your HomeCalendar project, *and* to your test project.
## Reminders

* If you do not understand a story properly, check in with the product owner (your teacher)

## Helper Files

On Lea/Moodle, you can find

* a zip of test files
  * Note that these test files are not complete, but have tests for Category and Categories (after changes to database).  See suggested workflow.
  * includes a test database file that is needed once you start converting to database storage instead of xml storage.

## Suggested Workflow

1. Fix all existing bugs
   1. All current tests should pass
2. Add Database class and tests to the appropriate projects within your solution
   1. All tests should pass 
3. Make category & categories properties read-only.
   1. Replace `TestCategory.cs`
   2. All `TestCategory.cs` files should pass
4. Copy over all new tests to your project
   1. Temporarily change home calendar constructor (see code below). 
   2. Note that this is a TEMPORARY fix
5. Modify categories to use the database
   1. Remove all references to the `List<category>` property.
   2. All tests in `TestCategories.cs` should pass
6. Fix the availability category story
   1. All tests should pass

**SUGGESTED END OF SPRINT 1**

7. Modify events to use the database
   1. Adjust tests to the new situation
   2. Your new tests must pass
   
9. Update `HomeCalendar` constructor to take in one file, and one file only
   1. Adjust `HomeCalendar` tests
   2. all tests pass
   
9. If not already done, remove the `HomeCalendar` constructor that takes in zero arguments and uses a default file. 

   10. Remove all code associated with default file.

   11. Update `TestHomeCalendar.cs`

   12. all tests pass

11. Remove any 'dead' or 'useless' code
    1. all tests pass
    

 **SUGGESTED END OF SPRINT 2**

### **What needs to be done for the GetCalendarItems.... methods for Sprint 2:**

* `GetCalendarItems`: should query the database directly, instead of calling `List()` on the Events or Categories instances. We should not be doing SQL-like manipulations on Lists now that we have a database to work on.
* `GetCalendarItemsByMonth`/`ByCategory`: 
  * Do not call `GetCalendarItems` to figure out the groups. Use a database query to get the Month/Category groups instead.  
  * When building the `CalendarItemByMonth`/`Category` for each group however, you can call `GetCalendarItems()` with the appropriate filtering to get the `CalendarItems` list to set as the Details property of the `CalendarItemByMonth`/`Category`.

* `GetCalendarDictionaryByCategoryAndMonth`: no implementation changes needed! Calls `GetCalendarItemsByMonth` internally. Unit tests should pass.

**HomeCalendar Constructor to use for intermediate state where Categories are in the database and expenses are still in XML files**

```csharp
public HomeCalendar(String databaseFile, String eventsXMLFile, bool newDB=false)    
{
  	  // if database exists, and user doesn't want a new database, open existing DB
      if (! newDB && File.Exists(databaseFile))
			{
      		Database.existingDatabase(databaseFile);      
      }
  
  		// file did not exist, or user wants a new database, so open NEW DB
      else
      {
          Database.newDatabase(databaseFile);
          newDB = true;
      }
  
      // create the category object
      _categories = new Categories(Database.dbConnection, newDB);
      
     // create the _events course
     _events = new Events();
     _events.ReadFromFile(eventsXMLFile);   
}
```

## General Info

### To Close or Not To Close the Database Connection

Many of you have been closing your database connection to get the tests to work, when in fact, that is NOT the problem.

* Do NOT close the SQLiteConnection, it slows everything down!!!!

* Do close the SQLiteDataReader
* NOTE:
  * if you use the SQLiteDataReader in a while loop, it will close itself once there are no more records to read, but if you do NOT use a while loop, then it will remain open, preventing other accesses to the database.
* Do dispose of any SQLite command variables

### Database test file

It is possible that we will need to give you a new test database file, so BE prepared for it.

**To create a database from an sql file**

```text
> sqlite3 testDBInput.db
SQLite version 3.34.1 2021-01-20 14:10:07
Enter ".help" for usage hints.
sqlite> .read testDBInput.sql
sqlite> .quit
```

**To create an sql file (dump) from an sqlite database**

```text
> sqlite3 testDBInput.db
SQLite version 3.34.1 2021-01-20 14:10:07
Enter ".help" for usage hints.
sqlite> .output filename.sql
sqlite> .dump
sqlite> .quit
```

### Dates

**Date and Time are always prone to trouble**

Because different people have different settings on their computer...

* The datetime 'string' will be different from user to user!!!

**Dealing with DateTime**

* Always use a C# `DateTime` object
* Always read/write datetime/strings specifying which format you want to use!

**Why use strings to represent the date?**

SQLite is *light*, and does not support the storage of a datetime object...

* Which means that you need to store the date as a string...
* Which can be interpreted differently if you have a different locale setup
  In SQLite, your datetime column must be a *text* type.

**What to do?**

Always ensure you use the formatting properties of `DateTime` in C#
Example:

```csharp
using System.Globalization;

DateTime x = DateTime.ParseExact("2011-02-27", "yyyy-MM-dd H:mm:ss, CultureInfor.InvariantCulture);
// CultureInfo.InvariantCulture Ignores the computer’s regional settings. 

```

***Very Important***

Use `MM` for month as a number, if you use small `mm`, it will not work.

To convert a DateTime to a string in the proper format:

```sql
String str = myDateTime.ToString("yyyy-MM-dd H:mm:ss")
```

**IMPORTANT**

* Date formats should *always* have the year-month-date (or year/month/date) format, so that you can sort by date, and query within a range of dates

Example:

```sql
select * from events where Date >= '2020-01-01' and Date <= '2020-01-31;
```

Query SQL by year/month?
* See SQL Help section below

**IMPORTANT:**
In HomeCalendar, we are using 
```csharp
GetCalendarItems(DateTime? Start, DateTime? End, ...)
```
Because Start and End are of type `DateTime?`, the `ToString` method does not work. 

You need to create variables that are just 
```csharp
DateTime realStart = Start ?? new DateTime(1900, 1, 1);
DateTime realEnd = End ?? new DateTime(2500, 1, 1);
```

**Getting the start and end days of a month**

To get the number of days in a month

```csharp
int days = DateTime.DaysInMonth(Year, Month)
```

If you need to get the start and end date of a month, there are multiple ways to do this.

> NOTE: year and month have to be integers!

```csharp
var startDate = new DateTime(year,month,1);
var lastDay = DateTime.DaysInMonth(year,month);
var endDate = new DateTime(year,month,lastDay);
```
Or
```csharp
var startDate = new DateTime(year,month,1);
var numberOfDaysInMonth = DateTime.DaysInMonth(year,month);
var endDate = startDate.AddDays(numberOfDaysInMonth - 1);
```

## SQL Help

#### Specifying a given month in the SQLite query

You will need to get parts of the date string for various uses. For example: 

* to specify a given month, you will need to get the year-month substring of the date. 
* This is where the `substr()` SQLite method comes in. You can use it in your query directly, in the `SELECT`, `GROUP BY` and `ORDER BY` clauses, 
  Example.
  
  > NOTE: indices specified in substr() are 1-based!!
```sql
  # get the “year-month” part of the Date string.
  select substr(Date, 1, 7) from events;
```

#### Group by syntax refresher

```sql
select ownerName, count(pets), sum(ages) 
			from ownersTable 
			group by ownerID
```
#### Inner join syntax refresher

```sql
select A.ownerName, B.petName from 
			ownersTable as A 
			inner join petsTable as B 
			on A.petId == B.Id
```
OR
```sql
select A.ownerName, B.petName 
			from ownersTable as A, 
			petsTable as B 
			where A.petID == B.Id
```
#### Order by syntax refresher

```sql
select ownerName from ownersTable order by ownerID
```

## Professionalism reminders

* Your team is as strong in the code as the person that is least comfortable in the code
* A distracted teammate is frustrating. You want to work with people that are all there.
* Missing a stand up not fun for the team, they don’t know where you are at, they might be blocked by something you were working on, you are not coordinating.
* Taking long or frequent breaks affects your team – miss conversations, miss the visit by the product owner, miss team discussion 
* Is a teammate falling behind despite their best efforts? Put them in the middle
