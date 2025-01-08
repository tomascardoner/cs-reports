namespace CSReports.Storage
{
    public static class FileSystem
    {
        public static bool Save(Model.Report report, string filePath)
        {
            ArgumentNullException.ThrowIfNull(report);
            ArgumentNullException.ThrowIfNullOrEmpty(filePath);

            if (!ReportSerializer.Serialize(report, out string reportSerial))
            {
                return false;
            }
            if (!ReportCompressor.CompressAndSaveFile(reportSerial, filePath))
            {
                return false;
            }
            return true;
        }
    }
}