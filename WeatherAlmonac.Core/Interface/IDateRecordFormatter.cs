using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAlmanac.Core.DTO;

namespace WeatherAlmanac.Core.Interface
{
    public interface IDateRecordFormatter
    {
        DateRecord Deserialize(string data);
        string Serialize(DateRecord record);
    }
}
