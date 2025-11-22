# SQL – Data query language



## What is SQL?

**Structured Query Language**, **SQL**, is a standardized language used to manage and manipulate relational databases. 

SQL is primarily a **query language** designed for **managing** and **manipulating** **data** in **relational** databases.

It is **not** **a full-fledged programming language** like Python or C#. However, you can use SQL to write scripts or procedures that perform complex operations within a database.

## What can I do with SQL?

SQL allows users to perform tasks such as:

- **Querying** data: Retrieving specific data from one or more tables using commands like **SELECT**.
- **Inserting** data: Adding new records to a database using commands like **INSERT**.
- **Updating** data: Modifying existing records in a database using commands like **UPDATE.**
- **Deleting** data: Removing records from a database using commands like **DELETE**.
- **Creating** and **modifying** database structures: Creating new tables, altering existing ones, and defining relationships between them using commands like **CREATE**, **ALTER**, and **DROP**.

## Components of SQL

**SQL commands** are keywords that tell the database what action to perform. These commands perform various database operations, such as creating tables, inserting data, and querying information and belongs to a component of the SQL language.

### **DDL** (Data Definition Language): 
Consists of SQL commands used to **create**, **modify**, and **delete database** structures. 

- **CREATE**: Create objects in the database.

- **ALTER**: Alter the structure of a table in a database.

- **DROP**: Delete objects from the database.

- **TRUNCATE**: Remove all records from a table. All spaces allocated for the records are also removed.

### **DML** (Data Manipulation Language): 
Consists of SQL commands that allow **changing** data within the database.
- **INSERT** : Insert data into a table.

- **UPDATE** : Update existing data within a table.

- **DELETE**: Delete all records from a table.

### **DQL** (Data Query Language):
Consists of SQL commands that allow **getting** data from the database and imposing **ordering** upon it.
- **SELECT**: Retrieve data from the database.

### Table Structure
Tables have rows and columns.

- Each **row** represents a **single** **instance** of Course **entity**. i.e a single course. Rows are also known as **records**.
- Each **column** represents a **specific** **property** or **attribute** of a record.

```
Building

| Id | Name      |
| -- | --------- |
| 1  | AME       |
| 2  | Hochelaga |
| 3  | Penfield  |
| 4  | Herzberg  |
| 5  | Other     |

```

The above Building table has 5 rows and 2 columns.

### 🧠 Matching Game 

Given the table of buildings above, go to Moodle and complete the H5P activity *Components of SQL* in the *Introduction to Databases* section. You may attempt it as many times as you like.

## What does a DQL query look like?

The basic SQL query has a **S F W** format

**SELECT** . . . indicates which attributes should appear in the result

**FROM** . . . gives the relation(s) on which the query should be applied

**WHERE** . . . is a Boolean expression or condition that restricts the query

>
> The result of the query is itself a **relation/table**
>
> This resulting relation is **unnamed**

Let's Look at some examples:

---

### Example 1

Find all information about courses stored in the database:

```
Course

| Number   | Name            | Description     |
| -------- | --------------- | --------------- |
| Comp 352 | Data Structures | Introduction    |
| Comp 353 | Databases       | DBMS            |
```

Query:

```sql
SELECT * 
FROM Course
```

Result:

```

| Number   | Name            | Description     |
| -------- | --------------- | --------------- |
| Comp 352 | Data Structures | Introduction to |
| Comp 353 | Databases       | DBMS            |

```

> Using * (an **asterisk**) is a way to indicate that the result should include **all the attributes** in the relations/tables 
>
> The **WHERE** clause is **optional**

---

### Example 2

Find the names of courses stored in the database

```
Course

| Number   | Name            | Description     |
| -------- | --------------- | --------------- |
| Comp 352 | Data Structures | Introduction    |
| Comp 353 | Databases       | DBMS            |
```

Query:

```sql
SELECT Name
FROM Course
```

Result:

```
| Name            |
| --------------- |
| Data Structures |
| Databases       |

```

---

## The WHERE clause

The expressions that follow **WHERE** are **conditions**

- **Comparison operators** { =, <>, <, >, <=, >= }

- The values that may be compared include **constants** and **attributes** of the relation(s) mentioned in FROM clause 

  ​	Example: ID=111, Student.ID = Course.ID

- We may also apply the usual arithmetic operators, + ,- ,* ,/ etc. to numeric values before comparing them 

  ​	Example: (year -1930) * (year -1930) < 100

The **result** of a comparison is a **Boolean** value TRUE or FALSE

Boolean expressions **can be combined** by the logical operators AND, OR, and NOT 

---

### Example 3

Find the ids of students that have a Gpa > 3.5

```
Student

| Id   | FirstName | LastName | Gpa  | Address      |
| ---- | --------- | -------- | ---- | ------------ |
| 111  | Joe       | Smith    | 4.0  | 45 Pine ave. |
| 222  | Sue       | Brown    | 3.1  | 71 Main st.  |
| 333  | Ann       | Jones    | 3.7  | 39 Bay st.   |

```

Query:

```sql
SELECT Id
FROM Student
WHERE Gpa > 3.5
```

Result:

```
| Id   |
| ---- |
| 111  |
| 333  |
```

---

### Example 4

Find the Id and last name of every student with first name Joe that has a Gpa > 3 

```
Student

| Id   | FirstName | LastName | Gpa  | Address      |
| ---- | --------- | -------- | ---- | ------------ |
| 111  | Joe       | Smith    | 4.0  | 45 Pine ave. |
| 222  | Sue       | Brown    | 3.1  | 71 Main st.  |
| 333  | Ann       | Jones    | 3.7  | 39 Bay st.   |

```

Query:

```sql
SELECT Id, LastName 
FROM Student 
WHERE FirstName= 'Joe' AND Gpa > 3
```

Result:

```
| Id   | LastName |
| ---- | -------- |
| 111  | Smith    |

```

---

### Example 5

Find the Id and last name of students with first name Sue or that have a Gpa > 3.3



```
Student

| Id   | FirstName | LastName | Gpa  | Address      |
| ---- | --------- | -------- | ---- | ------------ |
| 111  | Joe       | Smith    | 4.0  | 45 Pine ave. |
| 222  | Sue       | Brown    | 3.1  | 71 Main st.  |
| 333  | Ann       | Jones    | 3.7  | 39 Bay st.   |

```

Query:

```sql
SELECT Id, LastName 
FROM Student 
WHERE FirstName= 'Sue' OR Gpa > 3.3
```

Result:

```
| Id   | LastName |
| ---- | -------- |
| 111  | Smith    |
| 222  | Brown    |
| 333  | Jones    |
```

---

### 🧠Exercise

```
Student

| Id   | FirstName | LastName | Gpa  | Address      |
| ---- | --------- | -------- | ---- | ------------ |
| 111  | Joe       | Smith    | 4.0  | 45 Pine ave. |
| 222  | Sue       | Brown    | 3.1  | 71 Main st.  |
| 333  | Ann       | Jones    | 3.7  | 39 Bay st.   |

```
You want the list of last names of any students that have a Gpa above 3.3 AND a first name of Sue

Query:  what will the query be?



Result: What do you think the result will be?

1. An error

2. Sue's Gpa will be increased to 3.3

3. An empty table

4. A message indicating that there are no results




## Case insensitivity

SQL is case insensitive

So, keyword CREATE maybe written as:

CREATE , Create or CrEaTE

Only in strings, SQL distinguishes between uppercase and the lowercase (Some databases (Oracle, IBM DB2, PostgreSQL, etc.) will perform case sensitive string comparisons by default, others case insensitive (SQL Server, MySQL, SQLite))

By default, string comparisons in SQL Server are case insensitive. Case sensitivity could be achieved through the use of collation.

## References

- https://www.sqlservertutorial.net/sql-server-basics/sql-server-data-types/
- [https://docs.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-](https://docs.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver15)[sql?view=sql-server-ver15](https://docs.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver15)
- https://www.sqlshack.com/an-overview-of-sql-server-data-types/



## Lab 2: DQL

🎯Objectives: Practice Data Query Language

---

### Setup

1. Open SQL Server Management Studio.

2. In Server type select **Database Engine**.

3. In Server name place **`(localdb)\MSSQLLocalDB`**.

4. In Authentication select **Windows Authentication**

5. Open `Company.sql` script in SQL Server Management Studio.

6. Select `CREATE DATABASE Company;` statement and execute by clicking on `Execute` button or `F5`.

   ![](.\images\execute.jpg)

7. Select `USE Company;` statement and execute it.

8. Select the SQL Statement that creates the `Employee` Table and execute it.

   > We will learn more about this soon

9. Select the SQL Statements that add data to the  `Employee` Table and execute it.

   > We will learn more about this soon

10. Open the `Employee` table or execute `SELECT * from Employee;` statement to have a look at the data and the fields of the table.

   > You could also use the UI as shown below
   >
   > ![](.\images\TableDetails.jpg)


### Write DQL statements that:

1. Display all information about employees who are not on a pension plan. Show all fields.

2. Display the full name of employees who do not have a bonus.

3. Display the full name and hired date of employees in the Sales (SL) Department.

4. Display the full name and salary of employees in the Marketing (MK) Department with a salary of $40,000 or over.

5. Display the full name, salary, and bonus of employees with a salary above $40,000 or a bonus above $5000, or both.

6. Display all information about employees with a salary in the range of $40,000 to $50,000 inclusive.


## Extra Exercises

1. [Play the SELECT card game](https://sqlzoo.net/40289347/)

