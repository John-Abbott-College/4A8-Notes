# DateTime Nonsense (*sigh*)

**Date and Time are always prone to trouble**

Because different people have different settings on their computer...
* The datetime 'string' will be different from user to user!!!

**Dealing with DateTime**

Two choices:
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

DateTime x = DateTime.ParseExact("2011-02-27",
      "yyyy-MM-dd", CultureInfor.InvariantCulture);
Console.WriteLine(x.ToString("yyyy-MM-dd"));
Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
```

***Very Important***

Use `MM` for month as a number, if you use small `mm`, it will not work.
(*sigh*)
