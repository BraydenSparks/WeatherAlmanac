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
            // todo: check to see that start is before end date
            // todo: filter records from repository get all based on date range
            // todo: if no records found, return success false with not found message
            throw new NotImplementedException();
        }

        public Result<DateRecord> Get(DateTime date)
        {
            // todo: date cannot be in the future
            throw new NotImplementedException();
            // todo: find specific date in repository data or return success false with not found message
        }

        public Result<DateRecord> Add(DateRecord record)
        {
            // todo: date cannot be in the future
            // todo: temperature range is -50 to 140
            // todo: humidity must be between 0 and 100
            throw new NotImplementedException();
        }

        public Result<DateRecord> Remove(DateTime date)
        {
            // todo: pass through to IRecordRepository
            throw new NotImplementedException();
        }

        public Result<DateRecord> Edit(DateRecord record)
        {
            // todo: pass through to IRecordRepository, this should only not be successful if the date doesn't exist
            // which should have been caught when retrieving the record to edit.
            throw new NotImplementedException();
        }

    }
}