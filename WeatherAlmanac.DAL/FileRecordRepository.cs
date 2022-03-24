using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;

namespace WeatherAlmanac.DAL
{
    public class FileRecordRepository : IRecordRepository
    {
        private List<DateRecord> _records;
        private string _path;

        public FileRecordRepository()
        {
            _records = new List<DateRecord>();
            _path = Directory.GetCurrentDirectory() + "/Data/DateRecords.csv";
            DateRecordCSVFormatter csv = new DateRecordCSVFormatter();
            using (StreamReader sr = new StreamReader(_path))
            {
                string currentLine = sr.ReadLine();
                if(currentLine != null)
                {
                    currentLine = sr.ReadLine();
                }
                while(currentLine != null)
                {
                    DateRecord record = csv.Deserialize(currentLine.Trim());
                    _records.Add(record);
                    currentLine = sr.ReadLine();
                }
            }
        }

        public Result<List<DateRecord>> GetAll()
        {
            Result<List<DateRecord>> result = new Result<List<DateRecord>>();
            result.Success = true;
            result.Message = "";
            result.Data = new List<DateRecord>(_records);
            return result;
        }

        public Result<DateRecord> Add(DateRecord record)
        {
            // add record to list
            _records.Add(record);

            // return succeful result
            WriteToFile();
            Result<DateRecord> result = new Result<DateRecord>();
            result.Data = record;
            result.Message = "";
            result.Success = true;
            return result;
        }

        public Result<DateRecord> Remove(DateTime date)
        {
            Result<DateRecord> result = new Result<DateRecord>();
            int idx = 0;
            for (int i = 0; i < _records.Count; i++)
            {
                if (date == _records[i].Date)
                {
                    idx = i;
                }
            }

            WriteToFile();

            result.Data = _records[idx];
            result.Message = "";
            result.Success = true;
            _records.RemoveAt(idx);
            return result;
        }

        public Result<DateRecord> Edit(DateRecord record)
        {
            Result<DateRecord> result = new Result<DateRecord>();
            for (int i = 0; i < _records.Count; i++)
            {
                if (record.Date == _records[i].Date)
                {
                    _records[i] = record;
                    result.Data = record;
                }
            }

            WriteToFile();

            result.Message = "";
            result.Success = true;
            return result;
        }

        public void WriteToFile()
        {
            //string p = @"D:\Brayden\Dev10 Trainning\Result.csv";

            DateRecordCSVFormatter csv = new DateRecordCSVFormatter();
            File.WriteAllText(_path, "Date,HighTemp,LowTemp,Humidity,Description");

            bool appendMode = true;
            using (StreamWriter sw = new StreamWriter(_path,appendMode))
            {
                foreach(DateRecord record in _records)
                {
                    sw.Write($"\n{csv.Serialize(record)}");
                }
            }
        }
    }
}
