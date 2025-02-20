# User Stories for Assignment 3



## EPIC Bug Fixes and Proper Coding

### Create stories for all failing unit tests

As a user of the Budget API,

I am able to rely on the proper functioning of this API.

**Assumptions**

**Acceptance Criteria**

* Stories are written and added to the backlog for every unit test that does not pass

### Expenses should be a negative value

As a user of the Budget API, 

I expect the displayed data (budget amount) to be consistent with what is stored externally (XML or database).

**Assumptions**

**Acceptance Criteria**

* The Expense amount stored in an expense object should be negative (if it was a purchase) and be consistent with the BudgetItem amount.

### Category class variables should be readonly

As a user of the Budget API,

I am able to rely on proper coding practices, so that I do not accidently creating a bug by changing the category ID.

**Assumptions**

**Acceptance Criteria**

* The Category class properties should be changed to now be read-only

### Expense class variables should be readonly

As a user of the Budget API,

I am able to rely on proper coding practices, so that I do not accidently creating a bug by changing the expense ID.

**Assumptions**

**Acceptance Criteria**

* The Expense class properties should be changed to now be read-only

### 

## EPIC Remove default file

### Have to specify file 

As a user of the Budget API, 

I should no longer be able to rely on a budget being saved or accessed from a default file location so that a storage location must be explicitly specified.	

**Acceptance criteria**

* Can only create a HomeBudget by specifying a file.
* The specified file will be created if it does not exist. 
* The default categories are added to the budget
* .If the file exists, the HomeBudget is read.
* Tests updated/added

## EPIC Category and Categories using database

* Categories and Category work as per stories
* Expenses work as before (no changes)
* HomeBudget constructor modified to use both XML file (expenses) and the database (categories)

### Create and connect to a new database

As a user of the Budget API,
I am able to create a new budget database to a given file so I can access and store information in a scalable, maintainable manner

.**Assumptions**

**Acceptance Criteria** (see design)

* Create the database file and connect to it
* Create the tables
* Specify the columns, primary keys, foreign keys
* Add the category types to the table (income, savings, expense and credit)
* Add the default categories (input hardcoded list to database)
* Tests updated/added

### Connect to an existing database

As a user of the Budget API, 
I am able to connect to an existing database from a given file so I can access and store information in a scalable, maintainable manner.	

**Assumptions**

* The file is a valid database

**Acceptance Criteria**

* Throw an exception if the given file does not exist.
* Tests updated/added

### Retrieve categories

As a user of the Budget API, 
I am able to retrieve categories that have been previously stored in a database so I can access them in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database
* Expenses still stored in XML file

**Acceptance Criteria**

* Method that returns a list of Category objects is updated to retrieve them from the database.
* The list should be sorted by the Id.
* Tests updated/added

### New category 

As a user of the Budget API,
I am able to add a uniquely identified category that has a description and a typeId in the database so that I can store and access it in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database
* Table exists	

**Acceptance Criteria**

* Method in Categories allows for the addition of a new Category to the database table.
* All Category object information should be stored in the database directly and not in memory.
* Table should be updated with new category
* Tests updated/added

### Update category

As a user of the Budget API,
I am able to update a category in the database so I can change it in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database

**Acceptance Criteria**

* The Category class properties should be changed to now be read-only
* A Categories method allows the API user to update the database passing in all the Category properties. 
* The Id of the Category to be updated must be provided.
* The method updates the properties (except the Id) in the database row
* Tests updated/added

### Delete category

As a user of the Budget API,
I am able to delete a category stored in a database so I can change it in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database

**Acceptance Criteria**

* Able to delete by category id
* Row deleted from database.
* Ignore if Id does not exist
* Throws exception if not allowed to delete in database (foreign key constraint).
* Tests updated/added

## EPIC Expense and Expenses using database

* Expense and Expenses work as per stories
* HomeBudget constructor modified to only use the database.

### Retrieve expenses

As a user of the Budget API,
I am able to retrieve expenses that have been previously stored in a database so I can access them in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database	

**Acceptance Criteria**

* Method that returns a list of Expense objects is updated to retrieve them from the database. 
* The list should be sorted by Id. 
* Date is returned as a DateTime object
* Tests updated/added

### New expense

As a user of the Budget API,
I am able to add a uniquely identified expense that has 

*  a date,
*  an amount,
*  a description and 
*  a categoryId
   to the database so that I can store and access it in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database
* Table exists	

**Acceptance Criteria**

* Method in Expenses allows for the addition of a new Expense to the database table.
* All Expense object information should be stored in the database directly and not in memory.
* Date specified as a DateTime object
* Tests updated/added

### Update expense

As a user of the Budget API,
I am able to update an expense in the database so I can change it in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database

**Acceptance Criteria**

* The Expense class properties should be changed to now be read-only
* An Expenses method allows the API user to update the database passing in all the Expense properties, including the *date* property
* The Id of the Expense to be updated must be provided.
* The method updates the properties (except the Id) in the database row.
* Tests updated/added

### Delete expense

As a user of the Budget API,
I am able to delete an expense stored in a database so I can change it in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database

**Acceptance Criteria**

* Able to delete by expense id in Expenses.
* Row deleted from database.
* Ignore if Id does not exist
* Throws exception if not allowed to delete in database (foreign key constraint).
* Tests updated/added

## EPIC: HomeBudget using database

As a user of the Budget API, 
I only provide the database filename only so that I can manage a HomeBudget in a streamlined, scalable, maintainable manner.	

**Assumptions**

**Acceptance Criteria**

* No longer pass in or use any XML files.

### Update GetBudgetItems

As a user of the Budget API, 
I can retrieve a customizable (date, category) list of BudgetItem objects (each include categoryId, expenseId, date, amount, expense description, category description, dynamic balance) using the database so that I can retrieve the information in a scalable, maintainable manner.

**Assumptions**

**Acceptance Criteria**

* Start and end time if unspecified default to January 1st 1900 and January 1st 2500
* Category Id only used for filtering if the filter flag is set to true. 
* No default category
* Balance is a running total of the resulting budget items.
* Should use a database query.
* List of BudgetItems should be sorted by date. 
* Tests updated/added

### Update GetBudgetItemsByMonth

As a user of the Budget API,
I can retrieve a customizable (date, categoryId) list of BudgetItemsByMonth objects (each include details - a list of BudgetItems for that month, month identifier string, total) using the database so that I can retrieve the information in a scalable, maintainable manner.

**Assumptions**

**Acceptance Criteria**

* Start and end time if unspecified default to January 1st 1900 and January 1st 2500.
* Category Id only used for filtering if the filter flag is set to true. 
* No default category.
* The total in a given BudgetItemsByMonth object is the total amount for the BudgetItems of that month.
* Tests updated/added

### Update GetBudgetItemsByCategory

As a user of the Budget API, 
I can retrieve a customizable (date, categoryId) list of BudgetItemsByCategory objects (each include the category description, details - a list of BudgetItems for that category, total) using the database so that I can retrieve the information in a scalable, maintainable manner.

**Assumptions**

**Acceptance Criteria**

* Start and end time if unspecified default to January 1st 1900 and January 1st 2500.
* Category Id only used for filtering if the filter flag is set to true. 
* No default category.
* The total in a given BudgetItemsByCategory object is the total amount for the BudgetItems of that category.
* The returned list of BudgetItemsByCategory objects should be sorted by category description, alphabetically.
* In each BudgetItemsByCategory object’s details property, the list of BudgetItems should be sorted by date. 
  *Tests updated/added

### Update GetBudgetDictionaryByCategoryAndMonth

As a user of the Budget API,
I can retrieve a customizable (date, categoryId) list of Dictionary<string,object> objects using the database so that I can retrieve the information in a scalable, maintainable manner.

**Assumptions**

* That this will just work once the GetBudgetItemsByMonth method is converted.

**Acceptance Criteria**

* Tests pass

### Error handling

As a user of the Budget API, 
I receive an exception when my actions cause a database error so I be notified when attempting invalid or failed operations.

**Assumptions**

* Connection to a valid database

**Acceptance Criteria**

* Exceptions thrown on invalid (constraints, invalid SQL,...) or failed (connectivity) operations.

# Database design

### expenses

| Keys               | Column      | Column Type |
| ------------------ | ----------- | ----------- |
| PK                 | Id          | Int         |
|                    | Date        | Text        |
|                    | Description | Text        |
|                    | Amount      | Double      |
| FK - categories Id | CategoryId  | Int         |

### categories

| Keys                  | Column      | Column Type |
| --------------------- | ----------- | ----------- |
| PK                    | Id          | Int         |
|                       | Description | Text        |
| FK - categoryTypes Id | TypeId      | Int         |

### categoryTypes

| Keys | Column      | Column Type |
| ---- | ----------- | ----------- |
| PK   | Id          | Int         |
|      | Description | Text        |

