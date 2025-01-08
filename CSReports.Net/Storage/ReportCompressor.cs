using System.Text;

namespace CSReports.Storage
{
    internal static class ReportCompressor
    {
        internal static bool CompressAndSaveFile(string reportSerial, string filePath)
        {
            try
            {
                Encoding encoding = Encoding.UTF8;
                byte[] byteArray = encoding.GetBytes(reportSerial);
                using MemoryStream memoryStream = new(byteArray);
                using SharpCompress.Archives.GZip.GZipArchive archive = SharpCompress.Archives.GZip.GZipArchive.Create();
                archive.AddEntry("report", memoryStream);
                archive.SaveTo(filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}