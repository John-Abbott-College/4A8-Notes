using System;
using Xunit;
using System.IO;
using System.Collections.Generic;
using Calendar;

namespace CalendarCodeTests
{
    public class TestHomeCalendar_GetCalendarItemsByMonth
    {
        string testInputFile = TestConstants.testCalendarFile;
        


        // ========================================================================
        // Get Events By Month Method tests
        // ========================================================================

        [Fact]
        public void HomeCalendarMethod_GetCalendarItemsByMonth_NoStartEnd_NoFilter()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);
            int maxRecords = TestConstants.CalendarItemsByMonth_MaxRecords;
            CalendarItemsByMonth firstRecord = TestConstants.CalendarItemsByMonth_FirstRecord;

            // Act
            List<CalendarItemsByMonth> CalendarItemsByMonth = homeCalendar.GetCalendarItemsByMonth(null, null, false, 9);
            CalendarItemsByMonth firstRecordTest = CalendarItemsByMonth[0];

            // Assert
            Assert.Equal(maxRecords, CalendarItemsByMonth.Count);

            // verify 1st record
            Assert.Equal(firstRecord.Month, firstRecordTest.Month);
            Assert.Equal(firstRecord.Total, firstRecordTest.Total);
            Assert.Equal(firstRecord.Details.Count, firstRecordTest.Details.Count);
            for (int record = 0; record < firstRecord.Details.Count; record++)
            {
                CalendarItem validItem = firstRecord.Details[record];
                CalendarItem testItem = firstRecordTest.Details[record];
                Assert.Equal(validItem.DurationInMinutes, testItem.DurationInMinutes);
                Assert.Equal(validItem.CategoryID, testItem.CategoryID);
                Assert.Equal(validItem.EventID, testItem.EventID);

            }
        }

        // ========================================================================

        [Fact]
        public void HomeCalendarMethod_GetCalendarItemsByMonth_NoStartEnd_FilterbyCategory()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);
            int maxRecords = TestConstants.CalendarItemsByMonth_FilteredByCat9_number;
            CalendarItemsByMonth firstRecord = TestConstants.CalendarItemsByMonth_FirstRecord_FilteredCat9;

            // Act
            List<CalendarItemsByMonth> CalendarItemsByMonth = homeCalendar.GetCalendarItemsByMonth(null, null, true, 9);
            CalendarItemsByMonth firstRecordTest = CalendarItemsByMonth[0];

            // Assert
            Assert.Equal(maxRecords, CalendarItemsByMonth.Count);

            // verify 1st record
            Assert.Equal(firstRecord.Month, firstRecordTest.Month);
            Assert.Equal(firstRecord.Total, firstRecordTest.Total);
            Assert.Equal(firstRecord.Details.Count, firstRecordTest.Details.Count);
            for (int record = 0; record < firstRecord.Details.Count; record++)
            {
                CalendarItem validItem = firstRecord.Details[record];
                CalendarItem testItem = firstRecordTest.Details[record];
                Assert.Equal(validItem.DurationInMinutes, testItem.DurationInMinutes);
                Assert.Equal(validItem.CategoryID, testItem.CategoryID);
                Assert.Equal(validItem.EventID, testItem.EventID);

            }
        }
        // ========================================================================

        [Fact]
        public void HomeCalendarMethod_GetCalendarItemsByMonth_2018_filterDateAndCat9()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);
            List<Event> listEvents = TestConstants.filteredbyYear2018();
            List<Category> listCategories = homeCalendar.categories.List();
            List<CalendarItemsByMonth> validCalendarItemsByMonth = TestConstants.getCalendarItemsBy2018_01_filteredByCat9();
            CalendarItemsByMonth firstRecord = TestConstants.CalendarItemsByMonth_FirstRecord_FilteredCat9;

            // Act
            List<CalendarItemsByMonth> CalendarItemsByMonth = homeCalendar.GetCalendarItemsByMonth(new DateTime(2018, 1, 1), new DateTime(2018, 12, 31), true, 9);
            CalendarItemsByMonth firstRecordTest = CalendarItemsByMonth[0];

            // Assert
            Assert.Equal(validCalendarItemsByMonth.Count, CalendarItemsByMonth.Count);

            // verify 1st record
            Assert.Equal(firstRecord.Month, firstRecordTest.Month);
            Assert.Equal(firstRecord.Total, firstRecordTest.Total);
            Assert.Equal(firstRecord.Details.Count, firstRecordTest.Details.Count);
            for (int record = 0; record < firstRecord.Details.Count; record++)
            {
                CalendarItem validItem = firstRecord.Details[record];
                CalendarItem testItem = firstRecordTest.Details[record];
                Assert.Equal(validItem.DurationInMinutes, testItem.DurationInMinutes);
                Assert.Equal(validItem.CategoryID, testItem.CategoryID);
                Assert.Equal(validItem.EventID, testItem.EventID);

            }
        }


        // ========================================================================

        [Fact]
        public void HomeCalendarMethod_GetCalendarItemsByMonth_2018_filterDate()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);
            List<CalendarItemsByMonth> validCalendarItemsByMonth = TestConstants.getCalendarItemsBy2018_01();
            CalendarItemsByMonth firstRecord = validCalendarItemsByMonth[0];


            // Act
            List<CalendarItemsByMonth> CalendarItemsByMonth = homeCalendar.GetCalendarItemsByMonth(new DateTime(2018, 1, 1), new DateTime(2018, 12, 31), false, 9);
            CalendarItemsByMonth firstRecordTest = CalendarItemsByMonth[0];

            // Assert
            Assert.Equal(validCalendarItemsByMonth.Count, CalendarItemsByMonth.Count);

            // verify 1st record
            Assert.Equal(firstRecord.Month, firstRecordTest.Month);
            Assert.Equal(firstRecord.Total, firstRecordTest.Total);
            Assert.Equal(firstRecord.Details.Count, firstRecordTest.Details.Count);
            for (int record = 0; record < firstRecord.Details.Count; record++)
            {
                CalendarItem validItem = firstRecord.Details[record];
                CalendarItem testItem = firstRecordTest.Details[record];
                Assert.Equal(validItem.DurationInMinutes, testItem.DurationInMinutes);
                Assert.Equal(validItem.CategoryID, testItem.CategoryID);
                Assert.Equal(validItem.EventID, testItem.EventID);

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

