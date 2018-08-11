using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Handlers
{
   public class CopyFiles
    {
        
        public static void  Copydata()
        {
            string FolderPath = @"C:\ProUI";
            string DebugPath = Directory.GetCurrentDirectory();// Environment.GetFolderPath(Environment.SpecialFolder.);
            try
            {
                string DBName = "ProDB.db";
                string logoName = "v1pro.ico";
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

                if (!File.Exists(FolderPath + $"\\{DBName}"))
                {
                    File.Copy(DebugPath + $"\\{DBName}", FolderPath + $"\\{DBName}");
                }
            }
            catch { }
        }
    }
}
