using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PomodoroTimer.Models;

namespace PomodoroTimer.Services
{
    /// <summary>
    /// Class for calculating statistic of Pomadoro records
    /// </summary>
    internal class RecordsManager
    {
        /// <summary>
        /// Add new record or append
        /// </summary>
        /// <param name="item">Pomodoro record</param>
        /// <param name="name">File name</param>
        public static void addToDate(PomodoroModel item, string name)
        {
            // check if directory exist
            if (!Directory.Exists(".\\Data")) Directory.CreateDirectory(".\\Data");
            // get today path
            string path = ".\\Data\\" + name;

            // get record by name
            PomodoroModel pomodoro = getByName(name);
            // append
            item.TodayTime += pomodoro.TodayTime;
            item.TodayCount += pomodoro.TodayCount;

            // create a FileStream to write the serialized data
            FileStream fileStream = new FileStream(path, FileMode.Create);

            // create a BinaryFormatter instance
            BinaryFormatter formatter = new BinaryFormatter();

            // serialize the object and write it to the file
            formatter.Serialize(fileStream, item);

            // close the file stream
            fileStream.Close();
        }

        /// <summary>
        /// Get item by name
        /// </summary>
        /// <param name="name">File name</param>
        /// <returns>Pomodoro record</returns>
        public static PomodoroModel getByName(string name)
        {
            // Create a FileStream to read the serialized data
            string path = ".\\Data\\" + name;

            // if file don't exist -> create new empty record
            if(!File.Exists(path)) return new PomodoroModel { TodayCount = 0, TodayTime = 0 };

            // open file stream
            FileStream fileStream = new FileStream(path, FileMode.Open);

            // create a BinaryFormatter instance
            BinaryFormatter formatter = new BinaryFormatter();

            // deserialize the object from the file
            PomodoroModel model = (PomodoroModel)formatter.Deserialize(fileStream);

            // close the file stream
            fileStream.Close();

            return model;
        }

        /// <summary>
        /// Get total time of all records
        /// </summary>
        /// <returns>count of seconds</returns>
        public static int getTotalTime()
        {
            int totalSeconds = 0;
            // for every file in directory
            foreach(string file in Directory.GetFiles(".\\Data"))
            {
                FileInfo info = new FileInfo(file);
                PomodoroModel model = getByName(info.Name);
                totalSeconds += model.TodayTime; // sum time
            }
            return totalSeconds; // return result time
        }

    }
}
