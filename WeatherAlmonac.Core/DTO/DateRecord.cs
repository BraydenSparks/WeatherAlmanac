using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAlmanac.Core.DTO
{
    public class DateRecord
    {
        public DateTime Date { get; set; }
        public decimal HighTemp { get; set; }
        public decimal LowTemp { get; set; }
        public decimal Humidity { get; set; }
        public string Description { get; set; }
    }
}
