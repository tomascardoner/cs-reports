using System.Data.Common;

namespace CardonerSistemas.Reports.Net.Engine
{
    internal static class TextProcessor
    {
        internal static string GetDatasourceFieldValue(Model.Text text, DbDataReader? dbDataReader, Model.Datasource datasource)
        {
            ArgumentNullException.ThrowIfNull(text);

            if (dbDataReader is null)
            {
                return string.Empty;
            }
            Model.DatasourceField? field = datasource.Fields.FirstOrDefault(f => f.FieldId == text.DatasourceFieldId);
            if (field is null)
            {
                return string.Empty;
            }
            if (dbDataReader.GetOrdinal(field.Name) != field.Position)
            {
                field.Position = dbDataReader.GetOrdinal(field.Name);
            }
            if (dbDataReader.IsDBNull(field.Position))
            {
                return string.Empty;
            }

            try
            {
                return Value.GetTypeFromDbType(field.Type) switch
                {
                    Model.Value.Types.Text => field.Type switch
                    {
                        System.Data.DbType.AnsiString => dbDataReader.GetString(field.Position),
                        System.Data.DbType.String => dbDataReader.GetString(field.Position),
                        System.Data.DbType.AnsiStringFixedLength => dbDataReader.GetString(field.Position),
                        System.Data.DbType.StringFixedLength => dbDataReader.GetString(field.Position),
                        System.Data.DbType.Xml => dbDataReader.GetString(field.Position),
                        _ => string.Empty
                    },
                    Model.Value.Types.Integer => field.Type switch
                    {
                        System.Data.DbType.Byte => dbDataReader.GetByte(field.Position).ToString(text.Format),
                        System.Data.DbType.Int16 => dbDataReader.GetInt16(field.Position).ToString(text.Format),
                        System.Data.DbType.Int32 => dbDataReader.GetInt32(field.Position).ToString(text.Format),
                        System.Data.DbType.Int64 => dbDataReader.GetInt64(field.Position).ToString(text.Format),
                        System.Data.DbType.SByte => dbDataReader.GetByte(field.Position).ToString(text.Format),
                        System.Data.DbType.UInt16 => dbDataReader.GetInt16(field.Position).ToString(text.Format),
                        System.Data.DbType.UInt32 => dbDataReader.GetInt32(field.Position).ToString(text.Format),
                        System.Data.DbType.UInt64 => dbDataReader.GetInt64(field.Position).ToString(text.Format),
                        _ => string.Empty
                    },
                    Model.Value.Types.Decimal => field.Type switch
                    {
                        System.Data.DbType.Currency => dbDataReader.GetDecimal(field.Position).ToString(text.Format),
                        System.Data.DbType.Decimal => dbDataReader.GetDecimal(field.Position).ToString(text.Format),
                        System.Data.DbType.Double => dbDataReader.GetDouble(field.Position).ToString(text.Format),
                        System.Data.DbType.Single => dbDataReader.GetFloat(field.Position).ToString(text.Format),
                        _ => string.Empty
                    },
                    Model.Value.Types.DateTime => field.Type switch
                    {
                        System.Data.DbType.Date => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        System.Data.DbType.DateTime => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        System.Data.DbType.Time => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        System.Data.DbType.DateTime2 => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        System.Data.DbType.DateTimeOffset => dbDataReader.GetDateTime(field.Position).ToString(text.Format),
                        _ => string.Empty
                    },
                    Model.Value.Types.YesNo => field.Type switch
                    {
                        System.Data.DbType.Boolean => dbDataReader.GetBoolean(field.Position) ? Properties.Resources.StringGeneralYes : Properties.Resources.StringGeneralNo,
                        _ => string.Empty
                    },
                    _ => string.Empty
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }

        internal static string GetDatasourceParameterValue(Model.Text text, Model.Datasource datasource)
        {
            ArgumentNullException.ThrowIfNull(text);

            Model.DatasourceParameter? parameter = datasource.Parameters.FirstOrDefault(p => p.ParameterId == text.DatasourceParameterId);
            if (parameter is null || parameter.Value is null)
            {
                return string.Empty;
            }

            try
            {
#pragma warning disable S6580 // Use a format provider when parsing date and time
                return Value.GetTypeFromDbType(parameter.Type) switch
                {
                    Model.Value.Types.Text => (string)parameter.Value,
                    Model.Value.Types.Integer => long.Parse(parameter.Value.ToString()!).ToString(text.Format),
                    Model.Value.Types.Decimal => decimal.Parse(parameter.Value.ToString()!).ToString(text.Format),
                    Model.Value.Types.DateTime => DateTime.Parse(parameter.Value.ToString()!).ToString(text.Format),
                    Model.Value.Types.YesNo => (bool)parameter.Value ? Properties.Resources.StringGeneralYes : Properties.Resources.StringGeneralNo,
                    _ => string.Empty
                };
#pragma warning restore S6580 // Use a format provider when parsing date and time
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }

        internal static string GetReportParameterValue(Model.Text text, Model.Report report)
        {
            ArgumentNullException.ThrowIfNull(text);

            Model.ReportParameter? parameter = report.Parameters.FirstOrDefault(p => p.ParameterId == text.ReportParameterId);
            if (parameter is null || parameter.Value is null)
            {
                return string.Empty;
            }

            try
            {
#pragma warning disable S6580 // Use a format provider when parsing date and time
                return parameter.Type switch
                {
                    Model.Value.Types.Text => (string)parameter.Value,
                    Model.Value.Types.Integer => long.Parse(parameter.Value.ToString()!).ToString(text.Format),
                    Model.Value.Types.Decimal => decimal.Parse(parameter.Value.ToString()!).ToString(text.Format),
                    Model.Value.Types.DateTime => DateTime.Parse(parameter.Value.ToString()!).ToString(text.Format),
                    Model.Value.Types.YesNo => (bool)parameter.Value ? Properties.Resources.StringGeneralYes : Properties.Resources.StringGeneralNo,
                    _ => string.Empty
                };
#pragma warning restore S6580 // Use a format provider when parsing date and time
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
}
