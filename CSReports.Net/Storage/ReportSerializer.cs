using System.Text.Json;

namespace CSReports.Storage
{
    internal static class ReportSerializer
    {
        internal static bool Serialize(Model.Report report, out string reportSerial)
        {
            try
            {

#pragma warning disable CA1869 // Cache and reuse 'JsonSerializerOptions' instances
                reportSerial = JsonSerializer.Serialize(report, new JsonSerializerOptions() { WriteIndented = true });
                return true;
#pragma warning restore CA1869 // Cache and reuse 'JsonSerializerOptions' instances
            }
            catch (Exception)
            {
                reportSerial = string.Empty;
                return false;
            }
        }
    }
}
