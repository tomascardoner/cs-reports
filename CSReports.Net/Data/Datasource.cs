using System.Data.Common;

namespace CardonerSistemas.Reports.Net.Data
{
    internal static class Datasource
    {
        // Given a provider name and connection string,
        // create the DbProviderFactory and DbConnection.
        // Returns a DbConnection on success; null on failure.
        private static DbConnection? CreateAndOpenConnection(Model.Datasource datasource)
        {
            ArgumentNullException.ThrowIfNull(datasource);
            ArgumentNullException.ThrowIfNullOrEmpty(datasource.ProviderName);
            ArgumentNullException.ThrowIfNullOrEmpty(datasource.ConnectionString);

            // Assume failure.
            DbConnection? dbConnection = null;

            // Create the DbProviderFactory and DbConnection.
            try
            {
                DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
                DbProviderFactory factory = DbProviderFactories.GetFactory(datasource.ProviderName);
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

        internal static void GetDatasource(Model.Report report, ref DbDataReader? dbDataReader, Dictionary<string, int> fieldsOrdinals)
        {
            if (report.Datasource is not null)
            {
                DbConnection? dbConnection = Datasource.CreateAndOpenConnection(report.Datasource);
                if (dbConnection is not null)
                {
                    dbDataReader = Datasource.GetDataReader(dbConnection, report.Datasource);
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