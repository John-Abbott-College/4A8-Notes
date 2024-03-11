# **Test 1 Info**



### *Reminder: as indicated in the course outline Evaluation Plan, to pass the course, <u>you must get >= 60% on cumulative tests</u>.*



VisualStudio project setup

- VS Project file (.csproj) contains all the info and instructions to build the project. 

  - In XML format
  - Can be edited (to fixup file list of files if it gets out of sync, for example)

- VS Solution file (.sln) contains the info for one or more related projects with build info and solution wide settings.

  - Text file in its own format
  - Should not be edited 

- To add existing .cs files, copy them into the project directory and Add -> Existing Items on the project in VisualStudio - this ensures that the files are properly added in the .csproj file

- Setting a common namespace in C# files

- Using a console app to test an API with no GUI

  

Documenting APIs

- Why?

  - Allow others to use your API without having to understand your implementation (how it does what it does). You might even not want to give them the code at all. They need to rely on your documentation. IDEs show you the documentation which helps users of your code.

- What you should document

  - Public classes, methods, fields in an API
  - Keep it succinct and clear: do not repeat the name of the method/class/interface/struct, do not state "this method/class/interface/struct will/does"

- Identify the components of a public method/class/interface/struct to document

  - What it does (not how), return type, parameters, exceptions
  - Describe what it does starting with a verb indicating the operation
  - Boolean parameters:
    - Requesting an action: If true… If false
    - Boolean specifying state: True if….; false otherwise
  - Exceptions: Thrown when…., specify all thrown explicitly and implicitly

- Providing example usage of the main class in XML documentation

- Specify XML documentation for classes, methods, fields using appropriate tags

- Using NuGet to install DocFX

- What DocFX was used for

  - generating static web pages from the XML comments

    

Unit tests

- A test of a unit of code (often a method) in isolation

  - Not about interaction with other parts of the code, no dependencies on any outside systems
  - is NOT:
    - integration testing
      - tests the interaction between components of the system
      - done after you have tested each individual component
    - regression testing
      - verify if any new bugs in the system introduced by your changes. Sometimes bugs in other parts of the code that your changes affected.

- In an XUnit Test project, 

  - Need to add a reference to the source code project, so that the XUnit project can access the code to test

  - need to decorate test methods with [Fact]

- Test methods

  - Should test that
    - the code works as expected, typical use
    - the code works as expected in atypical uses
    - the expected functioning in edge case conditions
  - Should be named very descriptively
    - Name often includes inputs or tested scenario and expected output
  - Should be independent
  - Usually follow the pattern of
    - Arrange - test setup
    - Act - invoke the tested method
    - Assert - check that the expected occurred
  - Assert methods throw if the condition passed in is false, for example
    - Assert.Equal( expected, actual ) will throw if expected and actual are not equal
    - Assert.NotEqual( expected, actual ) will throw if expected and actual are equal
    - Assert.True( condition ) will throw if the condition is false
    - Assert.False( condition ) will throw if the condition is not false (true)
  - Good idea to add test when you fix a bug found post development
  - Be able to write, run, and debug unit tests

- Code coverage

  - Gives the percentage of code (per namespace, class, or method) that the unit tests exercise.

  - Highlights code that is run during tests and code that is not run.

  - Allows a developer to realise that there are missing tests.

  - The ideal is 100% coverage, but this is hard to attain in practice.

  - Just because code is run in a test does not mean that it is necessarily well tested or that it is good code. What is tested and how it is tested determines if a ‘covered’ line of code is well tested.

  - You need to 

    - ensure the quality of your code: good logic, meets the requirements, well documented
    - write good unit tests that test
      - all possible logic flows in the expected use of the method
      - all possible cases where things could go wrong: edge cases
      - intentional misuses of your method (security risks)

    

Coding standards

- Don’t change existing code unnecessarily
  - May unnecessarily introduce bugs
    - Causes noise
      - makes it more difficult to see what the intended change in the commit is, in particular if it introduces a bug
- Always use standard indentation styles (usually spaces instead of tabs)
- Functions/methods should do one thing and one thing only
- Variable/method/field/class names should be meaningful
- Avoid code duplication
  - Holding the same information in two places is increasing the likelihood of bugs - versions diverge, one may forget to update both places, etc.



Software Development Cycle

- Plan, Define requirements, Design, Develop, Test, Deploy, Maintain

- Waterfall method

  - Method
    - Requirements are all determined up front (for example, “for release 3.5 we will have these features”)
    - Developers come up with designs and estimate the times involved. Release date is set accordingly. 
    - Developers code everything according to design.
    - Only after development is done, testers test and release is deployed.
  - Pitfalls
    - While coding, many issues are often discovered. Flaws in the design are discovered as is often the case when the developer works in the code in depth and the unknowns are now clearer. Changes in design cause delays.
    - Requirements are not detailed enough and cases they do not address become apparent when development is in progress.
    - Customers do not get any new features until the whole release is ready. Often there are long delays due to development issues.
    - Customer needs evolve. The initial requirements may no longer suit their needs.

- Iterative development approach

  - Break the project into smaller bits, and only make promises about the ‘next bit’.

    

Agile Development Principles

- The principles are defined in a document, the Agile manifesto
- The principles focus on iterative development, working software that offers business value, team communication, collaboration with the customer (frequent feedback) and response to change

Scrum

- An agile process - one way to work that respects the Agile principles

  - Deliver highest value in short time intervals

  - Short delivery intervals allows for requirements to evolve

  - Teams self-organize and communicate to improve on team dynamics and efficiency.

    ![img](https://lh3.googleusercontent.com/-EhUYXCkdWBUKl9hYK0s2bQXRwFrdDAzIj3QV2crceO-w2zbOfhZdkM7zNpIjhg55A58a58ifEo1LRxhMqhthhBiz9smmxRoj2j9Xw8RL8YITLKB62Jo8ift9siKXki3AJnQfdrWAKYR5CSX__eIuw)

  - Process involves

    - A Scrum team consisting of
      - The team
        - Should not change between sprints
        - Cross-functional: developers, testers, designers
      - The Scrum master
        - Makes sure the Scrum process runs smoothly
      - The Product Owner
        - Directs the team towards the most valuable work
        - Controls the priority of the user stories in the backlog
        - Makes sure the requirements and stories are clear.
        - Accepts or rejects work results
    - User stories
      - Written from the perspective of an actor (customer, for example):
        - As a <role> I want a <feature> so that I can <accomplish something>
        - Knowing the motivation of the actor helps make sure the story is defined correctly
      - Should be valuable, independent and testable
      - Acceptance criteria defined
      - Should be discussed by the SCRUM team to make sure they are well defined and thought through
      - Should be attributed a story point value which reflects its relative complexity to other stories
        - The story point value could be determined following a scrum team discussion and round of planning poker
          - In planning poker, each team member independently determines what they think the story’s relative complexity is
          - Seeing everyone’s values could lead to further beneficial discussions about details.
          - Subsequent planning poker rounds can be performed to determine an agreed upon value for the story
    - A product backlog containing all the user stories for the project kept in priority (highest priority at the top) by the Product Owner. 
      - The Scrum team meets to look at the stories in the backlog and try to refine and update the ones from the top periodically.
    - A Sprint backlog determined at a sprint planning meeting
      - Team decides how many story points they want to aim for. The team creates and starts a sprint with the chosen stories from the top of the backlog.
    - Sprints of 2-4 weeks 
      - The team works on the stories in the sprint
        - The team should try to close stories before starting new ones. Delivering value to the customer as soon as possible being the goal
      - It is ok to bring in more stories if stories are completed (or in progress stories cannot benefit from help from team members)
      - Stories should not be removed from the sprint. The initial set of stories is an estimate of what the team thought they could complete. Knowing how accurate the estimate is helps the team improve.
      - There should always be a potentially shippable product at the end of every sprint
    - Daily Scrum meetings
      - Also called stand up meetings. They should be short - 15 minutes max. Having everyone standing promotes meeting brevity.
      - Each person indicates what they worked on the day before, what they will work on the upcoming day and what, if anything, is blocking them.
    - Sprint Reviews
      - At the end of the sprint, the sprint itself is closed.
      - Any closed stories are demoed to anyone that is interested (the product owner, customer, other teams in the company)
      - All closed stories should be part of a potentially shippable product.
      - Any user stories that were not closed will fall to the top of the backlog.
    - Retrospectives
      - The team looks back on the sprint that just finished. Discusses what went well, what did not go so well and what they should change or start doing going forward.

JIRA

- A tool that is widely used in industry for software project management
- Allows Scrum teams to create and manage user stories in a backlog and to manage sprints.
- Allows for the creation of Epics - a logical grouping of user stories



Prepare and Test Database

- SQLite database properties

  - Relational
  - Stored in a file
  - Very lightweight
  - No configuration required
  - No server required

- Be able to use the command line interface to see database basics like:

  - Open the file of an existing database: run sqlite3 with the filename or call .open [filename]
  - List the tables in the database (.tables), 
  - Query a given table (select [columns] from [table]**;**)
  - Quit the Command line interface (.quit)
  - Why did we add the sqlite3 executable to the PATH environment variable?

- ADO.NET provides an interface to databases. We are using the SQLite version,System.Data.SQLite, which allows us to interface with SQLite in C#. We are able to:

  - Create an SQLite database
  - Add tables to an SQLite database, with primary key and foreign key columns specified
  - Insert rows into an SQLite database
  - Query data in an SQLite database
    - Be able to iterate over the data received
  - Create appropriate queries with GROUP BY and ORDER BY clauses
  - Remember to not use SELECT * because it makes your code vulnerable to bugs if someone modifies the database by adding a column. Specify the column names in your select statements.

- What do we use NuGet for in VisualStudio?

  

Understand what SQL injection is

- A common hacking technique
- Attempts to place malicious code into an SQL statement
- As a developper, if you take user input and incorporate into the SQL statement directly, you leave your application vulnerable to SQL injection
- Be able to understand why a particular injection string is dangerous
  - Example injection strings (for SELECT * FROM Users WHERE UserID='{id}'):
  - 105' OR '1'='1 
  - 105'; DROP TABLE suppliers;--
  - ' OR ''='



Protecting against SQL injection

- Parameter binding (aka dynamic parameters or prepared statements)

  - Understand how they work

    - Bound data is not interpreted as SQL
    - Compiling SQL inserts the reference to the data
    - The data is only used when the SQL code is executed

  - Prepare, Bind, Execute, Fetch pattern

    ![img](https://lh4.googleusercontent.com/-zmDw_HtGJHfvrc1W9VHHmJLb6gxNC81grd7wrp_-_I3EZV54l_PEXO7kr5NWSzQJCuYEx9DgIgbqWIOvYBvVXicsOgfHV8AAqX5kJ7M5qg6Q9lqODrvb35DzBEfBK2Fp_eq2VVSJlj3zZMhFQURRg)

  - Be able to create SQL statements that use bound parameters in C# with SQLite.



Working in teams on a common code base

- Git
  - Is a version control system
  - Allows you to save versions of a code base
  - You commit code to a repository with all the necessary files of the code base
  - GitHub holds a copy of the repository in the cloud.
  - You need to push changes from your local machine to the cloud-based GitHub copy and pull changes from GitHub to any local machine.
- Why should you use Git
  - Sending files to one another quickly becomes unmanageable.
- Why you should use branching
  - Having several people working in the same repository becomes troublesome, having to coordinate commits is difficult
  - Work that one person adds might be releasable immediately, all the while another person may commit partial work.
  - One person may commit partial work that does not compile leaving the others unable to run or test their changes
- Use master/main repository and branches
  - The master/main repository should only contain code that is deployable
  - Individuals work in their branches which are initially copies of the shared master/main repository
- Each team member has:
  - A local copy of the feature branch they are working on
  - Usually also a local copy of the master/main repository
- Know what a pull request is, when and how to create one: when bringing your completed branch changes to master
- Know how to update the master/main repository with your branch changes: pull request
- Know how to update your branch with new changes that have been added to master/main: merge master into your branch
- Know when it is necessary to do the above two (branch=>master, master=>branch)
- Remember to keep local copies of branches/repositories in sync with the versions on GitHub.
- Commit your branch work very often, even if it is not finalized.
- Conflicts may occur on any merge - each conflict should be properly examined to decide what version of the code should be retained
- Generally, good to have different people work on different parts of the code to minimize conflicts, even with branching
- What is the purpose of a .gitignore file when creating a repository in GitHub?
  - Any generated files should be in the list of ignored files (fields that should not be tracked by Git)
