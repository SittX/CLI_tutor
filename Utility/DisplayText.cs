using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesLibrary
{
    public static class DisplayText
    {
     public static void Display(ConsoleColor color, string text,bool wholeLine = false)
        {
            Console.ForegroundColor = color;
            if (wholeLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }
            Console.ResetColor();
        }

        public static void DisplayErrorMsg(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
        }


    }
}
