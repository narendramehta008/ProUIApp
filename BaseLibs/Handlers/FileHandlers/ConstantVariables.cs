using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.Handlers.FileHandlers
{
    public class ConstantVariables
    {
        public static string CurrentAssemblyPath = Directory.GetCurrentDirectory();
        public static string DBPath { get; set; } = Directory.GetCurrentDirectory() + "\\ProUI\\Data\\ProUIDB.db";
       // public static string DBPath = @"C:\ProUI\Data\ProUIAppDB.db";//@"D:\ProUI\Data\ProUIAppDB.db";

    }
}
