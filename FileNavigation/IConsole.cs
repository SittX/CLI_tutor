using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNavigation
{
    internal interface IConsole
    {
         string CurrentDirectory { get; }
         string RootDirectory { get; }
         void Run();
    }
}
