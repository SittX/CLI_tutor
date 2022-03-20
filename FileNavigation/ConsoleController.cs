using System.Text;
using static UtilitiesLibrary.DisplayText;
using static UtilitiesLibrary.IOMethods;

namespace FileNavigation
{
    public abstract class ConsoleController
    {
        private List<List<string>> _commands = CommandsList.AllCommands;
        private Dictionary<int, string> _operationsDictionary = OperationDictionary.CreateDictionary();
        public bool exit { get; private set; } = false;
        private string CurrentCommand { get;  set; }
        private string CurrentOperation { get;  set; }
        private string UserInput { get;  set; }
        private int OperationNum { get;  set; }
        protected string CurrentDirectory { get; private set; }
        protected string RootDirectory { get;  private set; }

        protected void DisplayOperationTypes()
        {
         Display(ConsoleColor.Gray,"Choose the operation you want to do.\n\n");
        foreach(KeyValuePair<int,string> operation in _operationsDictionary)
            {
                Display(ConsoleColor.DarkBlue,$"({operation.Key}) {operation.Value}\t");
            }
         Display(ConsoleColor.Green,"\n\n=> ");
        }

        protected void DisplayCommands()
        {
            switch (OperationNum)
            {
                case 1:
                     Display(ConsoleColor.Gray,"Create Commands :",true);
                    foreach(var command in _commands[0])
                    {
                        Display(ConsoleColor.DarkBlue,"# "+command + '\n');
                    }
                    Display(ConsoleColor.Gray, "Press x to exit", true);
                    break;
                case 2:
                    Display(ConsoleColor.Gray,"Read Commands :",true);
                    foreach (var command in _commands[1])
                    {
                        Display(ConsoleColor.DarkBlue,"# " + command + '\n');
                    }
                    Display(ConsoleColor.Gray, "Press x to exit", true);
                    break;
                case 3:
                    Display(ConsoleColor.Gray,"Update Commands :",true);
                    foreach (var command in _commands[2])
                    {
                        Display(ConsoleColor.DarkBlue,"# " + command + '\n');
                    }
                    Display(ConsoleColor.Gray, "Press x to exit", true);
                    break;
                case 4:
                    Display(ConsoleColor.Gray,"Delete Commands :",true);
                    foreach (var command in _commands[3])
                    {
                        Display(ConsoleColor.DarkBlue,"# " + command + '\n');
                    }
                    Display(ConsoleColor.Gray, "Press x to exit", true);
                    break;
                default:
                    break;
            }
        }

        protected void GetOperationInput()
        {
            bool operationLoop = false;
            int operationListCount = _operationsDictionary.Count;

            /* Usage of While loop : get user input for operations 
             if getting input is successful , exit the loop and continue executing the rest of the application. If it's failed, restart the whole process again
             */
            while (!operationLoop)
            {
                    try
                    {
                        DisplayOperationTypes();

                        int input = Convert.ToInt32(Console.ReadLine());
                    OperationNum = input;
                        if(input > operationListCount)
                        {
                            DisplayErrorMsg("Invalid input.\nPlease try again.");
                            operationLoop = true;
                        }
                        else if (input == 5)
                        {
                        CurrentOperation = _operationsDictionary[input];
                        // exit variable is associated with the whole application
                        exit = true;
                        }
                        else
                        {
                            // Search the input value in _operationDictionary and assign to the     CurrentOperation property
                                string InputValue;
                                if(_operationsDictionary.TryGetValue(input, out InputValue))
                                {
                                    CurrentOperation = InputValue;
                                }
                                else
                                {
                                    DisplayErrorMsg("Invalid choice.\nPlease try again.");
                                }
                         }
                        // Exit the loop
                        operationLoop = true;
                    }
                    catch (Exception e)
                    {
                        DisplayErrorMsg(e.Message);
                        DisplayErrorMsg("Please try again.");
                    }
            }
        }

        protected void GetCommand() 
        {
            
            try
            {
                string input = Console.ReadLine().Trim();
                if (CurrentOperation == "Read" && input != "x")
                {
                    CurrentCommand = input;
                }
                else if (input.ToLower() == "x")
                {
                    Display(ConsoleColor.Gray,"Exit method",true);
                    Console.Clear();
                }
                else
                {
                    // split the input into 'command' and 'userInput' parts
                    string[] splitInput = input.Split(' ');
                    CurrentCommand = splitInput[0];
                    UserInput = splitInput[1];
                    // Check if the user input is a file or a directory 
                    //string userInput = splitInput[1];
                    //if (userInput.Contains('.'))
                    //{

                    //}
                }
            }
            catch (Exception e)
            {
                DisplayErrorMsg(e.Message);
            }
        }

        protected void RunCommands()
        {
            switch (CurrentCommand)
            {
                case "touch":
                    CreateFile(CurrentDirectory,UserInput);
                    break;
                case "mkdir":
                    CreateDirectory(CurrentDirectory, UserInput);
                    break;
                case "ls":
                    ListFiles(CurrentDirectory);
                    break;
                case "cat":
                    break;
                case "rm":
                    DeleteFile(CurrentDirectory, UserInput);
                    break;
                case "rmdir":
                    break;
            }
        }

        protected void GetPaths()
        {
            RootDirectory = UserDirectory.GetUserProfilePath(Environment.UserName);
            CurrentDirectory = RootDirectory;
        }

        protected void ClearData()
        {
            CurrentCommand = null;
            CurrentOperation = null;
            UserInput = null;
        }
    }
}
