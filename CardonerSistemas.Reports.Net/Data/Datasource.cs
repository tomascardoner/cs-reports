using System.Data.Common;

namespace CardonerSistemas.Reports.Net.Data
{
    public static class Datasource
    {
        private static string GetProviderName(Model.Datasource.Providers provider) => provider switch
        {
            Model.Datasource.Providers.SqlServer => "Microsoft.Data.SqlClient",
            Model.Datasource.Providers.OleDb => "System.Data.OleDb",
            Model.Datasource.Providers.Odbc => "System.Data.Odbc",
            Model.Datasource.Providers.DataSet => "System.Data.DataSet",
            _ => string.Empty
        };

        // Given a provider name and connection string,
        // create the DbProviderFactory and DbConnection.
        // Returns a DbConnection on success; null on failure.
        private static DbConnection? CreateAndOpenConnection(Model.Datasource datasource)
        {
            ArgumentNullException.ThrowIfNull(datasource);

            // Assume failure.
            DbConnection? dbConnection = null;

            // Create the DbProviderFactory and DbConnection.
            try
            {
                switch (datasource.Provider)
                {
                    case Model.Datasource.Providers.None:
                        break;
                    case Model.Datasource.Providers.SqlServer:
                        DbProviderFactories.RegisterFactory(GetProviderName(datasource.Provider), Microsoft.Data.SqlClient.SqlClientFactory.Instance);
                        break;
                    case Model.Datasource.Providers.OleDb:
                        
                        break;
                    case Model.Datasource.Providers.Odbc:
                        
                        break;
                    case Model.Datasource.Providers.Oracle:
                        
                        break;
                    case Model.Datasource.Providers.DataSet:
                        
                        break;
                }
                DbProviderFactory factory = DbProviderFactories.GetFactory(GetProviderName(datasource.Provider));
                dbConnection = factory.CreateConnection();
                if (dbConnection is not null)
                {
                    dbConnection.ConnectionString = datasource.ConnectionString;
                    dbConnection.Open();
                }
            }
            catch (Exception ex)
            {
                // Set the connection to null if it was created.
                if (dbConnection is not null)
                {
                    dbConnection = null;
                }
                Console.WriteLine(ex.Message);
            }

            // Return the connection.
            return dbConnection;
        }

        private static DbDataReader? GetDataReader(DbConnection dbConnection, Model.Datasource datasource)
        {
            ArgumentNullException.ThrowIfNull(dbConnection);
            ArgumentNullException.ThrowIfNull(datasource);

            DbDataReader? dbDataReader = null;

            try
            {
                DbCommand dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandType = datasource.Type;
                dbCommand.CommandText = datasource.Text;
                foreach (Model.DatasourceParameter parameter in datasource.Parameters)
                {
                    DbParameter dbParameter = dbCommand.CreateParameter();
                    dbParameter.ParameterName = parameter.Name;
                    dbParameter.DbType = parameter.Type;
                    dbParameter.Value = parameter.Value;
                    dbCommand.Parameters.Add(dbParameter);
                }
                dbDataReader = dbCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dbDataReader;
        }

        public static void GetDatasource(Model.Report report, ref DbDataReader? dbDataReader, Dictionary<string, int> fieldsOrdinals)
        {
            if (report.Datasource is not null && report.Datasource.Provider != Model.Datasource.Providers.None && !string.IsNullOrEmpty(GetProviderName(report.Datasource.Provider)))
            {
                DbConnection? dbConnection = CreateAndOpenConnection(report.Datasource);
                if (dbConnection is not null)
                {
                    dbDataReader = GetDataReader(dbConnection, report.Datasource);
                    if (dbDataReader is not null)
                    {
                        if (dbDataReader.Read())
                        {
                            try
                            {
                                for (int columnIndex = 0; columnIndex < dbDataReader.FieldCount; columnIndex++)
                                {
                                    fieldsOrdinals.Add(dbDataReader.GetName(columnIndex), columnIndex);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                dbDataReader = null;
                                dbConnection.Close();
                            }
                        }
                        else
                        {
                            dbDataReader.Close();
                            dbDataReader = null;
                            dbConnection.Close();
                        }
                    }
                }
            }
        }
    }
}