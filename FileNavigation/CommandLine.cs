using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static UtilitiesLibrary.DisplayText;

namespace FileNavigation
{
    public abstract class CommandLine
    {
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
    }
}
