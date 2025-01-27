namespace CardonerSistemas.Reports.Net.Model
{
    public partial class Datasource
    {
        public enum Providers
        {
            None = 0,
            SqlServer = 1,
            OleDb = 2,
            Odbc = 3,
            Oracle = 4,
            DataSet = 5
        }
    }
}