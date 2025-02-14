using System.Text.Json;

namespace CardonerSistemas.Reports.Net.Storage
{
    internal static class ReportSerializer
    {
        internal static bool Serialize(Model.Report report, out string reportSerial)
        {
            try
            {

                reportSerial = JsonSerializer.Serialize(report, new JsonSerializerOptions() { WriteIndented = true });
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
