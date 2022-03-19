using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNavigation
{
    internal class LinuxCLI : CommandLine, ICommandLine
    {
        public string CurrentDirectory { get; private set; }
        public string RootDirectory { get; private set; }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
