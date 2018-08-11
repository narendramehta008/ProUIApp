using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Handlers.FileHandlers
{
    public class FileHelper
    {
        public void FileWriter(string filePath, string data)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }

                Encoding encode = Encoding.GetEncoding("UTF-*");
                using (StreamWriter sw = new StreamWriter(filePath, true, encode))
                {
                    sw.WriteLine(data);
                }

            }
            catch { }
        }
    }
}
