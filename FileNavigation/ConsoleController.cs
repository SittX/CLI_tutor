using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static UtilitiesLibrary.DisplayText;

namespace FileNavigation
{
    public class ConsoleController
    {
        private List<List<string>> _commands = CommandsList.AllCommands;
        public int FuncNumber { get; private set; }
        public bool exit { get; private set; }
        public string CurrentCommand { get; private set; }
        public string CurrentOperationType { get; private set; }

        public void DisplayCurrentDirectory(string path)
        {
            Display(ConsoleColor.Green, path, true);
        }

        public void ChangeDirectory(string path,string destinationPath)
        {
            try
            {
                if (Directory.Exists(destinationPath))
                {
                    DisplayCurrentDirectory(destinationPath);
                    //return destinationPath;
                }
                else
                {
                    DisplayErrorMsg("This directory doesn't exists.\nPlease enter a valid directory name.");
                    //return path;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Error : {e.Message}");
                throw;
            }
        }

        public void PrintWorkingDirectory(string currentDir)
        {
            try
            {
                Display(ConsoleColor.DarkBlue,currentDir);
            }
            catch (Exception e)
            {
                DisplayErrorMsg(e.Message);
                throw;
            }
        }

        public void DisplayFunctionsList()
        {
         Display(ConsoleColor.Gray,"Choose the operation you want to do.\n\n");
         Display(ConsoleColor.DarkBlue,"(1) Create\t(2) Read\t(3) Write\t(4) Delete\n\n");
         Display(ConsoleColor.Green,"=> ");
        }

        public void DisplayCommands()
        {
            switch (FuncNumber)
            {
                case 1:
                     Display(ConsoleColor.Gray,"Create Commands :",true);
                    foreach(var command in _commands[0])
                    {
                        Display(ConsoleColor.DarkBlue,"# "+command + '\n');
                    }
                    break;
                case 2:
                    Display(ConsoleColor.Gray,"Read Commands :",true);
                    foreach (var command in _commands[1])
                    {
                        Display(ConsoleColor.DarkBlue,"# " + command + '\n');
                    }
                    break;
                case 3:
                    Display(ConsoleColor.Gray,"Update Commands :",true);
                    foreach (var command in _commands[2])
                    {
                        Display(ConsoleColor.DarkBlue,"# " + command + '\n');
                    }
                    break;
                case 4:
                    Display(ConsoleColor.Gray,"Delete Commands :",true);
                    foreach (var command in _commands[3])
                    {
                        Display(ConsoleColor.DarkBlue,"# " + command + '\n');
                    }
                    break;
                default:
                    break;
            }
        }

        public void GetFunctionsInput(int ListLength)
        {
            bool exitLoop = false;
            while(!exitLoop)
            try
            {
                DisplayFunctionsList();
                int input = Convert.ToInt32(System.Console.ReadLine());
                if(input >= ListLength)
                {
                    DisplayErrorMsg("Invalid input");
                    DisplayErrorMsg("Please try again.");
                    exitLoop = false;
                }
                else
                {
                        switch (input)
                        {
                            case 1:
                                CurrentOperationType = "Create";
                                break;
                            case 2:
                                CurrentOperationType = "Read";
                                break;
                            case 3:
                                CurrentOperationType = "Update";
                                break;
                            case 4:
                                CurrentOperationType = "Delete";
                                break;
                            default:
                                break;
                        }
                    FuncNumber = input;
                    exitLoop = true;
                }
            }
            catch (Exception e)
            {
                DisplayErrorMsg(e.Message);
                DisplayErrorMsg("Please try again.");
            }
        }

        public void GetCommand()
        {
            string input = Console.ReadLine();
            CurrentCommand = input;
        }

        public void InvokeCommand(string CurrentCommand)
        {

        }
    }
}
