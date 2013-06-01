using System.Collections.Generic;
using System.IO;

namespace FileBackup
{
    public class Configuration
    {
        #region Static public

        public static List<FileFtp> GetFilesDownload()
        {
            var files = new List<FileFtp>();

            using (TextReader textReader = new StreamReader("FileBackup.txt"))
            {
                string ftp, user, pass, line;
                ftp = user = pass = line = string.Empty;

                while ((line = textReader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] itens = line.Split(';');

                    if (itens.Length == 3 && line.StartsWith("ftp://"))
                    {
                        ftp = itens[0];
                        user = itens[1];
                        pass = itens[2];
                    }

                    if (!string.IsNullOrEmpty(ftp) && itens.Length == 2 && line.StartsWith("/"))
                        files.Add(new FileFtp {Ftp = ftp, User = user, Pass = pass, FilePath = itens[0], File = itens[1]});
                }
            }

            return files;
        }

        #endregion
    }
}