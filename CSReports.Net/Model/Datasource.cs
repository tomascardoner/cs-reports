namespace CSReports.Model
{
    public class Datasource
    {
        public string ProviderName { get; set; } = string.Empty;

        public string ConnectionString { get; set; } = string.Empty;

        public System.Data.CommandType Type { get; set; }

        public string Text { get; set; } = string.Empty;

        public virtual ICollection<DatasourceParameter> Parameters { get; set; } = [];
    }
}