using System;
using Xunit;
using System.IO;
using System.Collections.Generic;
using Calendar;

namespace CalendarCodeTests
{
    public class TestHomeCalendar_GetCalendarItemsByCategory
    {
        string testInputFile = TestConstants.testCalendarFile;

        // ========================================================================
        // Get Events By Month Method tests
        // ========================================================================

        [Fact]
        public void HomeCalendarMethod_GetCalendarItemsByCategory_NoStartEnd_NoFilter()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);
            int maxRecords = TestConstants.CalendarItemsByCategory_MaxRecords;
            CalendarItemsByCategory firstRecord = TestConstants.CalendarItemsByCategory_FirstRecord;

            // Act
            List<CalendarItemsByCategory> CalendarItemsByCategory = homeCalendar.GeCalendarItemsByCategory(null, null, false, 9);
            CalendarItemsByCategory firstRecordTest = CalendarItemsByCategory[0];

            // Assert
            Assert.Equal(maxRecords, CalendarItemsByCategory.Count);

            // verify 1st record
            Assert.Equal(firstRecord.Category, firstRecordTest.Category);
            Assert.Equal(firstRecord.TotalBusyTime, firstRecordTest.TotalBusyTime);
            Assert.Equal(firstRecord.Items.Count, firstRecordTest.Items.Count);
            for (int record = 0; record < firstRecord.Items.Count; record++)
            {
                CalendarItem validItem = firstRecord.Items[record];
                CalendarItem testItem = firstRecordTest.Items[record];
                Assert.Equal(validItem.DurationInMinutes, testItem.DurationInMinutes);
                Assert.Equal(validItem.CategoryID, testItem.CategoryID);
                Assert.Equal(validItem.EventID, testItem.EventID);

            }
        }

        // ========================================================================

        [Fact]
        public void HomeCalendarMethod_GetCalendarItemsByCategory_NoStartEnd_FilterbyCategory()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);
            int maxRecords14 = TestConstants.CalendarItemsByCategory14;
            int maxRecords20 = TestConstants.CalendarItemsByCategory20;

            // Act
            List<CalendarItemsByMonth> CalendarItemsByCategory = homeCalendar.GetCalendarItemsByMonth(null, null, true, 14);

            // Assert
            Assert.Equal(maxRecords14, CalendarItemsByCategory.Count);


            // Act
            CalendarItemsByCategory = homeCalendar.GetCalendarItemsByMonth(null, null, true, 20);

            // Assert
            Assert.Equal(maxRecords20, CalendarItemsByCategory.Count);

        }
        // ========================================================================

        [Fact]
        public void HomeCalendarMethod_GetCalendarItemsByCategory_2018_filterDateAndCat9()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);
            List<CalendarItemsByCategory> validCalendarItemsByCategory = TestConstants.getCalendarItemsByCategory2018_Cat9();
            CalendarItemsByCategory firstRecord = validCalendarItemsByCategory[0];

            // Act
            List<CalendarItemsByCategory> CalendarItemsByCategory = homeCalendar.GeCalendarItemsByCategory(new DateTime(2018, 1, 1), new DateTime(2018, 12, 31), true, 9);
            CalendarItemsByCategory firstRecordTest = CalendarItemsByCategory[0];

            // Assert
            Assert.Equal(validCalendarItemsByCategory.Count, CalendarItemsByCategory.Count);

            // verify 1st record
            Assert.Equal(firstRecord.Category, firstRecordTest.Category);
            Assert.Equal(firstRecord.TotalBusyTime, firstRecordTest.TotalBusyTime);
            Assert.Equal(firstRecord.Items.Count, firstRecordTest.Items.Count);
            for (int record = 0; record < firstRecord.Items.Count; record++)
            {
                CalendarItem validItem = firstRecord.Items[record];
                CalendarItem testItem = firstRecordTest.Items[record];
                Assert.Equal(validItem.DurationInMinutes, testItem.DurationInMinutes);
                Assert.Equal(validItem.CategoryID, testItem.CategoryID);
                Assert.Equal(validItem.EventID, testItem.EventID);

            }
        }


        // ========================================================================

        [Fact]
        public void HomeCalendarMethod_GetCalendarItemsByCategory_2018_filterDate()
        {
            // Arrange
            string inFile = GetSolutionDir() + "\\" + testInputFile;
            HomeCalendar homeCalendar = new HomeCalendar(inFile);
            List<CalendarItemsByCategory> validCalendarItemsByCategory = TestConstants.getCalendarItemsByCategory2018();
            CalendarItemsByCategory firstRecord = validCalendarItemsByCategory[0];


            // Act
            List<CalendarItemsByCategory> CalendarItemsByCategory = homeCalendar.GeCalendarItemsByCategory(new DateTime(2018, 1, 1), new DateTime(2018, 12, 31), false, 9);
            CalendarItemsByCategory firstRecordTest = CalendarItemsByCategory[0];

            // Assert
            Assert.Equal(validCalendarItemsByCategory.Count, CalendarItemsByCategory.Count);

            // verify 1st record
            Assert.Equal(firstRecord.Category, firstRecordTest.Category);
            Assert.Equal(firstRecord.TotalBusyTime, firstRecordTest.TotalBusyTime);
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

