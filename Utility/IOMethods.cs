using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UtilitiesLibrary.DisplayText;

namespace UtilitiesLibrary
{
    public static class IOMethods
    {
        public static void DisplayCurrentDirectory(string path)
        {
            Display(ConsoleColor.Green, path, true);
        }

        public static void ChangeDirectory(string path, string destinationPath)
        {
            try
            {
                if (Directory.Exists(destinationPath))
                {
                    DisplayCurrentDirectory(destinationPath);
                    //return destinationPath;
                }
                else
                {
                    DisplayErrorMsg("This directory doesn't exists.\nPlease enter a valid directory name.");
                    //return path;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Error : {e.Message}");
                throw;
            }
        }

        public static void PrintWorkingDirectory(string currentDir)
        {
            try
            {
                Display(ConsoleColor.DarkBlue, currentDir);
            }
            catch (Exception e)
            {
                DisplayErrorMsg(e.Message);
                throw;
            }
        }

        public static void CreateFile(string path, string fileName)
        {
            try
            {
                string filePath = $"{path}/{fileName}";
                File.Create(filePath);
            }
            catch (Exception e)
            {
                DisplayErrorMsg($"Error : {e.Message}");
                throw;
            }
        }

        public static void CreateDirectory(string path, string dirName)
        {
            try
            {
                string dirPath = $"{path}/{dirName}";
                Directory.CreateDirectory(dirPath);
            }
            catch (Exception e)
            {
                DisplayErrorMsg($"Error : {e.Message}");
                throw;
            }
        }

        public static void ListFiles(string path)
        {
            try
            {
                string[] files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    Display(ConsoleColor.Cyan, file, true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void DeleteFile(string path, string fileName)
        {
            try
            {
                string filePath = $"{path}/{fileName}";
                File.Delete(filePath);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
