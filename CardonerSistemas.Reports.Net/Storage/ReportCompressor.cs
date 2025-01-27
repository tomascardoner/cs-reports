using SharpCompress.Archives.GZip;
using System.Text;

namespace CardonerSistemas.Reports.Net.Storage
{
    internal static class ReportCompressor
    {
        internal static bool CompressAndSaveFile(string serializedReport, string filePath)
        {
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(serializedReport);
                using MemoryStream memoryStream = new(byteArray);
                using GZipArchive archive = GZipArchive.Create();
                archive.AddEntry("report.json", memoryStream);
                archive.SaveTo(filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static bool LoadAndDecompressFile(string filePath, out string serializedReport)
        {
            try
            {
                using GZipArchive archive = GZipArchive.Open(filePath);
                using Stream stream = archive.Entries.First().OpenEntryStream();
                using MemoryStream memoryStream = new();
                stream.CopyTo(memoryStream);
                serializedReport = Encoding.UTF8.GetString(memoryStream.ToArray());
                return true;
            }
            catch (Exception)
            {
                serializedReport = string.Empty;
                return false;
            }
        }
    }
}