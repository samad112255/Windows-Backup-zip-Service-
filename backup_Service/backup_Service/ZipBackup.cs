using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Configuration;
namespace backup_Service
{
    class ZipBackup
    {
        public static string startndeletePath = ConfigurationManager.AppSettings["from"].ToString();
        public static string fileName = ConfigurationManager.AppSettings["fileName"].ToString();
        public static string zipPath = (ConfigurationManager.AppSettings["to"]).ToString();

        public static void BackupAndDelete()
        {
            
          
            try
            {
                CompressFile(startndeletePath, zipPath);
                DeleteFile(startndeletePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void CompressFile(string pathFrom, string pathTo)
        {
            ZipFile.CreateFromDirectory(pathFrom, pathTo + fileName + DateTime.Now.ToString("yyyy-MM-dd h:mm tt"));
        }

        public static void DeleteFile(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
    }
}
