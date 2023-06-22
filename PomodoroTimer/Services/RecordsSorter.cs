using PomodoroTimer.Models;
using System;
using System.Collections.Generic;

namespace PersonalBudget.Modules
{
    internal class RecordsSorter
    {
        private const int FIRST_ELEMENT = 0;
        const string DATE_FORMAT = "dd-MM-yyyy";

        public static List<RecordItem> SortItemsDate(List<RecordItem> items)
        {
            try
            {
                List<RecordItem> sortedItems = new List<RecordItem>();
                int itemsCount = items.Count;
                for (int i = 0; i < itemsCount; i++)
                {
                    RecordItem maxItem = getItemWithMaxDate(items);
                    sortedItems.Add(maxItem);
                    items.Remove(maxItem);
                }
                return sortedItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static RecordItem getItemWithMaxDate(List<RecordItem> records)
        {            
            try
            {
                return findItemWithMaxDateInList(records);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static RecordItem findItemWithMaxDateInList(List<RecordItem> records)
        {
            if (records.Count > 0)
            {
                RecordItem currentMaxRecord = records[FIRST_ELEMENT];
                foreach (RecordItem record in records)
                    if (DateTime.ParseExact(currentMaxRecord.Date, DATE_FORMAT, null) < DateTime.ParseExact(record.Date, DATE_FORMAT, null))
                        currentMaxRecord = record;
                return currentMaxRecord;
            }
            else
            {
                throw new Exception("Recods list is empty!");
            }
        }
    }
}
