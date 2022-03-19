using FileNavigation;
namespace FileNavigation
{
    internal class WindowCLI : ConsoleController
    {
        /// <summary>
        /// Get the current directory 
        /// Set the root directory
        /// Display the available functions of the application to the user in a loop
        /// Users should be able to choose the functions after they've finished the previous one
        /// </summary>


        public void Run()
        {
            while (!exit)
            {
                GetPaths();
                ActionMethods.DisplayCurrentDirectory(CurrentDirectory);
                GetFunctionsInput(5);
                if (!exit)
                {
                    DisplayCommands();
                    ProcessInput();
                    RunCommands();
                }
                ClearData();
            }
        }



    }
}
