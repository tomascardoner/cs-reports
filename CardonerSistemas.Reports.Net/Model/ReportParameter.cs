using System.Text.Json.Serialization;

namespace CardonerSistemas.Reports.Net.Model;

public class ReportParameter
{

    public ReportParameter(Report report)
    {
        ParameterId = report.Parameters.Count == 0 ? (short)1 : (short)(report.Parameters.Max(p => p.ParameterId) + 1);
    }

    [JsonConstructor]
    public ReportParameter(short parameterId)
    {
        ParameterId = parameterId;
    }

    public short ParameterId { get; }

    public string Name { get; set; } = string.Empty;

    public required Value.Types Type { get; set; }

    public object? Value { get; set; }
}
