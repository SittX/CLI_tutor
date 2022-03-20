using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNavigation
{
    internal static class OperationDictionary
    {

        public static Dictionary<int, string> CreateDictionary()
        {
            Dictionary<int,string> operationDictionary = new Dictionary<int, string>();
            operationDictionary.Add(1, "Create");
            operationDictionary.Add(2, "Read");
            operationDictionary.Add(3, "Update");
            operationDictionary.Add(4, "Delete");
            operationDictionary.Add(5, "Exit");
            operationDictionary.Add(6, "Clear");

            return operationDictionary;
        }
    }
}
