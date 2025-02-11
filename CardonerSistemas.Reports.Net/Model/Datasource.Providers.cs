namespace CardonerSistemas.Reports.Net.Model
{
    public partial class Datasource
    {
        public enum Providers : byte
        {
            SqlServer = 1,
            OleDb = 2,
            Odbc = 3,
            Oracle = 4,
            DataSet = 5
        }
    }
}