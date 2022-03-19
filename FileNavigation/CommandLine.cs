using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static UtilitiesLibrary.DisplayText;

namespace FileNavigation
{
    public class CommandLine
    {
        private List<List<string>> _commands = CommandsList.AllCommands;

        public void DisplayCurrentDirectory(string path)
        {
            Display(ConsoleColor.Green, path, true);
        }


        public string ChangeDirectory(string path,string destinationPath)
        {
            try
            {
                if (Directory.Exists(destinationPath))
                {
                    DisplayCurrentDirectory(destinationPath);
                    return destinationPath;
                }
                else
                {
                    DisplayErrorMsg("This directory doesn't exists.\nPlease enter a valid directory name.");
                    return path;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
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


        public int DisplayFunctionsList()
        {
            while (true)
            {
                try
                {
                    Display(ConsoleColor.Gray,"Choose the operation you want to do.\n\n");
                    Display(ConsoleColor.DarkBlue,"(1) Create\t(2) Read\t(3) Write\t(4) Delete\n\n");
                Display(ConsoleColor.Green,"=> ");
                    int operationNo = Convert.ToInt32(Console.ReadLine());
                    if(operationNo < 1 || operationNo > 4)
                    {
                        DisplayErrorMsg("Invalid choice.\nPlease try again.");
                    }
                    else
                    {
                        return operationNo;
                    }

                }
                catch (Exception e)
                {
                    DisplayErrorMsg($"Error : {e.Message}");
                }
            }
        }


        public void DisplayCommands()
        {
            int FuncNumber = DisplayFunctionsList();
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

    }
}
