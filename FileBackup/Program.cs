using System;
using System.Collections.Generic;

namespace FileBackup
{
    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {
            int processed = 0;
            List<FileFtp> filesFtp = Configuration.GetFilesDownload();
            foreach (FileFtp fileFtp in filesFtp)
            {
                //string sucess = FileBackup.Download(ftp, user, pass, filePath, file);
                string success = FileBackup.Download(fileFtp);
                Console.WriteLine(string.IsNullOrEmpty(success) ? "Fail" : string.Format("Success: {0}", success));
                Console.WriteLine(string.Format("Processed: {0} de {1}", ++processed, filesFtp.Count));
            }
            Console.ReadKey();
        }

        #endregion Private Methods
    }
}