using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UtilitiesLibrary.DisplayText;
namespace FileNavigation_v2
{
    internal abstract class CommandLine
    {
        // This class define the methods which should be available in all of the CommandLine classes like Window, Linux , MacOS
        private Dictionary<int, string> _CRUDChoicesDict = new Dictionary<int, string>();

        private Dictionary<string, Dictionary<string,string>> CommandsDict = new Dictionary<string, Dictionary<string,string>>();

        private Dictionary<string, string> CreateCommands = new Dictionary<string, string>();
        public CommandLine()
        {
            // Populate CRUDChoicesDict
            _CRUDChoicesDict.Add(1, "Create");
            _CRUDChoicesDict.Add(2, "Read");
            _CRUDChoicesDict.Add(3, "Update");
            _CRUDChoicesDict.Add(4, "Delete");
            _CRUDChoicesDict.Add(5, "Exit");

            // Populate the CommandsDict 
            #region
            //CommandsDict.Add("Create",new List<string>() 
            //{ 
            //    "Enter 'touch <FileName>' to create a file",
            //    "Enter 'mkdir <DirectoryName> to create a directory"
            //});

            //CommandsDict.Add("Read", new List<string>()
            //{
            //    "Enter 'ls' to list all the files in a directory ",
            //    "Enter 'cat <FileName>' to print all the contexts inside a file"
            //});

            //CommandsDict.Add("Update",new List<string>()
            //{
            //    "Enter 'cat <FileName> <text>' to append text to a file "
            //});

            //CommandsDict.Add("Delete", new List<string>()
            //{
            //    "Enter 'rm <fileName>' to delete a file",
            //    "Enter 'rmdir <fileName>' to remove a directory",
            //    "Enter 'rm -rf <fileName / DirectoryName>' to remove a directory recursively.\nWarning: all the files and directories that you deleted cannot be restored."
            //});
            #endregion
            CommandsDictionary cmdDict = new CommandsDictionary();
            CommandsDict.Add("Create",cmdDict.CreateCommands);
            CommandsDict.Add("Read",cmdDict.ReadCommands);
            CommandsDict.Add("Update",cmdDict.UpdateCommands);
            CommandsDict.Add("Delete",cmdDict.DeleteCommands);
            
        }

        protected void DisplayCRUD()
        {
           foreach(var choice in _CRUDChoicesDict)
            {
                Display(ConsoleColor.DarkGray,$"(({choice.Key}) {choice.Value}",true);
            }
        }

        protected void GetInputForCRUD(ref bool exit,ref string CRUDChoice)
        {
            // Use int data type for this input 
            int input;
            input = Convert.ToInt32(Console.ReadLine());
            if(input > _CRUDChoicesDict.Count)
            {
                DisplayErrorMsg("Please enter the available input.");
            }else if(input == 5)
            {
                exit = true;
            }
            else
            {
                CRUDChoice = _CRUDChoicesDict[input];
                exit = true;
            }
        }

        protected void DisplayCommands(string CRUDInput)
        {
            // CommandsDict has nested dictionary and we need to get value from that dictionary
            
            foreach (KeyValuePair<string, Dictionary<string,string>> command in CommandsDict)
            {
                // upperDict.Key => " Create "
                // upperDict.Value => innerDict
                // innerDict.Key => " touch "
                // innerDict.Value => "Enter touch to create a new file"

                var upperDict = command;
                var innerDict = upperDict.Value;
                if(upperDict.Key == CRUDInput)
                {
                    foreach(string cmd in innerDict.Values)
                    {
                        Console.WriteLine("Commands : " + cmd);
                    }
                }
            }
        }

        protected void GetInputForCmd()
        {
            string input = Console.ReadLine();
            foreach(KeyValuePair<string,Dictionary<string,string>> command in CommandsDict)
            {
                foreach(KeyValuePair<string,string> cmd in command.Value)
                {
                    if(input != cmd.Key)
                    {
                        Console.WriteLine("This command is not available");
                    }
                    else
                    {
                        Console.WriteLine("Check!");
                    }
                }
            }
        }
    }
}
