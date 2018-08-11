using Ionic.Zip;
using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Handlers.CompressHandler
{
   public class ZipHandler
    {
        public static void Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
                    }
                }
            }
        }

        public static void DecompressDoNetZip(string filePath)
        {
            try
            {
                // FileInfo fileInfo = new FileInfo(filePath);
                using (ZipFile zip = ZipFile.Read(filePath))
                {
                    string baseDirectory = filePath.Substring(0, filePath.LastIndexOf('\\') + 1);
                    string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);
                    ZipEntry ev = zip.Entries.ElementAtOrDefault(0);
                    ev.ExtractWithPassword(baseDirectory, "test");
                }
            }
            catch (Exception ex)
            {
            }
        }


    }
}
