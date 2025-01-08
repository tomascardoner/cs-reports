namespace CSReports.Storage
{
    public static class FileSystem
    {
        public static bool Load(string filePath, out Model.Report? report)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(filePath);

            if (!ReportCompressor.LoadAndDecompressFile(filePath, out string reportSerial))
            {
                report = null;
                return false;
            }
            if (!ReportSerializer.Deserialize(reportSerial, out report))
            {
                return false;
            }
            return true;
        }


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