using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;

namespace WeatherAlmanac.DAL
{
    public class MockRecordRepository : IRecordRepository
    {
        private List<DateRecord> _records;

        public MockRecordRepository()
        {
            _records = new List<DateRecord>();
            DateRecord bogus = new DateRecord();
            bogus.Date = DateTime.Today;
            bogus.HighTemp = 82;
            bogus.LowTemp = 40;
            bogus.Humidity = .30m;
            bogus.Description = "Really inconsistent weather today";
            _records.Add(bogus);
        }

        public Result<DateRecord> Add(DateRecord record)
        {
            // add record to list
            _records.Add(record);

            // return succeful result
            Result<DateRecord> result = new Result<DateRecord>();
                result.Data = record;
                result.Message = "";
                result.Success = true;
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
            result.Message = "";
            result.Success = true;
            return result;
        }

        public Result<List<DateRecord>> GetAll()
        {
            Result<List<DateRecord>> result = new Result<List<DateRecord>>();
            result.Success = true;
            result.Message = "";
            result.Data = new List<DateRecord>(_records);
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
            _records.RemoveAt(idx);
            result.Message = "";
            result.Success = true;
            return result;
        }
    }
}
