using System.Text.Json.Serialization;

namespace CardonerSistemas.Reports.Net.Model;

public class DatasourceParameter
{

    public DatasourceParameter(Datasource datasource)
    {
        ParameterId = datasource.Parameters.Count == 0 ? (short)1 : (short)(datasource.Parameters.Max(p => p.ParameterId) + 1);
    }

    [JsonConstructor]
    public DatasourceParameter(short parameterId)
    {
        ParameterId = parameterId;
    }

    public short ParameterId { get; }

    public string Name { get; set; } = string.Empty;

    public System.Data.DbType Type { get; set; }

    [JsonIgnore]
    public object? Value { get; set; }

    [JsonIgnore]
    public string DisplayName => Name;

}
