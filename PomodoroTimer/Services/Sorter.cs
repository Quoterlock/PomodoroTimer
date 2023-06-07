using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PomodoroTimer.Views.StatisticView;

namespace PersonalBudget.Modules
{
    internal class Sorter
    {
        public static List<DataItemModel> sortByDate(List<DataItemModel> items)
        {
            List<DataItemModel> result = new List<DataItemModel>();
            int cycles = items.Count;
            for(int i = 0; i < cycles; i++)
            {
                DataItemModel min = getMinDate(items);
                result.Add(min);
                items.Remove(min);
            }
            return result;
        }

        private static DataItemModel getMinDate(List<DataItemModel> items)
        {
            if(items.Count == 0) return new DataItemModel();
            DataItemModel tmp = items[0];
            foreach (DataItemModel item in items)
            {
                if(DateTime.Parse(tmp.Date) < DateTime.Parse(item.Date))
                {
                    tmp = item;
                }
            }
            return tmp;
        }
    }
}
