# Milestone 6 Stories


**Bolded Stories are Mandatory for Milestone 6**

<u>**NOTE**: Do not display the list of expenses! You could check if your add worked by verifying the database using the command line sqlite3.</u>

### Epic - choosing the budget file to work with

1. **We would like first time users to be able to specify the name of the database file they wish to use, as well as the directory where it will be stored**

2. Returning users should have a 'one-click' option to reopen a previously used budget file. This could be done by writing to te registry, an OS-agnostic .ini file, or a .json file.

3. Returning users should have a 'one-click' option to open the file exporer to choose the budget file to work with.

4. When using the file explorer, it should open into the last directory used for this program.

### Epic - Closing the application

1. **It should be possible to close the application in a single click.**

2. Users should be informed if there is a possibility of unsaved changes that might be lost when they go to close the program. 

### Epic - Navigation

1. **When adding a new Expense into the budget, the user should be able to easily transition into choosing the category for it, or even adding a new category if required. This should be done without leaving the context of adding the expense.**

2. The application should be intuitive to use so that the user does not need to reference any documentation to successfully navigate and use the app.

3. The app should have a nice colour scheme.
   
4. The colour should be customizable based on user preference and/or special needs.

### Epic - entering expenses into the budget

1. **The app should have a GUI that allows the user to enter details of the expense they want to add. It should have (at least) two buttons, one to finalize adding the expense ot the budget, and the other to cancel the operation.**

2. **The app should reject invalid data inputted by the user.**

3. The app should use a DateTime picker for getting dates from users.

4. The default date for the DateTime should be set to "today" when the application first starts.

5. When entering multiple expenses, the DateTime chosen should not change between entries unless explicitly modified.

6. The name of the file currently being used should always be clearly displayed to the user.

7. **Selecting a category for an expense should be done via a drop-down menu.**

8. The drop-down menu used for selecting a category can allow for the entry of a new category. If the user types in a category name that does not exist and tries to use it, the new category will be created automatically.

9. The drop-down menu for choosing a category should have an autocomplete functionality.

10. When entering multiple expenses, the category chosen should not change between entries unless explicitly modified.

11. Other than Category and Date, all the entry fields for entering an Expense should be reset between entries.

12. The app should inform the user when an expense has been succesfully added.

13. If a user tries to enter the exact same expense twice in a row they should be warned and asked to confirm if they want o proceed.

14. There should be an option when you add an expense to indicate that it was paid with a credit card and have two expenses added. In addition to the original expense, an extra one in the 'credit card' category should be created with an amount equal to the negative of the original expense's amount.

    Example: I enter 35.00 for clothing expenses, and click ‘paid by credit card’. Two expenses will be added to the budget, -35.00 for clothing, +35.00 for credit card.

15. The app should allow users to enter all expense amounts as positive numbers. Expenses and Savings should be converted to negative values automatically while Income and Credit will remain positive.

### Epic - creating a new category

1. **The app should allow for the creation of a new category**.
  
2. Users should be prevented from creating a category if a category with the same description already exists. (This should be changed in the HomeBudget itself.)
