using System.Text.Json;

namespace CardonerSistemas.Reports.Net.Storage
{
    internal static class ReportSerializer
    {
        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };

        internal static bool Serialize(Model.Report report, out string reportSerial)
        {
            try
            {

                reportSerial = JsonSerializer.Serialize(report, options);
                return true;
            }
            catch (Exception)
            {
                reportSerial = string.Empty;
                return false;
            }
        }

        internal static bool Deserialize(string reportSerial, out Model.Report? report)
        {
            try
            {
                report = JsonSerializer.Deserialize<Model.Report>(reportSerial);
                return true;
            }
            catch (Exception)
            {
                report = null;
                return false;
            }
        }
    }
}
