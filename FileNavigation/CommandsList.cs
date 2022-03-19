using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNavigation
{
    internal static class CommandsList
    {
        private static List<string> CreateCommands = new List<string>()
        {
            "Enter 'touch <FileName>' to create a file",
            "Enter 'mkdir <DirectoryName> to create a directory"
        };

         private static List<string> ReadCommands = new List<string>()
        {
           "Enter 'ls' to list all the files in a directory ",
           "Enter 'cat <FileName>' to print all the contexts inside a file",
        };

        private static List<string> UpdateCommands = new List<string>()
        {
            "Enter 'cat <FileName> <text>' to append text to a file "
        };

        private static List<string> DeleteCommands = new List<string>()
        {
            "Enter 'rm <fileName>' to delete a file",
            "Enter 'rmdir <fileName>' to remove a directory",
            "Enter 'rm -rf <fileName / DirectoryName>' to remove a directory recursively.\nWarning: all the files and directories that you deleted cannot be restored."
        };

        public static List<List<string>> AllCommands = new List<List<string>>()
        {
           CreateCommands,
           ReadCommands,
           UpdateCommands,
           DeleteCommands
        };
    }
}
