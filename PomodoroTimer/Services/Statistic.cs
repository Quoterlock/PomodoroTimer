using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using PomodoroTimer.Models;

namespace PomodoroTimer.Services
{
    internal class Statistic
    {
        public static void addToDate(PomodoroModel item, string name)
        {
            if (!Directory.Exists(".\\Data")) Directory.CreateDirectory(".\\Data");
            // get today path
            string path = ".\\Data\\" + name;

            FileStream fileStream;

            // Create a FileStream to write the serialized data

            PomodoroModel pomodoro = getByName(name);
            item.TodayTime += pomodoro.TodayTime;
            item.TodayCount += pomodoro.TodayCount;

            // open stream
            fileStream = new FileStream(path, FileMode.Create);

            // Create a BinaryFormatter instance
            BinaryFormatter formatter = new BinaryFormatter();

            // Serialize the object and write it to the file
            formatter.Serialize(fileStream, item);

            // Close the file stream
            fileStream.Close();
        }

        public static PomodoroModel getByName(string name)
        {
            // Create a FileStream to read the serialized data
            string path = ".\\Data\\" + name;
            if(!File.Exists(path)) return new PomodoroModel { TodayCount = 0, TodayTime = 0 };

            FileStream fileStream = new FileStream(path, FileMode.Open);

            // Create a BinaryFormatter instance
            BinaryFormatter formatter = new BinaryFormatter();

            // Deserialize the object from the file
            PomodoroModel model = (PomodoroModel)formatter.Deserialize(fileStream);

            // Close the file stream
            fileStream.Close();

            return model;
        }

        public static int getTotalTime()
        {
            int totalSeconds = 0;
            foreach(string file in Directory.GetFiles(".\\Data"))
            {
                FileInfo info = new FileInfo(file);
                PomodoroModel model = getByName(info.Name);
                totalSeconds += model.TodayTime;
            }
            return totalSeconds;
        }

    }
}
