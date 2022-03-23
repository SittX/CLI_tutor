using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UtilitiesLibrary.UserDirectory;

namespace FileNavigation_v2
{
    internal class Window : CommandLine
    {
        public string CurrentDirectory { get; private set; }
        public string RootDirctory { get; private set; }
        private string CRUDInput;
        private string Command;
        public Window()
        {
            RootDirctory = GetUserProfilePath(Environment.UserName);
            CurrentDirectory = RootDirctory;
        }
        
        public void Run()
        {
            CRUDFunc();
        }

        public void CRUDFunc()
        {
            // exit variable only associated with the CRUDFunc method
            bool exit = false;
            while (!exit)
            {
                DisplayCRUD();
                GetInputForCRUD(ref exit,ref CRUDInput);
                DisplayCommands(CRUDInput);
                GetInputForCmd();
            }
        }
    }
}
