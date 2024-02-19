# User Stories for Milestones 3 and 4



## EPIC Bug Fixes and Proper Coding

### Create stories for any failing unit tests

As a user of the Calendar API,

I am able to rely on the proper functioning of this API.

**Assumptions**

**Acceptance Criteria**

* Stories are written and added to the backlog for every unit test that does not pass

### Events should be a negative value

As a user of the Calendar API, 

I expect the displayed busy time to be consistent with the fact that availability events do not block time.

**Assumptions**

**Acceptance Criteria**

* The busytime amounts in a CalendarItem* object should only reflect be consistent with the CalendarItem amount.

### Category class variables should be readonly

As a user of the Calendar API,

I am able to rely on proper coding practices, so that I do not accidently creating a bug by changing the category ID.

**Assumptions**

**Acceptance Criteria**

* The Category class properties should be changed to now be read-only

### Event class variables should be readonly

As a user of the Calendar API,

I am able to rely on proper coding practices, so that I do not accidently creating a bug by changing the event ID.

**Assumptions**

**Acceptance Criteria**

* The Event class properties should be changed to now be read-only

### 

## EPIC Remove default file

### Have to specify file 

As a user of the Calendar API, 

I should no longer be able to rely on a calendar being saved or accessed from a default file location so that a storage location must be explicitly specified.	

**Acceptance criteria**

* Can only create a HomeCalendar by specifying a file.
* The specified file will be created if it does not exist. 
* The default categories are added to the calendar
* .If the file exists, the HomeCalendar is read.
* Tests updated/added

## EPIC Category and Categories using database

* Categories and Category work as per stories
* Events work as before (no changes)
* HomeCalendar constructor modified to use both XML file (events) and the database (categories)

### Create and connect to a new database

As a user of the Calendar API,
I am able to create a new calendar database to a given file so I can access and store information in a scalable, maintainable manner

.**Assumptions**

**Acceptance Criteria** (see design)

* Create the database file and connect to it
* Create the tables
* Specify the columns, primary keys, foreign keys
* Add the category types to the table (income, savings, expense and credit)
* Add the default categories (input hardcoded list to database)
* Tests updated/added

### Connect to an existing database

As a user of the Calendar API, 
I am able to connect to an existing database from a given file so I can access and store information in a scalable, maintainable manner.	

**Assumptions**

* The file is a valid database

**Acceptance Criteria**

* Throw an exception if the given file does not exist.
* Tests updated/added

### Retrieve categories

As a user of the Calendar API, 
I am able to retrieve categories that have been previously stored in a database so I can access them in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database
* Events still stored in XML file

**Acceptance Criteria**

* Method that returns a list of Category objects is updated to retrieve them from the database.
* The list should be sorted by the Id.
* Tests updated/added

### New category 

As a user of the Calendar API,
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

As a user of the Calendar API,
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

As a user of the Calendar API,
I am able to delete a category stored in a database so I can change it in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database

**Acceptance Criteria**

* Able to delete by category id
* Row deleted from database.
* Ignore if Id does not exist
* Throws exception if not allowed to delete in database (foreign key constraint).
* Tests updated/added

## EPIC Event and Events using database

* Event and Events work as per stories
* HomeCalendar constructor modified to only use the database.

### Retrieve events

As a user of the Calendar API,
I am able to retrieve events that have been previously stored in a database so I can access them in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database	

**Acceptance Criteria**

* Method that returns a list of Events objects is updated to retrieve them from the database. 
* The list should be sorted by Id. 
* StartDateTime is returned as a DateTime object
* Tests updated/added

### New Event

As a user of the Calendar API,
I am able to add a uniquely identified event that has 

*  a startDateTime,
*  a durationInMinutes,
*  a dedetails and 
*  a categoryId
   to the database so that I can store and access it in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database
* Table exists	

**Acceptance Criteria**

* Method in Events allows for the addition of a new Event to the database table.
* All Event object information should be stored in the database directly and not in memory.
* StartDateTime specified as a DateTime object
* Tests updated/added

### Update event

As a user of the Calendar API,
I am able to update an event in the database so I can change it in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database

**Acceptance Criteria**

* The Event class properties should be changed to now be read-only
* An Events method allows the API user to update the database passing in all the Event properties, including the *date* property
* The Id of the Event to be updated must be provided.
* The method updates the properties (except the Id) in the database row.
* Tests updated/added

### Delete event

As a user of the Calendar API,
I am able to delete an event stored in a database so I can change it in a scalable, maintainable manner.	

**Assumptions**

* Connection to a valid database

**Acceptance Criteria**

* Able to delete by event id in Events.
* Row deleted from database.
* Ignore if Id does not exist
* Throws exception if not allowed to delete in database (foreign key constraint).
* Tests updated/added

## EPIC: HomeCalendar using database

As a user of the Calendar API, 
I only provide the database filename only so that I can manage a HomeCalendar in a streamlined, scalable, maintainable manner.	

**Assumptions**

**Acceptance Criteria**

* No longer pass in or use any XML files.

### Update GetCalendarItems

As a user of the Calendar API, 
I can retrieve a customizable (date, category) list of CalendarItem objects (each include categoryId, eventId, startDateTime, durationInMinutes, event description, category description, dynamic busyTime) using the database so that I can retrieve the information in a scalable, maintainable manner.

**Assumptions**

**Acceptance Criteria**

* Start and end time if unspecified default to January 1st 1900 and January 1st 2500
* Category Id only used for filtering if the filter flag is set to true. 
* No default category
* BusyTime is a running total of the resulting calendar items.
* Should use a database query.
* List of CalendarItems should be sorted by date. 
* Tests updated/added

### Update GetCalendarItemsByMonth

As a user of the Calendar API,
I can retrieve a customizable (date, categoryId) list of CalendarItemsByMonth objects (each include details - a list of CalendarItems for that month, month identifier string, total) using the database so that I can retrieve the information in a scalable, maintainable manner.

**Assumptions**

**Acceptance Criteria**

* Start and end time if unspecified default to January 1st 1900 and January 1st 2500.
* Category Id only used for filtering if the filter flag is set to true. 
* No default category.
* The total in a given CalendarItemsByMonth object is the total busy time for the CalendarItems of that month.
* Tests updated/added

### Update GetCalendarItemsByCategory

As a user of the Calendar API, 
I can retrieve a customizable (date, categoryId) list of CalendarItemsByCategory objects (each include the category description, details - a list of CalendarItems for that category, total) using the database so that I can retrieve the information in a scalable, maintainable manner.

**Assumptions**

**Acceptance Criteria**

* Start and end time if unspecified default to January 1st 1900 and January 1st 2500.
* Category Id only used for filtering if the filter flag is set to true. 
* No default category.
* The total in a given CalendarItemsByCategory object is the total busy time for the CalendarItems of that category.
* The returned list of CalendarItemsByCategory objects should be sorted by category description, alphabetically.
* In each CalendarItemsByCategory object’s details property, the list of CalendarItems should be sorted by date. 
  *Tests updated/added

### Update GetCalendarDictionaryByCategoryAndMonth

As a user of the Calendar API,
I can retrieve a customizable (date, categoryId) list of Dictionary<string,object> objects using the database so that I can retrieve the information in a scalable, maintainable manner.

**Assumptions**

* That this will just work once the GetCalendarItemsByMonth method is converted.

**Acceptance Criteria**

* Tests pass

### Error handling

As a user of the Calendar API, 
I receive an exception when my actions cause a database error so I am notified when attempting invalid or failed operations.

**Assumptions**

* Connection to a valid database

**Acceptance Criteria**

* Exceptions thrown on invalid (constraints, invalid SQL,...) or failed (connectivity) operations.

# Database design

### events

| Keys               | Column              | Column Type |
| ------------------ | ------------------- | ----------- |
| PK                 | Id                  | Int         |
|                    | DateTime            | Text        |
|                    | Details             | Text        |
|                    | DurationInMinutes   | Double      |
| FK - categories Id | CategoryId          | Int         |

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

