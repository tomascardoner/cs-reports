namespace CSReports.Model
{
    public class Datasource
    {
        public System.Data.CommandType Type { get; set; }

        public string Text { get; set; } = string.Empty;

        public virtual ICollection<DatasourceParameter> Parameters { get; set; } = [];
    }
}