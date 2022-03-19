using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileNavigation
{
    internal class App
    {
        private WindowCLI _window = new WindowCLI();

        public void Run()
        {
            CheckOS();
        }

        private void CheckOS()
        {
            if(OperatingSystem.IsMacOS() && OperatingSystem.IsLinux())
            {
                Console.WriteLine("Sorry our app is not currently working in MacOS and Linux distributions.");
            }else if (OperatingSystem.IsWindows())
            {
                _window.Run();
            }else
            {
                Console.WriteLine("Can't detect the OS. Please try again.");
            }
        }
            
    }
}
