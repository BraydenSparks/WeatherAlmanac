using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;
using WeatherAlmanac.DAL;

namespace WeatherAlmanac.BLL
{
    public static class RecordServiceFactory
    {
        public static IRecordService GetRecordService(ApplicationMode mode)
        {
            if (mode == ApplicationMode.TEST)
            {
                return new RecordService(new MockRecordRepository());
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
