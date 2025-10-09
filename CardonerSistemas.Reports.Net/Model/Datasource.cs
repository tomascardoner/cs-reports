using System.Text.Json.Serialization;

namespace CardonerSistemas.Reports.Net.Model;

public partial class Datasource
{
    public Providers Provider { get; set; }

    public string ConnectionString { get; set; } = string.Empty;

    public System.Data.CommandType Type { get; set; }

    public string Text { get; set; } = string.Empty;

    public ICollection<DatasourceParameter> Parameters { get; set; } = [];

    public ICollection<DatasourceField> Fields { get; set; } = [];

    public bool SetParameterValue(string parameterName, object? value)
    {
        DatasourceParameter? parameter = Parameters.FirstOrDefault(p => p.Name == parameterName);
        if (parameter is not null)
        {
            parameter.Value = value;
            return true;
        }

        return false;
    }

    [JsonIgnore]
    public string DisplayName => FriendlyNames.GetDatasourceType(Type) + (Type != System.Data.CommandType.Text ? " => " + Text : string.Empty);
}
