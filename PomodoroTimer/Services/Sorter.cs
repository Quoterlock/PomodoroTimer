﻿using System;
using System.Collections.Generic;
using static PomodoroTimer.Views.StatisticView;

namespace PersonalBudget.Modules
{
    /// <summary>
    /// Sorter for data row items
    /// </summary>
    internal class Sorter
    {
        /// <summary>
        /// Sort list by date
        /// </summary>
        /// <param name="items">List of items</param>
        /// <returns>sorted list</returns>
        public static List<DataItemModel> sortByDate(List<DataItemModel> items)
        {
            try
            {
                // create new list
                List<DataItemModel> result = new List<DataItemModel>();
                // counter
                int cycles = items.Count;
                // for every item
                for (int i = 0; i < cycles; i++)
                {
                    // find min in unsorted of list
                    DataItemModel min = getMaxDate(items);
                    // add to sorted list
                    result.Add(min);
                    // remove this item from unsorted list
                    items.Remove(min);
                }
                return result; // return result
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Find max date value in list
        /// </summary>
        /// <param name="items">list of items</param>
        /// <returns>item with max date</returns>
        private static DataItemModel getMaxDate(List<DataItemModel> items)
        {
            string format = "dd-MM-yyyy";
            // if list is empty -> return default
            if (items.Count == 0) return new DataItemModel();
            // start with first item
            DataItemModel tmp = items[0];
            // chech elements
            try
            {
                foreach (DataItemModel item in items)
                    if (DateTime.ParseExact(tmp.Date, format, null) < DateTime.ParseExact(item.Date, format, null))
                        tmp = item; // update current max
                return tmp; // return current max
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
