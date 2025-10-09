namespace CardonerSistemas.Reports.Net.Storage;

public static class FileSystem
{
    public static bool Load(string filePath, out Model.Report? report)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

        if (!ReportCompressor.LoadAndDecompressFile(filePath, out string reportSerial))
        {
            report = null;
            return false;
        }

        return ReportSerializer.Deserialize(reportSerial, out report);
    }

    public static bool Save(Model.Report report, string filePath)
    {
        ArgumentNullException.ThrowIfNull(report);
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

        return (report.Version >= Engine.Version.Report || Engine.Version.Update(report)) && ReportSerializer.Serialize(report, out string reportSerial) && ReportCompressor.CompressAndSaveFile(reportSerial, filePath);
    }
}
