using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PomodoroTimer.Models;

namespace PomodoroTimer.Services
{
    internal class PomodoroRecordsStatictic
    {
        private const string DATA_FOLDER_PATH= ".\\Data";
        public static void append(PomodoroModel record, string fileName)
        {
            if (!Directory.Exists(DATA_FOLDER_PATH))
                Directory.CreateDirectory(DATA_FOLDER_PATH);

            string filePath = DATA_FOLDER_PATH + "\\" + fileName;
            PomodoroModel prevRecord = getRecordFromFile(fileName);
            record.TodayTime += prevRecord.TodayTime;
            record.TodayCount += prevRecord.TodayCount;
            createNewRecordFile(record, filePath);
        }
        public static PomodoroModel getRecordFromFile(string fileName)
        {
            PomodoroModel record;
            string filePath = DATA_FOLDER_PATH + "\\" + fileName;

            if (File.Exists(filePath))
            {
                FileStream fileStream = new FileStream(filePath, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                record = (PomodoroModel)formatter.Deserialize(fileStream);
                fileStream.Close();
            }
            else
            {
                record = new PomodoroModel { TodayCount = 0, TodayTime = 0 };
            }
            return record;
        }
        public static int getRecordsTotalTime()
        {
            int totalSeconds = 0;

            foreach(string file in Directory.GetFiles(DATA_FOLDER_PATH))
            {
                FileInfo fileInfo = new FileInfo(file);
                PomodoroModel record = getRecordFromFile(fileInfo.Name);
                totalSeconds += record.TodayTime;
            }
            return totalSeconds;
        }
        private static void createNewRecordFile(PomodoroModel record, string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, record);
            fileStream.Close();
        }
    }
}
