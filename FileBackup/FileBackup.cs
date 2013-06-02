using System.IO;
using System.Net;

namespace FileBackup
{
    public class FileBackup
    {
        #region Public Methods

        public static string Download(string ftp, string user, string pass, string filePath, string file)
        {
            try
            {
                var ftpWebRequest = (FtpWebRequest)WebRequest.Create(string.Concat(ftp, filePath, file));
                ftpWebRequest.Credentials = new NetworkCredential(user, pass);

                ftpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpWebRequest.UsePassive = true;
                ftpWebRequest.UseBinary = true;
                ftpWebRequest.KeepAlive = true;

                var ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
                using (Stream responseStream = ftpWebResponse.GetResponseStream())
                    SaveStreamToFile(responseStream, file);
                ftpWebResponse.Close();
                return file;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Download(FileFtp file)
        {
            return Download(file.Ftp, file.User, file.Pass, file.FilePath, file.File);
        }

        #endregion Public Methods



        #region Private Methods

        private static void CopyStream(Stream inputStream, Stream outputStream)
        {
            var buffer = new byte[8 * 1024]; // 8KB
            int length = 0;
            while ((length = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                outputStream.Write(buffer, 0, length);
        }

        private static void SaveStreamToFile(Stream stream, string file)
        {
            using (Stream fileStream = File.OpenWrite(file))
                CopyStream(stream, fileStream);
        }

        #endregion Private Methods
    }
}