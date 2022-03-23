using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;

namespace WeatherAlmanac.BLL
{
    public class RecordService : IRecordService
    {
        private IRecordRepository _repo;

        public RecordService(IRecordRepository repo)
        {
            _repo = repo;
        }

        public Result<List<DateRecord>> LoadRange(DateTime start, DateTime end)
        {
            Result<List<DateRecord>> result = new Result<List<DateRecord>>();
            // todo: check to see that start is before end date
            if (start > end)
            {
                result.Message = "Start date can not be greater than end date.";
                result.Success = false;
                return result; 
            }

            // todo: if no records found, return success false with not found message
            result = _repo.GetAll();
            

            // todo: filter records from repository get all based on date range
            List<DateRecord> listFromStartToEnd= new List<DateRecord>();
            foreach(DateRecord record in result.Data)
            {
                if(record.Date >= start && record.Date <= end)
                {
                    listFromStartToEnd.Add(record);
                }
            }

            // if no records found return false else return true and the new list of records
            if (listFromStartToEnd.Count == 0)
            {
                result.Message = "No records found.";
                result.Success = false;
                return result;
            }
            else
            {
                result.Data = listFromStartToEnd;
                result.Message = "";
                result.Success = true;
                return result;
            }
        }

        public Result<DateRecord> Get(DateTime date)
        {
            Result<DateRecord> result = new Result<DateRecord>();
            // todo: date cannot be in the future
            if (date > DateTime.Now)
            {
                result.Message = "Date cannot be in the future.";
                result.Success = false;
                return result;
            }

            // todo: find specific date in repository data or return success false with not found message
            Result<List<DateRecord>> currentList = _repo.GetAll();
            foreach( DateRecord record in currentList.Data)
            {
                if(record.Date == date)
                {
                    result.Data = record;
                    result.Message = "";
                    result.Success = true;
                    return result;
                }    
            }
            result.Message = "Date cannot be found.";
            result.Success = false;
            return result;
        }

        public Result<DateRecord> Add(DateRecord record)
        {
            Result<DateRecord> result = new Result<DateRecord>();
            // todo: date cannot be in the future
            if (record.Date > DateTime.Now)
            {
                result.Data = record;
                result.Message = "Date cannot be in the future.";
                result.Success = false;
                return result;
            }
            // todo: temperature range is -50 to 140
            if (record.LowTemp < -50 || record.LowTemp > record.HighTemp ||  record.HighTemp > 140)
            {
                result.Data = record;
                result.Message = "Invalid tempature range.";
                result.Success = false;
                return result;
            }
            // todo: humidity must be between 0 and 100
            if (record.Humidity < 0 || record.Humidity > 100)
            {
                result.Data = record;
                result.Message = "Humidity must be between 0 and 100.";
                result.Success = false;
                return result;
            }
            
            // data looks safe, pass it along
            return _repo.Add(record);
        }

        public Result<DateRecord> Remove(DateTime date)
        {
            // todo: pass through to IRecordRepository
                return _repo.Remove(date);
        }

        public Result<DateRecord> Edit(DateRecord record)
        {
            // todo: pass through to IRecordRepository, this should only not be successful if the date doesn't exist
            // which should have been caught when retrieving the record to edit.
                return _repo.Edit(record);
        }
    }
}