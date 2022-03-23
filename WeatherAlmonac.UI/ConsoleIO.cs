using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAlmanac.UI
{
    public class ConsoleIO
    {
        public int GetInt(string message)
        {
            int result = -1;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"{message}");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a proper integer\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public DateTime GetDateTime(string message)
        {
            DateTime result = new DateTime();
            bool valid = false;
            while (!valid)
            {
                Console.Write($"{message}");
                if (!DateTime.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a valid DateTime\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }

        public decimal GetDecimal(string message)
        {
            decimal result = -1m;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"{message}");
                if (!Decimal.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a valid decimal\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }

        public string GetString(string message)
        {
            string result = "";
            bool valid = false;
            while (!valid)
            {
                Console.Write(message);
                result = Console.ReadLine();
                if (string.IsNullOrEmpty(result))
                {
                    Error("Invalid string! input was null or empty.\n\n");
                }
                else
                {
                    valid = true;
                }
                
            }
            return result;
        }

        public string GetYesNo(string message)
        {
            string result = "";
            bool valid = false;
            while (!valid)
            {
                Console.Write(message);
                result = Console.ReadLine().Trim().ToLower();
                if(result != "y" && result != "n")
                {
                    Error("Invalid response! use Y or N\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }
    }
}