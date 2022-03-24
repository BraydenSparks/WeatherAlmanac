using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;

namespace WeatherAlmanac.DAL
{
    public class DateRecordCSVFormatter : IDateRecordFormatter
    {
        public DateRecord Deserialize(string data)
        {
            DateRecord result = new DateRecord();

            string[] fields = data.Split(",");
            result.Date = DateTime.Parse(fields[0]);
            result.HighTemp = decimal.Parse(fields[1]);
            result.LowTemp = decimal.Parse(fields[2]);
            result.Humidity = decimal.Parse(fields[3]);
            result.Description = fields[4];

            return result;
        }

        public string Serialize(DateRecord record)
        {
            return $"{record.Date},{record.HighTemp},{record.LowTemp},{record.Humidity},{record.Description}";
        }
    }
}
