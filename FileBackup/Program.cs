using System;
using System.Collections.Generic;

namespace FileBackup
{
    internal class Program
    {
        #region Static private

        private static void Main(string[] args)
        {
            int processed = 0;
            List<FileFtp> filesFtp = Configuration.GetFilesDownload();
            foreach (FileFtp fileFtp in filesFtp)
            {
                //string sucess = FileBackup.Download(ftp, user, pass, filePath, file);
                string sucess = FileBackup.Download(fileFtp);
                Console.WriteLine(string.IsNullOrEmpty(sucess) ? "Fail" : string.Format("Sucess: {0}", sucess));
                Console.WriteLine(string.Format("Processed: {0} de {1}", ++processed, filesFtp.Count));
            }
            Console.ReadKey();
        }

        #endregion
    }
}