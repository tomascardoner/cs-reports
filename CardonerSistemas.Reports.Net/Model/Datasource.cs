using System.Text.Json.Serialization;

namespace CardonerSistemas.Reports.Net.Model
{
    public partial class Datasource
    {
        public Providers Provider { get; set; } = Providers.None;

        public string ProviderName => Provider switch
        {
            Providers.SqlServer => "Microsoft.Data.SqlClient",
            Providers.OleDb => "System.Data.OleDb",
            Providers.Odbc => "System.Data.Odbc",
            Providers.DataSet => "System.Data.DataSet",
            _ => string.Empty
        };

        public string ConnectionString { get; set; } = string.Empty;

        public System.Data.CommandType Type { get; set; }

        [JsonIgnore]
        public string TypeFriendlyName => Type switch
        {
            System.Data.CommandType.Text => Properties.Resources.StringDatasourceTypeTextFriendlyName,
            System.Data.CommandType.StoredProcedure => Properties.Resources.StringDatasourceTypeStoredProcedureFriendlyName,
            System.Data.CommandType.TableDirect => Properties.Resources.StringDatasourceTypeTableDirectFriendlyName,
            _ => string.Empty
        };

        public string Text { get; set; } = string.Empty;

        public virtual ICollection<DatasourceParameter> Parameters { get; set; } = [];

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
    }
}