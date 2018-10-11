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

            DirectoryInfo directorySource = new DirectoryInfo(startndeletePath);
            DirectoryInfo directoryDestination = new DirectoryInfo(zipPath);

            if (directorySource.GetFiles().Length != 0)
            {
                if (directoryDestination.GetFiles().Length == 0)
                {
                    CompressFile(startndeletePath, zipPath);
                    DeleteFileAllFiles(startndeletePath);
                }
                else
                {
                    DeleteFileAllFiles(zipPath);
                    CompressFile(startndeletePath, zipPath);
                    DeleteFileAllFiles(startndeletePath);
                }

            }
            
        }

        public static void CompressFile(string pathFrom, string pathTo)
        {
            ZipFile.CreateFromDirectory(pathFrom, pathTo + fileName);
        }

        public static void DeleteFileAllFiles(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
    }
}
