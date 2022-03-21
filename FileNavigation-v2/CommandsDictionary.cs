using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNavigation_v2
{
    internal class CommandsDictionary
    {
        public Dictionary<string, string> CreateCommands = new Dictionary<string, string>();
        public Dictionary<string, string> ReadCommands = new Dictionary<string, string>();
        public Dictionary<string, string> UpdateCommands = new Dictionary<string, string>();
        public Dictionary<string, string> DeleteCommands = new Dictionary<string, string>();

        public CommandsDictionary()
        {
            populateCreateCommandDict();
            populateReadCommandDict();
            populateUpdateCommandDict();
            populateDeleteCommandDict();
        }

        private void populateCreateCommandDict()
        {
            CreateCommands.Add("touch", "Enter 'touch <FileName>' to create a file");
            CreateCommands.Add("mkdir", "Enter 'mkdir <DirectoryName> to create a directory");
        }

        private void populateReadCommandDict()
        {
            ReadCommands.Add("ls", "Enter 'ls' to list all the files in a directory ");
            ReadCommands.Add("cat", "Enter 'cat <FileName>' to print all the contexts inside a file");
        }

        private void populateUpdateCommandDict()
        {
            UpdateCommands.Add("cat","Enter 'cat <FileName> <text>' to append text to a file ");
        }

        private void populateDeleteCommandDict()
        {
            DeleteCommands.Add("rm","Enter 'rm <fileName>' to delete a file");
            DeleteCommands.Add("rmdir","Enter 'rmdir <DirectoryName>' to delete a directory");
        }

    }
}
