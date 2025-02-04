using System.Text.Json.Serialization;

namespace CardonerSistemas.Reports.Net.Model
{
    public class DatasourceParameter
    {

        public string Name { get; set; } = string.Empty;

        public System.Data.DbType Type { get; set; }

        [JsonIgnore]
        public object? Value { get; set; }

    }
}