using FileNavigation;
using static UtilitiesLibrary.IOMethods;
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
                DisplayCurrentDirectory(CurrentDirectory);
                GetOperationInput();
                // If the user didn't choose to exit the application, continue running the methods below
                if (!exit)
                {
                    DisplayCommands();
                    GetCommand();
                    RunCommands();
                    ClearData();
                }
            }
        }



    }
}
