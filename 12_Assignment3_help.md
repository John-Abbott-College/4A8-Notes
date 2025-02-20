# Assignment 3 - Extra Info

## Reminders

* You must add `System.Data.SQLite` to both your HomeBudget project, *and* to your test project.
* If you do not understand a story properly, check in with the product owner (Helen and Sandy)

## Helper Files

On Lea, you can find

* a zip of test files.
  * Note that these test files are not complete, but have tests for Category and Categories (after changes to database).  See suggested workflow
* a test database file
  * Needed once you start converting to database storage instead of xml storage

## Suggested Workflow

1. Fix all existing bugs except for the date
   1. All current tests should pass (except for the date issues)
2. Add Database class and tests to the appropriate projects within your solution
   1. All tests should pass (except for date issues)
3. Make category & categories properties readonly.
   1. Replace TestCategory.cs
   2. All TestCategory.cs files should pass
4. Copy over all new tests to your project
   1. Temporarily change home budget constructor (see code below). 
   2. Note that this is a TEMPORARY fix
5. Modify categories to use the database
   1. Remove all references to the `List<category>` property.
   2. All tests in TestCategories.cs should pass
6. Fix the negative expense story
   1. All tests should pass (except for date issues)

**SUGGESTED END OF SPRINT 1**

7. Modify expenses to use the database
   1. Adjust tests to the new situation
   2. Your new tests must pass
9. Update HomeBudget constructor to take in one file, and one file only
   1. Adjust HomeBudget tests
   2. all tests pass
10. If not already done, remove the HomeBudget constructor that takes in zero arguments and uses a default file. 
   1. Remove all code associated with default file.
   2. Update TestHomeBudget.cs
   3. all tests pass
11. Remove any 'dead' or 'useless' code
    1. all tests pass

```csharp
public HomeBudget(String databaseFile, String expensesXMLFile, bool newDB=false)    
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
      _categories = new Categories(Database.dbConnection,newDB);
      
     // create the _expenses course
 		 _expenses = new Expenses();
     _expenses.ReadFromFile(expensesXMLFile);   
}
```

## General Info

### To Close or Not To Close the Database Connection

Many of you have been closing your database connection to get the tests to work, when in fact, that is NOT the problem.

* Do NOT close the SQLiteConnection, it slows everything down!!!!

* Do close the SQLiteDataReaderNOTE:, 

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

#### SQLiteSQLite

**IMPORTANT**

 SQLite does not support dates inside the database, only Text, so all dates in the database must be expressed as a string.

* Date formats should *always* have the year-month-date (or year/month/date) format, so that you can sort by date, and query within a range of dates

Example:

```sql
select * from expenses 
		where Date >= ‘2020-01-01’ and Date <= ‘2020-01-31’;
```

Query SQL by year/month?
* See SQL Help section below

#### C# 

**To convert a string (in the correct format) to a DateTime…**

```csharp
using System.Globalization;
DateTime date = DateTime.ParseExact(
			string, “yyyy-MM-dd”, 
			CultureInfo.InvariantCulture
);
```
To convert a DateTime to a string in the proper format:
```csharp
String str = myDateTime.ToString("yyyy-MM-dd")
```

**IMPORTANT:**
In HomeBudget, we are using 
```csharp
GetBudgetItems(DateTime? Start, DateTime? End, ...)
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
  select substr(Date, 1, 7) from expenses;
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
