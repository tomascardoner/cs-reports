namespace CardonerSistemas.Reports.Net.Model
{
    public class ReportParameter
    {

        public string Name { get; set; } = string.Empty;

        public required Value.Types Type { get; set; }

        public object? Value { get; set; }

    }
}