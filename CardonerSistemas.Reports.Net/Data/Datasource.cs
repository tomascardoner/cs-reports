using System.Data.Common;

namespace CardonerSistemas.Reports.Net.Data;

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
    private static DbConnection? CreateAndOpenConnection(Model.Datasource datasource, string connectionStringToOverride)
    {
        ArgumentNullException.ThrowIfNull(datasource);

        // Assume failure.
        DbConnection? dbConnection = null;

        // Create the DbProviderFactory and DbConnection.
        try
        {
            switch (datasource.Provider)
            {
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
                case Model.Datasource.Providers.None:
                    break;
                default:
                    break;
            }

            DbProviderFactory factory = DbProviderFactories.GetFactory(GetProviderName(datasource.Provider));
            dbConnection = factory.CreateConnection();
            if (dbConnection is not null)
            {
                dbConnection.ConnectionString = string.IsNullOrEmpty(connectionStringToOverride) ? datasource.ConnectionString : connectionStringToOverride;
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
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            dbCommand.CommandText = datasource.Text.Replace("'", "''", StringComparison.Ordinal);
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            foreach (Model.DatasourceParameter parameter in datasource.Parameters)
            {
                DbParameter dbParameter = dbCommand.CreateParameter();
                dbParameter.ParameterName = parameter.Name;
                dbParameter.DbType = parameter.Type;
                dbParameter.Value = parameter.Value ?? DBNull.Value;
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

    private static bool GetDatasourceFields(DbDataReader dbDataReader, Model.Datasource datasource)
    {
        ArgumentNullException.ThrowIfNull(dbDataReader);
        ArgumentNullException.ThrowIfNull(datasource);
        try
        {
            for (int columnIndex = 0; columnIndex < dbDataReader.FieldCount; columnIndex++)
            {
                string fieldName = dbDataReader.GetName(columnIndex);
                Model.DatasourceField? field = datasource.Fields.FirstOrDefault(f => f.Name == fieldName);
                if (field is null)
                {
                    field = new(datasource)
                    {
                        Name = fieldName
                    };
                    datasource.Fields.Add(field);
                }

                field.Position = columnIndex;
                field.Type = Framework.Base.TypeMapper.GetDbType(dbDataReader.GetFieldType(columnIndex));
                field.Verified = true;
            }

            // Remove fields that are not in the datasource
            foreach (Model.DatasourceField field in datasource.Fields.Where(f => !f.Verified))
            {
                datasource.Fields.Remove(field);
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public static void GetDatasource(Model.Datasource? datasource, ref DbDataReader? dbDataReader)
    {
        GetDatasource(datasource, ref dbDataReader, string.Empty);
    }

    public static void GetDatasource(Model.Datasource? datasource, ref DbDataReader? dbDataReader, string connectionStringToOverride)
    {
        if (datasource is not null && !string.IsNullOrEmpty(GetProviderName(datasource.Provider)))
        {
            DbConnection? dbConnection = CreateAndOpenConnection(datasource, connectionStringToOverride);
            if (dbConnection is not null)
            {
                dbDataReader = GetDataReader(dbConnection, datasource);
                if (dbDataReader is not null && (!dbDataReader.Read() || !GetDatasourceFields(dbDataReader, datasource)))
                {
                    dbDataReader.Close();
                    dbDataReader = null;
                    dbConnection.Close();
                }
            }
        }
    }
}
