using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAlmanac.Core.DTO;

namespace WeatherAlmanac.Core.Interface
{
    public interface IRecordRepository
    {
        Result<List<DateRecord>> GetAll();          // Retrieves all records from storage
        Result<DateRecord> Add(DateRecord record);  // Adds a record to storage
        Result<DateRecord> Remove(DateTime date);   // Removes record for date
        Result<DateRecord> Edit(DateRecord record); // Replaces a record with the same date
    }
}