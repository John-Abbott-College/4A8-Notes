# Milestone 6 Stories



**Bolded Stories are Mandatory for Milestone 6**

<u>**NOTE**: Do not display the list of events! You could check if your add worked by verifying the database using the command line sqlite3.</u>

### Epic - choosing the calendar file to work with

1. **As a first time user, I want to be asked for a calendar file name so that I can store my information in a file that I could easily identify.**

2. **As a first time user, I want to be asked for the folder name where the file will be stored so that I could easily find my calendar files.**

   **OR**

   **As a first time user, I want to be asked where the calendar files will be stored, with the default set to “Documents/Calendars” so that I could get started on a calendar quickly and still be able to intuitively find my files.**

3. As a continuing user, I want a ‘one-click’ option to open the calendar file that I previously worked on, so that I will be more efficient in my tasks

   Writing to the registry or creating an OS-agnostic .ini file

4. As a continuing user, I want a ‘one-click’ option to open file explorer to choose the calendar file that I want to work with, so that I can quickly get working on a previously saved calendar.

5. As a continuing user, when I open file explorer to choose the calendar file, I want to see the last directory that I used for this program, so that I don’t have to waste time navigating to my usual file location.

### Epic - Closing the application

1. **As a user, I want to be able to close the application with ‘one-click’, so that I can quickly start working on something else.**
2. As a user, I want to be notified and asked to confirm the closing of the application if there is a possibility of unsaved changes, so that I do not inadvertently lose changes.

### Epic - Navigation

1. **As a user, I want to be able to easily transition from entering events into the calendar and adding a new category to it, so that I can remain in the context of the event even when the need for a new category arises.**
2. As a user, I want the application to be intuitive so that I do not need to read the help documentation to use the application, so that I can focus on the calendar work I need to do and not on the application itself.
3. As a user, I want the colour scheme to be a pleasant looking interface, so that I will not suffer from eye strain.
4. As a user, I want to be able to change the colour scheme so that I can personalize my use of the app aesthetically, or based on my visual special needs.

### Epic - entering events into the calendar

1. **As a user, I want to be able to enter the info of my events into a GUI form, and have two buttons, one for adding to the calendar, and one for cancelling this event so that I could add events in a graphical manner.**

2. As a user, I want the application to verify my input data so that I do not enter invalid data.**

3. As a user, I want a DateTime picker to pick my date and time, so that I don’t have to enter it manually.

4. As a user, I want the default date to be set to “today” when the application first starts, so that I could easily enter my events every day.
   
5. As a user, I want the default time to be set to the next 30 minute tome boundary from now when the application first starts, so that I could easily create an immediate event.

6. As a user, I want the date not to change between successive event entries unless explicitly modified, so that when I add events that occurred all on the same day, I don’t have to constantly choose a date.

7. As a user, I want the name of the file that I am using always displayed, so that I am aware of which file I am writing to when I have multiple calendars.

8. **As a user, I want a drop-down list of available categories to choose from, so that I don’t have to guess what categories are available.****

9. As a user, I want to be able to type in the drop-down category list, a new category name which will automatically create a new category for me so that my life is simpler.

10. As a user, I want to be able to start typing a category name, and have the selection tool go to the first match of what I have typed, so that I can increase my efficiency.

11. As a user, I want the chosen category to remain the same between successive event entries, unless specifically changed, so that I can add a bunch of events with the same category, one after the other without having to constantly choose the category.

12. As a user, with the exception of Category and StartDateTime, I want all the entry fields to be reset between successive event entries, so that I can enter the information that is likely to be different without having to delete information.

13. As a user, I want an indication when an event has been successfully added so that I avoid re-submitting the same event accidentally. 

14. As a user, I want to be asked to confirm when the current event that I am trying to save is exactly the same as the previous one so that I can avoid adding duplicate events by mistake

15. As a user, I want to be able to enter an event that repeats at the same time over several consecutive days, so that I can easily enter multi-day events without needing to intecract with the form for each event.


### Epic - creating a new category

1. **As a user I want to be able to create a new category, so that I can effectively organize my events.**

   

This should be changed in the HomeCalendar itself

1. *As a user, I want to be prevented from creating a category if a category with the same description already exists, so that I do not split similar events unnecessarily.*
