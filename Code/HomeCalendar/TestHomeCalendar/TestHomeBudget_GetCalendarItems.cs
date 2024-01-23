using System;
using Xunit;
using System.IO;
using System.Collections.Generic;
using Calendar;

namespace CalendarCodeTests
{
    public class TestHomeCalendar_GetCalendarItems
    {
        string testInputFile = TestConstants.testCalendarFile;
        

        // ========================================================================
        // Get Events Method tests
        // ========================================================================

        [Fact]
        public void HomeCalendarMethod_GetCalendarItems_NoStartEnd_NoFilter()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);
            List<Event> listEvents = homeCalendar.Events.List();
            List<Category> listCategories = homeCalendar.categories.List();

            // Act
            List<CalendarItem> CalendarItems =  homeCalendar.GetCalendarItems(null,null,false,9);

            // Assert
            Assert.Equal(listEvents.Count, CalendarItems.Count);
            foreach (Event Event in listEvents)
            {
                CalendarItem CalendarItem = CalendarItems.Find(b => b.EventID == Event.Id);
                Category category = listCategories.Find(c => c.Id == Event.Category);
                Assert.Equal(CalendarItem.Category, category.Description);
                Assert.Equal(CalendarItem.CategoryID, Event.Category);
                Assert.Equal(CalendarItem.DurationInMinutes, 0 - Event.DurationInMinutes);
                Assert.Equal(CalendarItem.ShortDescription, Event.Description);
            }
       }

        [Fact]
        public void HomeCalendarMethod_GetCalendarItems_NoStartEnd_NoFilter_VerifyBalanceProperty()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);

            // Act
            List<CalendarItem> CalendarItems = homeCalendar.GetCalendarItems(null, null, false, 9);

            // Assert
            double balance = 0;
            foreach (CalendarItem CalendarItem in CalendarItems)
            {
                balance = balance + CalendarItem.DurationInMinutes;
                Assert.Equal(balance, CalendarItem.Balance);
            }

        }

        // ========================================================================

        [Fact]
        public void HomeCalendarMethod_GetCalendarItems_NoStartEnd_FilterbyCategory()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);
            int filterCategory = 9;
            List<Event> listEvents = TestConstants.filteredbyCat9();
            List<Category> listCategories = homeCalendar.categories.List();

            // Act
            List<CalendarItem> CalendarItems = homeCalendar.GetCalendarItems(null, null, true, filterCategory);

            // Assert
            Assert.Equal(listEvents.Count, CalendarItems.Count);
            foreach (Event Event in listEvents)
            {
                CalendarItem CalendarItem = CalendarItems.Find(b => b.EventID == Event.Id);
                Category category = listCategories.Find(c => c.Id == Event.Category);
                Assert.Equal(CalendarItem.Category, category.Description);
                Assert.Equal(CalendarItem.CategoryID, Event.Category);
                Assert.Equal(CalendarItem.DurationInMinutes, 0 - Event.DurationInMinutes);
                Assert.Equal(CalendarItem.ShortDescription, Event.Description);
            }
        }

        // ========================================================================

        [Fact]
        public void HomeCalendarMethod_GetCalendarItems_2018_filterDate()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);
            List<Event> listEvents = TestConstants.filteredbyYear2018();
            List<Category> listCategories = homeCalendar.categories.List();

            // Act
            List<CalendarItem> CalendarItems = homeCalendar.GetCalendarItems(new DateTime(2018, 1, 1), new DateTime(2018, 12, 31), false, 0);

            // Assert
            Assert.Equal(listEvents.Count, CalendarItems.Count);
            foreach (Event Event in listEvents)
            {
                CalendarItem CalendarItem = CalendarItems.Find(b => b.EventID == Event.Id);
                Category category = listCategories.Find(c => c.Id == Event.Category);
                Assert.Equal(CalendarItem.Category, category.Description);
                Assert.Equal(CalendarItem.CategoryID, Event.Category);
                Assert.Equal(CalendarItem.DurationInMinutes, 0 - Event.DurationInMinutes);
                Assert.Equal(CalendarItem.ShortDescription, Event.Description);
            }
        }

        // ========================================================================

        [Fact]
        public void HomeCalendarMethod_GetCalendarItems_2018_filterDate_verifyBalance()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);
            List<Event> listEvents = TestConstants.filteredbyCat9();
            List<Category> listCategories = homeCalendar.categories.List();

            // Act
            List<CalendarItem> CalendarItems = homeCalendar.GetCalendarItems(null, null,  true, 9);
            double total = CalendarItems[CalendarItems.Count-1].Balance;
            

            // Assert
            Assert.Equal(0-TestConstants.filteredbyCat9Total, total);
        }

        // ========================================================================

        [Fact]
        public void HomeCalendarMethod_GetCalendarItems_2018_filterDateAndCat10()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);
            List<Event> listEvents = TestConstants.filteredbyYear2018AndCategory10();
            List<Category> listCategories = homeCalendar.categories.List();

            // Act
            List<CalendarItem> CalendarItems = homeCalendar.GetCalendarItems(new DateTime(2018, 1, 1), new DateTime(2018, 12, 31), true, 10);

            // Assert
            Assert.Equal(listEvents.Count, CalendarItems.Count);
            foreach (Event Event in listEvents)
            {
                CalendarItem CalendarItem = CalendarItems.Find(b => b.EventID == Event.Id);
                Category category = listCategories.Find(c => c.Id == Event.Category);
                Assert.Equal(CalendarItem.Category, category.Description);
                Assert.Equal(CalendarItem.CategoryID, Event.Category);
                Assert.Equal(CalendarItem.DurationInMinutes, 0 - Event.DurationInMinutes);
                Assert.Equal(CalendarItem.ShortDescription, Event.Description);
            }
        }




        // ========================================================================

        // -------------------------------------------------------
        // helpful functions, ... they are not tests
        // -------------------------------------------------------

        private String GetSolutionDir()
        {

            // this is valid for C# .Net Foundation (not for C# .Net Core)
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
        }

        // source taken from: https://www.dotnetperls.com/file-equals

        private bool FileEquals(string path1, string path2)
        {
            byte[] file1 = File.ReadAllBytes(path1);
            byte[] file2 = File.ReadAllBytes(path2);
            if (file1.Length == file2.Length)
            {
                for (int i = 0; i < file1.Length; i++)
                {
                    if (file1[i] != file2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private bool FileSameSize(string path1, string path2)
        {
            byte[] file1 = File.ReadAllBytes(path1);
            byte[] file2 = File.ReadAllBytes(path2);
            return (file1.Length == file2.Length);
        }

    }
}

