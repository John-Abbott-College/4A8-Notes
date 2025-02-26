# When to use SQLite vs SQLServer/MySQL? 

material from: https://tableplus.com/blog and https://www.sqlite.org/

#### We changed the code to be backed by a database instead of XML files. We chose to use SQLite as the database. Why?

SQLite is:

* open-source
* server-less - it does not require a server or any configuration
* lightweight



#### How does it differ from databases that require a server such as MySQL?

1. ##### Setup

   - **SQlite** is self-contained, small, and file-based. It can be installed with your application, on the client-side directly. It does not require a server to interact with, the application can interact with it directly (like we are via the C# SQLite library).
   - **MySQL** requires the client to interact with a database server. The application needs to connect to the server in order to access the database. Configuration is involved and the server is much bigger than SQLite.

   

2. ##### Scalability

   - **SQlite** does not do well with big databases, it requires too much memory and becomes inefficient

   - **MySQL** can handle a lot of data and can be used at scale.

     

3. ##### Access

   - **SQlite** does not have user management. It cannot handle being accessed simultaneously by multiple processes.

   - **MySQL** handles multiple users with permission levels 

     

4. ##### Security

   - **SQlite** does not have an authentication system. File itself can be read and updated. 

   - **MySQL** has a built-in authentication and security features.

     


#### When should you use SQLite?

- When scalability is not a concern - small applications that won't expand

- When it is handy to include the database with the application - small devices, standalone applications (do not connect to a server, like our HomeCalendar right now)

- When developing and testing with a simple database.

  

#### When should you **NOT** use SQLite?

- When you are creating a multi-user application and require security features such as authentication.
- When scalability is a concern.
- When you do not want to include a database with an application, like with a web application



