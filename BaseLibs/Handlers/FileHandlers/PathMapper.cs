using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.Handlers.FileHandlers
{
   public class PathMapper
    {
        //public static void DBPathHandler()
        //{
        //    if (!Directory.Exists(ConstantVariables.CurrentAssemblyPath + "\\ProUI"))
        //    {
        //        if (!Directory.Exists(ConstantVariables.CurrentAssemblyPath + "\\ProUI\\Data"))
        //            Directory.CreateDirectory(ConstantVariables.CurrentAssemblyPath + "\\ProUI\\Data");
        //    }
        //    else
        //    {
        //        Directory.CreateDirectory(ConstantVariables.CurrentAssemblyPath + "\\ProUI");
        //        Directory.CreateDirectory(ConstantVariables.CurrentAssemblyPath + "\\ProUI\\Data");
        //    }
        //}

        public static void DBPathHandler()
        {
            string basePath = @"C:\ProUI";
            string dbPath = $"{basePath}\\Data";

            if (Directory.Exists(basePath))
            {
                if (!Directory.Exists(dbPath))
                    Directory.CreateDirectory(dbPath);
            }
            else
            {
                Directory.CreateDirectory(basePath);
                Directory.CreateDirectory(dbPath);
            }
        }
    }
}
