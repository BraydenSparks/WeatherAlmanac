using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAlmanac.Core.DTO;

namespace WeatherAlmanac.Core.Interface
{
    public interface IRecordService
    {
        Result<List<DateRecord>> LoadRange(DateTime start, DateTime end);     // Retrieves only records within range
        Result<DateRecord> Get(DateTime date);                              // Get only the record with the specified date
        Result<DateRecord> Add(DateRecord record);                          // Adds a record to storage
        Result<DateRecord> Remove(DateTime date);                           // Removes record for date
        Result<DateRecord> Edit(DateRecord record);
    }
}
