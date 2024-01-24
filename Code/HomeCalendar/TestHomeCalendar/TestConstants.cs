using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar;

namespace CalendarCodeTests
{
    public class TestConstants
    {

        private static Event Event1 = new Event(1, new DateTime(2018, 1, 10), 10, 12, "hat (on credit)");
        private static CalendarItem CalendarItem1 = new CalendarItem
        {
            CategoryID = Event1.Category,
            EventID = Event1.Id,
            DurationInMinutes = -Event1.DurationInMinutes
        };

        private static Event Event2 = new Event(2, new DateTime(2018, 1, 11), 9, -10, "hat (on credit)");
        private static CalendarItem CalendarItem2 = new CalendarItem
        {
            CategoryID = Event2.Category,
            EventID = Event2.Id,
            DurationInMinutes = -Event2.DurationInMinutes
        };


        private static CalendarItem CalendarItem3 = new CalendarItem
        {
            CategoryID = 10,
            EventID = 3,
            DurationInMinutes = -15
        };

        private static Event Event4 = new Event(4, new DateTime(2020, 1, 10), 9, -15, "scarf (on credit)");
        private static CalendarItem CalendarItem4 = new CalendarItem
        {
            CategoryID = Event4.Category,
            EventID = Event4.Id,
            DurationInMinutes = -Event4.DurationInMinutes
        };


        private static Event Event5 = new Event(5, new DateTime(2020, 1, 11), 14, 45, "McDonalds");
        private static CalendarItem CalendarItem5 = new CalendarItem
        {
            CategoryID = Event5.Category,
            EventID = Event5.Id,
            DurationInMinutes = -Event5.DurationInMinutes
        };

        private static Event Event7 = new Event(7, new DateTime(2020, 1, 12), 14, 25, "Wendys");
        private static CalendarItem CalendarItem7 = new CalendarItem
        {
            CategoryID = Event7.Category,
            EventID = Event7.Id,
            DurationInMinutes = -Event7.DurationInMinutes
        };







        public static int numberOfCategoriesInFile = 17;
        public static String testCategoriesInputFile = "test_categories.cats";
        public static int maxIDInCategoryInFile = 17;
        public static Category firstCategoryInFile = new Category(17, "Non Standard", Category.CategoryType.Event);
        public static int CategoryIDWithSaveType = 15;
        public static string CategoriesOutputTestFile = "test_output.cats";

        public static int numberOfEventsInFile = 6;
        public static String testEventsInputFile = "test_events.evts";
        public static int maxIDInEventFile = 7;
        public static Event firstEventInFile { get { return Event1; } }
        public static string EventOutputTestFile = "test_output.evts";

        public static string testCalendarFile = "test.Calendar";
        public static string outputTestCalendarFile = "output_test.Calendar";

        public static List<Event> filteredbyCat14()
        {
            List<Event> filtered = new List<Event>();
            filtered.Add(Event5);
            return filtered;
        }
        public static double filteredbyCat9Total = Event2.DurationInMinutes + Event4.DurationInMinutes;
        public static List<Event> filteredbyCat9()
        {
            List<Event> filtered = new List<Event>();
            filtered.Add(Event2);
            filtered.Add(Event4);
            return filtered;
        }
        public static List<Event> filteredbyYear2018AndCategory10()
        {
            List<Event> filtered = new List<Event>();
            filtered.Add(Event1);
            return filtered;
        }

        public static List<Event> filteredbyYear2018()
        {
            List<Event> filtered = new List<Event>();
            filtered.Add(Event1);
            filtered.Add(Event2);
            return filtered;
        }


        // LIST EventS BY MONTH
        public static int CalendarItemsByMonth_MaxRecords = 3;
        public static CalendarItemsByMonth CalendarItemsByMonth_FirstRecord = getCalendarItemsBy2018_01()[0];
        public static int CalendarItemsByMonth_FilteredByCat9_number = 2;
        public static CalendarItemsByMonth CalendarItemsByMonth_FirstRecord_FilteredCat9 = getCalendarItemsBy2018_01_filteredByCat9()[0];
        public static int CalendarItemsByMonth_2018_FilteredByCat9_number = 1;


        public static List<CalendarItemsByMonth> getCalendarItemsBy2018_01()
        {
            List<CalendarItemsByMonth> list = new List<CalendarItemsByMonth>();
            List<CalendarItem> CalendarItems = new List<CalendarItem>();

            CalendarItems.Add(CalendarItem1);
            CalendarItems.Add(CalendarItem2);


            list.Add(new CalendarItemsByMonth
            {
                Month = "2018/01",
                Items = CalendarItems,
                TotalBusyTime = CalendarItem1.DurationInMinutes + CalendarItem2.DurationInMinutes
            });
            return list;
        }

        public static List<CalendarItemsByMonth> getCalendarItemsBy2018_01_filteredByCat9()
        {
            List<CalendarItemsByMonth> list = new List<CalendarItemsByMonth>();
            List<CalendarItem> CalendarItems = new List<CalendarItem>();

            CalendarItems.Add(CalendarItem2);

            list.Add(new CalendarItemsByMonth
            {
                Month = "2018/01",
                Items = CalendarItems,
                TotalBusyTime = CalendarItem2.DurationInMinutes
            });
            return list;
        }



        // LIST EventS BY CATEGORY
        public static int CalendarItemsByCategory_MaxRecords = 3;
        public static CalendarItemsByCategory CalendarItemsByCategory_FirstRecord = getCalendarItemsByCategoryCat10()[0];
        public static int CalendarItemsByCategory_FilteredByCat10_number = 2;
        public static int CalendarItemsByCategory14 = 1;
        public static int CalendarItemsByCategory20 = 0;


        public static List<CalendarItemsByCategory> getCalendarItemsByCategoryCat10()
        {
            List<CalendarItemsByCategory> list = new List<CalendarItemsByCategory>();
            List<CalendarItem> CalendarItems = new List<CalendarItem>();

            CalendarItems.Add(CalendarItem1);
            CalendarItems.Add(CalendarItem3);


            list.Add(new CalendarItemsByCategory
            {
                Category = "Clothes",
                Items = CalendarItems,
                TotalBusyTime = CalendarItem1.DurationInMinutes+ CalendarItem3.DurationInMinutes
            });
            return list;
        }

        public static List<CalendarItemsByCategory> getCalendarItemsByCategory2018_Cat9()
        {
            List<CalendarItemsByCategory> list = new List<CalendarItemsByCategory>();
            List<CalendarItem> CalendarItems = new List<CalendarItem>();

            CalendarItems.Add(CalendarItem2);

            list.Add(new CalendarItemsByCategory
            {
                Category = "Credit Card",
                Items = CalendarItems,
                TotalBusyTime = CalendarItem2.DurationInMinutes
            });
            return list;
        }

        public static List<CalendarItemsByCategory> getCalendarItemsByCategory2018()
        {
            List<CalendarItemsByCategory> list = new List<CalendarItemsByCategory>();
            List<CalendarItem> CalendarItems = new List<CalendarItem>();

            CalendarItems.Add(CalendarItem1);

            list.Add(new CalendarItemsByCategory
            {
                Category = "Clothes",
                Items = CalendarItems,
                TotalBusyTime = CalendarItem1.DurationInMinutes
            });


            CalendarItems = new List<CalendarItem>();
            CalendarItems.Add(CalendarItem2);

            list.Add(new CalendarItemsByCategory
            {
                Category = "Credit Card",
                Items = CalendarItems,
                TotalBusyTime = CalendarItem2.DurationInMinutes
            });
            return list;
        }




        // LIST EventS BY CATEGORY AND MONTH
        public static int CalendarItemsByCategoryAndMonth_MaxRecords = 3; // 3 months

        public static Dictionary<string, object> getCalendarItemsByCategoryAndMonthFirstRecord()
        {
            List<CalendarItem> CalendarItems;

            Dictionary<string, object> dict = new Dictionary<string, object> {
                { "Month","2018/01" },{"Total", CalendarItem1.DurationInMinutes+CalendarItem2.DurationInMinutes }  };


            CalendarItems = new List<CalendarItem>();
            CalendarItems.Add(CalendarItem1);

            dict.Add("details:Clothes", CalendarItems);
            dict.Add("Clothes", CalendarItem1.DurationInMinutes);


            CalendarItems = new List<CalendarItem>();

            CalendarItems.Add(CalendarItem2);

            dict.Add("details:Credit Card", CalendarItems);
            dict.Add("Credit Card", CalendarItem2.DurationInMinutes);



            return dict;
        }

        public static Dictionary<string, object> getCalendarItemsByCategoryAndMonthTotalsRecord()
        {
            Dictionary<string, object> dict = new Dictionary<string, object> {
                { "Month","TOTALS" }  };
            dict.Add("Clothes", CalendarItem1.DurationInMinutes + CalendarItem3.DurationInMinutes);
            dict.Add("Credit Card", CalendarItem4.DurationInMinutes + CalendarItem2.DurationInMinutes);
            dict.Add("Eating Out", CalendarItem5.DurationInMinutes + CalendarItem7.DurationInMinutes);

            return dict;
        }

        public static List<Dictionary<string,object>> getCalendarItemsByCategoryAndMonthCat10()
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            List<CalendarItem> CalendarItems = new List<CalendarItem>();

            CalendarItems.Add(CalendarItem1);

            list.Add(new Dictionary<string, object> {
                {"Month","2018/01" },
                { "Clothes",CalendarItem1.DurationInMinutes},
                {"details:Clothes",CalendarItems },
                }
            );

            CalendarItems = new List<CalendarItem>();

            CalendarItems.Add(CalendarItem3);

            list.Add(new Dictionary<string, object> {
                {"Month","2019/01" },
                { "Clothes",CalendarItem3.DurationInMinutes},
                {"details:Clothes",CalendarItems },
                }
            );

            list.Add(new Dictionary<string, object> {
                {"Month","TOTALS" },
                { "Clothes",CalendarItem1.DurationInMinutes + CalendarItem3.DurationInMinutes},
                }
            );

            return list;
        }

 
        public static List<Dictionary<string,object>> getCalendarItemsByCategoryAndMonth2020()
        {
            List< Dictionary<string, object> > list = new List<Dictionary<string, object>>();

            list.Add(new Dictionary<string, object> {
                {"Month","2020/01" },
                { "Credit Card",CalendarItem4.DurationInMinutes},
                {"details:Credit Card",new List<CalendarItem>{CalendarItem4 } },
                {"Eating Out",CalendarItem5.DurationInMinutes + CalendarItem7.DurationInMinutes },
                {"details:Eating Out", new List<CalendarItem>{CalendarItem5, CalendarItem7} }
                }
            );

           list.Add(new Dictionary<string, object> {
                {"Month","TOTALS" },
                { "Credit Card",CalendarItem4.DurationInMinutes},
                { "Eating Out",CalendarItem5.DurationInMinutes + CalendarItem7.DurationInMinutes},
                }
            );



            return list;
        }
    }


}




