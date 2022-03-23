using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;

namespace WeatherAlmanac.UI
{
    public class MenuController
    {
        private ConsoleIO _ui;
        public IRecordService Service;

        public MenuController(ConsoleIO ui, IRecordService service)
        {
            _ui = ui;
            Service = service;
        }

        public ApplicationMode Setup()
        {
            _ui.Display("Enter Application Mode:");
            _ui.Display("1. Test");
            _ui.Display("2. Live");

            int mode = _ui.GetInt("");
            if (mode == 1)
            {
                return ApplicationMode.TEST;
            }
            else if (mode == 2)
            {
                return ApplicationMode.LIVE;
            }
            else
            {
                _ui.Display("Invalid mode: Exiting... ");
                Environment.Exit(0);
                return ApplicationMode.TEST;
            }
        }

        public void Run()
        {
            Console.Clear();
            bool running = true;
            while (running)
            {
                switch (GetMenuChoice())
                {
                    case 1:
                        LoadRecord();
                        break;
                    case 2:
                        ViewRecordByDateRange();
                        break;
                    case 3:
                        AddRecord();
                        break;
                    case 4:
                        EditRecord();
                        break;
                    case 5:
                        DeleteRecord();
                        break;
                    case 6:
                        if (_ui.GetYesNo("Are you sure you want to quit (y/n): ") == "y")
                        {
                            running = false;
                            _ui.Display("\nExiting now...");
                        }
                        break;
                    default:
                        _ui.Error("Err: Invalid menu option!");
                        break;
                }
            }
        }

        public int GetMenuChoice()
        {
            DisplayMenu();
            return _ui.GetInt("Enter a Choice: ");
        }

        public void DisplayMenu()
        {
            _ui.Display("Main Menu");
            _ui.Display("===============================");
            _ui.Display("1. Load a Record");
            _ui.Display("2. View Records by Date Range");
            _ui.Display("3. Add a Record");
            _ui.Display("4. Edit a Record");
            _ui.Display("5. Delete a Record");
            _ui.Display("6. Quit");
        }

        public void LoadRecord()
        {
            _ui.Display("\nLoad Record");
            _ui.Display("===============================");

            // get the user input as a date 
            DateTime dateToLoad = _ui.GetDateTime("Enter Record Date: ");

            // use input to call service method
            Result<DateRecord> result = Service.Get(dateToLoad);

            // display either successful Get() or display not found message
            if (result.Success)
            {
                _ui.Display("\n" + result.Data.ToString());
            }
            else
            {
                _ui.Display("");
                _ui.Error(result.Message);
                _ui.Display("");
            }

        }
        public void ViewRecordByDateRange()
        {
            _ui.Display("\nLoad Records by Date Range");
            _ui.Display("===============================");

            // get the user input as a date 
            DateTime startDate = _ui.GetDateTime("Enter Start Date: ");
            DateTime endDate = _ui.GetDateTime("Enter End Date: ");
            Result<List<DateRecord>> result = Service.LoadRange(startDate, endDate);

            // display either successful Get() or display not found message
            if (result.Success)
            {
                foreach (DateRecord record in result.Data)
                {
                    _ui.Display("\n" + record.ToString());
                }
            }
            else
            {
                _ui.Display("");
                _ui.Error(result.Message);
                _ui.Display("");
            }

        }
        public void AddRecord()
        {
            _ui.Display("\nAdd a Record");
            _ui.Display("===============================");

            // get the user input as a date 
            DateRecord newDateRecord = new DateRecord();
            newDateRecord.Date = _ui.GetDateTime("Enter record Date: ");
            newDateRecord.HighTemp = _ui.GetDecimal("High: ");
            newDateRecord.LowTemp = _ui.GetDecimal("Low: ");
            newDateRecord.Humidity = _ui.GetDecimal("Humity: ");
            newDateRecord.Description = _ui.GetString("Description: ");

            // pass on newDateRecord
            Result<DateRecord> result = Service.Add(newDateRecord);

            // display either successful Get() or display not found message
            if (result.Success)
            {
                _ui.Success("\nAdd was successful.\n");
            }
            else
            {
                _ui.Display("");
                _ui.Error(result.Message);
                _ui.Display("");
            }


        }
        public void EditRecord()
        {
            _ui.Display("\nEdit a Record");
            _ui.Display("===============================");
            DateTime dateToEdit = _ui.GetDateTime("Enter Record Date: ");

            // Get record
            Result<DateRecord> result = Service.Get(dateToEdit);

            // if successful
               // prompt for new values
            if (result.Success)
            {
                DateRecord newDateRecord = new DateRecord();
                newDateRecord.Date = dateToEdit;
                newDateRecord.HighTemp = _ui.GetDecimal($"High ({result.Data.HighTemp}): ");
                newDateRecord.LowTemp = _ui.GetDecimal($"Low ({result.Data.LowTemp}): ");
                newDateRecord.Humidity = _ui.GetDecimal($"Humity ({result.Data.Humidity}): ");
                _ui.Display($"Old Description: {result.Data.Description}");
                newDateRecord.Description = _ui.GetString("New Description: ");
                Service.Edit(newDateRecord);
                _ui.Success("\nEdit was completed.\n ");
            }
            // else
            // display error message
            else
            {
                _ui.Display("");
                _ui.Error(result.Message);
                _ui.Display("");
            }
        }
        public void DeleteRecord()
        {
            _ui.Display("\nDelete a Record");
            _ui.Display("===============================");
            DateTime dateToDelete = _ui.GetDateTime("Enter Record Date: ");

            // Get record
            Result<DateRecord> result = Service.Get(dateToDelete);

            // if successful
            // display record
            // prompt y/n to delete
            if (result.Success)
            {
                _ui.Display(result.Data.ToString());
                if (_ui.GetYesNo("Are you sure you want to delete this record (y/n): ") == "y")
                {
                    Service.Remove(dateToDelete);
                    _ui.Success("\nRecord was removed.\n");
                }

                else
                {
                    _ui.Display("");
                    _ui.Error("Did not remove record.");
                    _ui.Display("");
                }
                    
            }
            // else
            // display error message
            else
            {
                _ui.Display("");
                _ui.Error(result.Message);
                _ui.Display("");
            }
        }
    }
}
