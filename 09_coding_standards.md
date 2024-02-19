# Coding Standards

## Warning!

**Do NOT change existing Code base just to correct for coding standards** 

Even if the existing code base does not meet the Coding Standards listed herein, **do NOT change it.**

Changing existing code unnecessarily can…

* Introduce new bugs for no reason

* Make it more difficult to know when a bug was introduced 
  * based on what code has changed since the last release

## Helen vs Sandy

Helen and Sandy disagree on certain style guidelines (mostly commenting)

Each team may choose one style, or the other, or even a combination of the two…

BUT:

* The team must decide on what style of commenting, *etc*, they will use, and
* All members of the team must adhere to the agreed upon style
  * *i.e.* consistency!

## Indentation

Visual Studio forces standard C# indentation styles

Do not modify!

## Functions / Methods

Functions should do one thing and one thing only

## Constants, *etc*

No magic variables!

BAD: 

```csharp
for (i=0; i<10; i++) { … }
```

GOOD:	
```csharp
maxNumberOfWidgets = 10;	
for (widgetnum = 0; widgetnum < maxNumberOfWidgets; widgetnum++) {...}
```

## Line Length

Not everyone has huge monitors, and can read small fonts (sandy), so please...

* If your line is too long (over 100 columns), please wrap it to the next line

## Variable Names

The names of variables need to be meaningful.

BAD: 
```csharp
List<Categories> _cats;
```
GOOD: 

Sandy Style:
```csharp
// list of categories
List<Categories> _categories;
```
Helen Style:
```csharp
List<Categories> _listOfAllCategories;
```

## Function / Method Names

The names have to meaningful… what does the function/method do?
**Use verbs**

BAD:	

```csharp
  // noun implies that it is a property instead of a method
  List<Expenses> list() {...} 	 
  // although one could argue that ‘list’ is also a verb :)
```
GOOD:
```csharp
  // verb implies that it is a method
  List<Expenses> getList() {...} 
```

## Comments

### Sandy Style

All public functions/methods should have a proper xml header

For any code block that exceeds ½ page, there should be a comment describing what that code block is supposed to be doing

* What, not how!
* Why comment?
  * The comment describes what the code is supposed to do, 
  * if the code does not do what the comment says it is supposed to do, then there is an error (either in the comment or the code)
  * Aside: I have found many bugs while going back and validating my comments (design), 
    * sometimes it was the design didn’t make sense, or the code didn’t do what the comments said they were supposed to do.

#### Using comments as a Design

* Before you start coding, list what you need to do to achieve the results you want.
* This list can be used as the basis for your comments.
* Forces you to think a bit before you start coding

#### Comments Example (sandy)

```csharp
// ---------- assume proper xml comments here -----
// Verify that the file path and filename point to a valid file
// … if not specified, use default file path and default file name

 public static String VerifyReadFromFileName(String FilePath, String DefaultFileName)
 {

    // ---------------------------------------------------------------
    // if file path is not defined, use the default one in AppData
    // ---------------------------------------------------------------
    if (FilePath == null)
    {
        FilePath = Environment.ExpandEnvironmentVariables(
          DefaultAppData + DefaultSavePath + DefaultFileName);
    }

    // ---------------------------------------------------------------
    // does FilePath exist?
    // ---------------------------------------------------------------
    if (!File.Exists(FilePath))
    {
        throw new FileNotFoundException("ReadFromFileException: FilePath (" 
                                        + FilePath + ") does not exist");
    }

    // ----------------------------------------------------------------
    // valid path
    // ----------------------------------------------------------------
    return FilePath;

```



### Helen Style

Documenting code is useful when:

* Explaining an API for someone that will use it but is unlikely to look through code (XML comments from assignment 1).
* You want to denote something unintuitive or weird in the code.

Otherwise... 

* comments can be superfluous. They are not always maintained and can get out of date and confusing.
* “Good code is self-documenting.” Make sure your functions are small and do ‘one thing’ as much as possible. Name everything very well so what it does or represents is crystal clear.

A good read - amusing article on when comments are warranted and can get ugly:

[code comments - the good, the bad, and the ugly](https://www.freecodecamp.org/news/code-comments-the-good-the-bad-and-the-ugly-be9cc65fbf83/)

### Comments Example (Helen)

```csharp
// ---------- assume proper xml comments here -----
// Verify that the file path and filename point to a valid file
// … if not specified, use default file path and default file name
// ====================================================================
public static String GetValidReadFilePath(String ReadFilePathOrNull, 
                                          String DefaultFileName)
{
   String FilePath = GetReadFilePathOrDefault( ReadFilePathOrNull, DefaultFileName );

   ThrowIfFilePathInvalid( FilePath );

   return FilePath;
}

private static String GetReadFilePathOrDefault(String ReadFilePath, 
                                               String DefaultFileName)
{
   if (ReadFilePath == null)
      return GetDefaultSavedFilesPath() + DefaultFileName;
                 
   return ReadFilePath;
}

private static void ThrowIfFilePathInvalid( String FilePath )
{
   if (!File.Exists(FilePath))
     throw new FileNotFoundException("ReadFromFileException: FilePath (" 
                                     + FilePath + ") does not exist");
}

private static String GetDefaultSavedFilesPath()
{
   return Environment.ExpandEnvironmentVariables(DefaultAppData + DefaultSavePath);
}


```



### SQL standards

#### Parameter binding

Use parameter binding for all values inserted into an SQL statement. This ensures that values are never interpreted as SQL making your code safe and robust.

```
var time = "3 hours";
var recipe = "bread";

var cmd = new SQLiteCommand(DBConn);
cmd.CommandText = "update recipe set Name = @recipe, Time = @time";

cmd.Parameters.AddWithValue("@recipe", recipe);
cmd.Parameters.AddWithValue("@time", time);

cmd.ExecuteNonQuery();
```

#### Be specific about the columns to be retrieved

Never use SELECT * in a query. Specify the individual columns to be retrieved and their order.

BAD: 

```
SELECT * FROM Categories;
```

GOOD:

```
SELECT Id, Name FROM Categories;
```

Assuming the order of columns makes your code error prone and hard to maintain. If a change is made to the columns of a table, all query code will need to be modified to reflect the changed column order.  Moreover a column that should be accessed could be returned.

It is important to be purposeful in the selection of returned information.

