# **Test 2 Info**

### **Reminder: as indicated in the course outline Evaluation Plan, to pass the course, you must get >= 60% on cumulative tests.**


#### Access Modifiers in C#

- public, protected internal, protected, internal, private protected, private 
  - Scope of each
  
- Why do you want to always limit to the most restrictive scope possible?

  - Reduces accidental misuse of code
  - Protects internal logic from being broken
  - Makes code easier to maintain
  - Improves security and stability

- What access modifiers make sense in classes of the API dll. 

  - public: Classes that are part of the API - Services, models, interfaces consumers need
  - internal: Helper classes, Business logic not meant for external use, Implementation details
  - private: Fields inside classes, Internal logic methods
  - protected: Base classes meant to be inherited by API consumers

- Testing an internal class

  ```
  using System.Runtime.CompilerServices;
  [assembly: InternalsVisibleToAttribute("HomeCalendarTesting")]
  ```
#### Dynamic Link Library - dll

- What is it?

  - **compiled file that contains reusable code**: classes, methods,,,

- Can it be executed on its own? **No**

- Can another program use it? **Yes**

- How is it used (calling functions) 

  Once referenced in a project, The program loads the DLL, accesses its public classes/methods, calls them like normal code

- It is a good to include documentation so that users know how to use it.

  Since a DLL is a **black box to users**, documentation is important because:

  - users don’t see the internal code
  - they only see public classes/methods
  - they need to know:
    - what methods exist
    - what parameters to pass
    - what they return
    - how to use them correctly

  Without documentation, the DLL is hard to use.

- Loaded in memory when needed.

- A single copy can be used by different programs at the same time

- Be able to use a dll in a project in VisualStudio

  NOTE: you will not be expected to create a dll

#### WPF controls, layout

- Be able to add controls, set properties and event listeners
- Be able to layout controls in containers, margins, padding, alignment

#### Design patterns vs Architectural patterns

- Be able to distinguish between the two

  - Design patterns solve **coding-level problems**, while architectural patterns define the **overall structure of an application**.

- Advantages of using a design pattern

   **proven solutions to common coding problems**

- Examples of design patterns. **Singleton**

- Advantages of using an architectural pattern.

  - **Clear separation of concerns**: UI, logic, and data are separated
  - **Better scalability**: easier to grow and extend the application
  - **Improved testability**: components can be tested independently
  - **Easier collaboration**: teams can work on different layers without conflicts
  - **Maintainable structure**: changes in one layer have minimal impact on others


#### MVC, MVP, MVVM

- Be able to explain the basic differences and pros/cons of each. Note you do not need to know how to do MVC or MVVM explicitly. Just understand the key points about them and mostly how they differ from MVP.
- Does WPF imply MVVM?

#### MVP Implementation
- Be able to implement the MVP pattern and how you would go about taking something that is in MVC or not separated into layers and transform it into MVP in WPF.
- Be able to test an MVP Presenter layer. Create and use test interface implementations

#### Combo boxes

- What should I add to my combo box? The actual object? Just the displayed string? Why? 

  objects give you:

  - Access to **all data**, not just text
  - No loss of information (ID, date, etc.)
  - Easier logic when working with selection
  - Cleaner and more scalable code

- How to set the displayed property of an object added to the combobox. **DisplayMemberPath**

- Be able to get and work with the selected item


#### DataGrid

- DataGrid requires a get/set on properties that are bound to the DataGrid. They must be public.
- Binding
  - Can set the ItemsSource.
  - One column is shown per bound property, one row is shown per object in the ItemsSource
  - Automatically generates a column per property of objects
  - Can customize the columns by setting AutoGenerateColumns to false and creating columns programmatically with associated Bindings (need to know how).
  - When the ItemsSource is a List of Dictionary objects (key-value pairs), you need to bind to the indexed key value: new Binding([myKey])
- Adding a context menu

#### CI/CD 

- What does it stand for, what is the goal?
- How does it fit into Agile thinking?
- How is it implemented? By automating build, integration, testing, packaging and release steps.
- What are the advantages of having these steps automated?
- Understand the parts of a CI/CD pipeline (like a GitHub Actions workflow)
  - Why did we use command-line to figure out the steps?
    - Figured out that needed to set the PATH, restore packages before building.
  - GitHub Actions
    - Script is run on GitHub servers, independently of what is on my computer's copy of the repo
    - GitHub installs a fresh OS version and clones a fresh copy of my repo from GitHub, before running my script.
    - We used the suggested template script for our type of repo (WPF C# solution). In that template, there already were steps to checkout our repo and add MSBuild to the PATH on wherever GitHub is running our script.
    - We set appropriate values for the environment variables used in the script steps
    - The CICD run was set to be triggered by any commit to master, or an pull request to master.
    - The script was set up to build both the debug and release configurations of our solution. This is why we see two script runs per commit/pull request to master. 

#### Refactoring code

- Fits with Agile
- Managers do not like it generally, but important in development
- Understand goals: go back and improve code made fragile with piled on changes, change of requirements, change of frameworks/libraries, improving separation of concerns, improve robustness.
- The longer you wait the riskier it gets to go back and refactor.
- Example: 
  - Having to bring the model (our API) namespace into the UI layer. Why did we have to? What could have been done instead?


### SOME REVIEW ELEMENTS

#### Coding standards

- Don’t change existing code unnecessarily
  - May unnecessarily introduce bugs
  - Causes noise, makes it more difficult to see what the intended change in the commit is, in particular if it introduces a bug
  - Always use standard indentation styles (usually spaces instead of tabs)
  - Functions/methods should do one thing and one thing only
  - Variable/method/field/class names should be meaningful
  - Avoid code duplication
    - Holding the same information in two places is increasing the likelihood of bugs - versions diverge, one may forget to update both places, etc.
- Unit tests
  - Does full code coverage necessarily imply that logic is fully tested?
- JIRA / GIT
  - What are burndown/burnup charts
  - Why is it important to set your story points before starting a sprint?
  - The master/main repository should only contain code that is deployable, why?
  - What is the purpose of a .gitignore file when creating a repository in GitHub?
    - Any generated files should be in the list of ignored files (fields that should not be tracked by Git)
