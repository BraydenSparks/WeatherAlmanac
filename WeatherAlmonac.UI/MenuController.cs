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
                        running = false;
                        break;
                    default:
                        _ui.Display("Err: Invalid menu option!");
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
            _ui.Display("Load a Record");
        }
        public void ViewRecordByDateRange()
        {
            _ui.Display("View Records by Date Range");
        }
        public void AddRecord()
        {
            _ui.Display("Add a Record");
        }
        public void EditRecord()
        {
            _ui.Display("Edit a Record");
        }
        public void DeleteRecord()
        {
            _ui.Display("Delete a Record");
        }

    }
}
