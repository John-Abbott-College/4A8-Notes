# SQLite

## 🎯Goals

Be able to understand and use SQLite from the command line

* Connect to a database
* Create tables and insert data
* Verify your work by using proper select statements

---

## What is SQLite?

### 🧩🧩 Mini activity to learn about SQLite

1. Read the content on this webpage https://www.sqlitetutorial.net/what-is-sqlite/

2. Answer the below questions
   1. What is SQLite?
   2. How is SQLite like the SQLServer database you have experience with?
   3. How does it differ from SQLServer database you have experience with
   4. Where is it installed? On a server? Locally?
   5. What type of database is it? relational or non-relational?

### 🧠Installation

Follow the instructions on this page to install SQLite: [Installation Instructions](https://www.sqlitetutorial.net/download-install-sqlite/)

>**Keep a list of all the steps you have taken.**
>
>If you get stuck, you need to have the list of all the steps you have taken to help the trouble-shooting
>
>*Before* asking for help, verify that the list of steps you took are consistent with the instructions.

Verify that you can run SQLite from the command line!!!! You do not need to install an SQLite GUI tool.



### 🧩🧩  Mini Activity - Using SQLite from the command line

1. Download a sample database [SQLite Sample Database And Its Diagram (in PDF format)](https://www.sqlitetutorial.net/sqlite-sample-database/)

2. Learn how to use SQLite by following this [Practical SQLite Commands That You Don't Want To Miss](https://www.sqlitetutorial.net/sqlite-commands/)

3. It is assumed that the student remembers SQL from their database class, but if not, ([SQLite Tutorial - An Easy Way to Master SQLite Fast](https://www.sqlitetutorial.net/)).

4. Datatypes in SQLite is different than other standard relational databases.  Please read the following on [SQLite Data Types And Its Important Concepts Explained](https://www.sqlitetutorial.net/sqlite-data-types/)

5. Answer the following questions:

   After completing the above tutorial, you should be able to answer the following questions.  If not, either go back to the above tutorial, or read the reference documentation (see above).

   1. How do you use the SQLite from the command line
   2. How to get help in SQL command line
   3. How to quit the SQLite command line
   4. What is the SQLite command to get a list of tables in the database
   5. What is the SQLite command to list columns in a table
   6. The tutorial claims that the primary key is automatically incremented in SQLite, but it did not work for me. Did it work for you?



## 🛢When to use SQLite vs SQLServer/MySQL? 
We will change the code to be backed by a database instead of XML files. We chose to use SQLite as the database. Why?

SQLite is:

* open-source
* server-less - it does not require a server or any configuration
* lightweight

### How does it differ from databases that require a server such as MySQL?

1. #### Setup

   - **SQlite** is self-contained, small, and file-based. It can be installed with your application, on the client-side directly. It does not require a server to interact with, the application can interact with it directly (like we are via the C# SQLite library).
   - **MySQL** requires the client to interact with a database server. The application needs to connect to the server in order to access the database. Configuration is involved and the server is much bigger than SQLite.

   

2. #### Scalability

   - **SQlite** does not do well with big databases, it requires too much memory and becomes inefficient

   - **MySQL** can handle a lot of data and can be used at scale.

     

3. #### Access

   - **SQlite** does not have user management. It cannot handle being accessed simultaneously by multiple processes.

   - **MySQL** handles multiple users with permission levels 

     

4. #### Security

   - **SQlite** does not have an authentication system. File itself can be read and updated. 

   - **MySQL** has a built-in authentication and security features.

     


### When should you use SQLite?

- When scalability is not a concern - small applications that won't expand

- When it is handy to include the database with the application - small devices, standalone applications (do not connect to a server, like our API right now)

- When developing and testing with a simple database.

  

### When should you **NOT** use SQLite?

- When you are creating a multi-user application and require security features such as authentication.
- When scalability is a concern.
- When you do not want to include a database with an application, like with a web application



## References

[tutorialspoint](https://www.tutorialspoint.com/sqlite/index.htm)

https://sqlite.org/cli.html

https://tableplus.com/blog 

https://www.sqlite.org/

