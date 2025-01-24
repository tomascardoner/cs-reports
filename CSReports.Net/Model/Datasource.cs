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

        public string Text { get; set; } = string.Empty;

        public virtual ICollection<DatasourceParameter> Parameters { get; set; } = [];
    }
}