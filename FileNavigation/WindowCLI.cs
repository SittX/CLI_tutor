using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileNavigation;
using UtilitiesLibrary;

namespace FileNavigation
{
    internal class WindowCLI : CommandLine,ICommandLine
    {
        /// <summary>
        /// Get the current directory 
        /// Set the root directory
        /// Display the available functions of the application to the user in a loop
        /// Users should be able to choose the functions after they've finished the previous one
        /// </summary>
        public string CurrentDirectory { get; private set; }
        public string RootDirectory { get; private set; }

        public void Run()
        {
            GetPaths();
            DisplayCommands();
        }

        public void GetPaths()
        {
            RootDirectory = UserDirectory.GetUserProfilePath(Environment.UserName);
            CurrentDirectory = RootDirectory;
        }


    }
}
