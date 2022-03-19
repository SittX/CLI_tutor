using static UtilitiesLibrary.DisplayText;

namespace FileNavigation
{
    public abstract class ConsoleController
    {
        private List<List<string>> _commands = CommandsList.AllCommands;
        public int FuncNumber { get; private set; }
        public bool exit { get; private set; } = false;
        public string CurrentCommand { get; private set; }
        public string CurrentOperationType { get; private set; }
        public string UserInput { get; private set; }
        public string FileExtension { get; private set; }
        protected string CurrentDirectory { get; private set; }
        protected string RootDirectory { get; private set; }

        protected void DisplayFunctionsList()
        {
         Display(ConsoleColor.Gray,"Choose the operation you want to do.\n\n");
         Display(ConsoleColor.DarkBlue,"(1) Create\t(2) Read\t(3) Write\t(4) Delete\t(5) Exit\n\n");
         Display(ConsoleColor.Green,"=> ");
        }

        protected void DisplayCommands()
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

        protected void GetFunctionsInput(int ListLength)
        {
            bool exitLoop = false;
            while(!exitLoop)
            try
            {
                DisplayFunctionsList();
                int input = Convert.ToInt32(System.Console.ReadLine());
                if(input > ListLength)
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
                            case 5:
                                CurrentOperationType = "Exit";
                                exit = true;
                                break;
                            case 6:
                                CurrentOperationType = "Clear";
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

        protected void ProcessInput() 
        {

            if (CurrentOperationType == "Create" || CurrentOperationType == "Delete" || CurrentOperationType == "Update")
            {
                string input = Console.ReadLine().Trim();
                int i = 0;
                int j = input.IndexOf(' ');
                while(i < j)
                {
                    CurrentCommand += input[i];
                    i++;
                }
                    while (j < input.Length)
                {
                    UserInput += input[j];
                    j++;
                }
            }
            else
            {
                string input = Console.ReadLine().Trim();
                CurrentCommand = input;
            }
        }

        protected void CheckingFileOrDirectory()
        {
            
        }

        protected void RunCommands()
        {
            switch (CurrentCommand)
            {
                case "touch":
                    ActionMethods.CreateFile(CurrentDirectory,UserInput);
                    break;
                case "mkdir":
                    ActionMethods.CreateDirectory(CurrentDirectory, UserInput);
                    break;
                case "ls":
                    ActionMethods.ListFiles(CurrentDirectory);
                    break;
                case "cat":
                    break;
                case "rm":
                    ActionMethods.DeleteFile(CurrentDirectory, UserInput);
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
            CurrentOperationType = null;
            UserInput = null;
        }
    }
}
